# Error handling

When the platform answers with an error, the SDK reports it as an exception or as an error response, depending on
the SDK; `dotnet.md` describes how this SDK does it and names its error types. Every API error carries the HTTP
status code and a list of errors with an `errorCode` and an `id`; a validation error names the field in
`propertyName` when it is about one field. A 404 also carries an `errorId` (quote it to support) and a `message`. A 400 validation error can
come without `errorId`, `message` and `retriable`: do not rely on them being set, and log the error codes, ids and
property names. A Hosted Checkout validation error does not repeat the values you sent.

## What to do per error

| Situation | HTTP | What to do |
|---|---|---|
| Payment declined | error with a payment result in the body (402 for an acquirer decline, 403 for a failed 3-D Secure authentication) | The payment exists. Read its status with `GetPaymentDetails` before deciding anything (mandatory rule 5). Show the customer a neutral message and let them try again. |
| Request still running for this idempotence key | 409 | The first request with the same key is still being processed. Wait a moment and send the same request with the same key. |
| Invalid request | 400 | Fix the request. Do not retry. The errors list names the property, if the error is about one. |
| Operation not allowed in the payment's state | 400 | The error id is `ACTION_NOT_ALLOWED_ON_TRANSACTION` and no property is named: for example a capture after the final capture or after a cancel, a refund before the capture or above the remaining amount, a second cancel. Read the status with `GetPaymentDetails`. Do not retry. |
| Wrong credentials or merchant ID | 403 with the error id `ACCESS_TO_MERCHANT_NOT_ALLOWED` and no payment in the body | Check the API key ID, secret, merchant ID and endpoint. Do not retry. |
| Object not found | 404 | Check the ID. |
| Technical error marked retriable | check `retriable` | If an error in the list has `retriable` = true, the request was not processed. Send it again with a **new** idempotence key, with a growing delay. Without `retriable`, do not retry. |
| Timeout or connection error | none | The request may or may not have been processed. Retry with the same idempotence key. For an operation that supports idempotence (see mandatory rule 1) the platform returns the original result instead of processing it twice. If retries fail, check with `GetPaymentDetails` before creating a new payment. |

## Rules

- Handle the most specific error first, for example a declined payment before a general API error. How the SDK
  reports errors, and which error type is the most general, differs per SDK; see `dotnet.md`.
- Reuse the idempotence key only when you got no answer (timeout, connection error) or a 409 for a request that is
  still running: the outcome is unknown, and a new key could create a second payment.
- Use a new key only when the platform answered with an error marked `retriable`: that request was not processed.
- Log fields, not bodies: the `errorId`, HTTP status, error codes and error ids. A payment ID with its status is
  also fine. Never log the request yourself. The SDK's own logging masks card data; it is off by default.
- Printing or serialising the SDK's error object can include the platform's response body; `dotnet.md` says
  how for this SDK. For Hosted Checkout create and get calls the body is a plain error response (an error ID and a
  list of errors), so logging the error object is fine there. Never log the body of a response that carries a
  payment: the error of a declined payment, or a successful `GetPaymentDetails` or `GetHostedCheckout`
  response. It holds the card's expiry date, which mandatory rule 6 forbids in logs, and customer data;
  only the card number arrives masked.
- Waiting between retries blocks the thread, and inside a customer's request it blocks the customer's browser. Keep
  the number of attempts and the delays small there, or hand the call to a background job.
- Show customers a neutral message. Do not show error codes or decline reasons.

```csharp
// idempotenceKey is the stored key of the payment attempt (PaymentAttempt.KeyFor). Reuse it when a request
// got no answer; replace it, stored again, only when the platform answered with an error marked retriable.
public async Task<PaymentStep> CreatePayment(string orderId, CreatePaymentRequest request, string idempotenceKey)
{
    var context = new CallContext().WithIdempotenceKey(idempotenceKey);
    for (int attempt = 1; ; attempt++)
    {
        try
        {
            CreatePaymentResponse response = await _merchantClient.Payments.CreatePayment(request, context);
            return CreatePaymentResponseHandler.Handle(response, orderId, _orders);
        }
        catch (DeclinedPaymentException e)
        {
            // The payment exists but was declined. Read its status before deciding anything.
            string paymentId = e.CreatePaymentResponse?.Payment?.Id;
            if (paymentId == null)
            {
                _orders.SaveState(orderId, OrderPaymentState.Failed);
                return PaymentStep.Done(OrderPaymentState.Failed);
            }
            _orders.SavePaymentId(orderId, paymentId);
            PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);
            OrderPaymentState state = PaymentStatusExample.ToOrderState(details.Status, details.StatusOutput);
            _orders.SaveState(orderId, state);
            return PaymentStep.Done(state);
        }
        catch (IdempotenceException) when (attempt < 3)
        {
            // The first request with this key is still running. Wait, then send the same request again.
            await Task.Delay(TimeSpan.FromSeconds(2 * attempt));
        }
        catch (CommunicationException) when (attempt < 3)
        {
            // Timeout or connection error: the payment may or may not exist. Retry with the same key;
            // the platform returns the original result instead of creating a second payment.
            await Task.Delay(TimeSpan.FromSeconds(2 * attempt));
        }
        catch (ValidationException e)
        {
            // 400: the request is invalid. Fix the request; retrying does not help.
            // Log the error codes and the ErrorId, never the request (it can hold card data).
            _logger.LogError("CreatePayment rejected, errorId {ErrorId}: {Errors}", e.ErrorId,
                string.Join("; ", e.Errors.Select(error => error.ErrorCode + " " + error.PropertyName)));
            throw;
        }
        catch (ApiException e) when (attempt < 3 && e.Errors != null && e.Errors.Any(error => error.Retriable == true))
        {
            // A technical error marked retriable: the request was not processed.
            // Send it again with a new key, stored before the call like the first one.
            context = new CallContext().WithIdempotenceKey(PaymentAttempt.Start(orderId, _orders));
            await Task.Delay(TimeSpan.FromSeconds(2 * attempt));
        }
        // Other exceptions are not retried here:
        // AuthorizationException (403): wrong API key, secret or merchant ID.
        // ReferenceException (404, 409, 410): the object does not exist.
        // PlatformException (500, 502, 503) without a retriable error.
        // ApiException: any other error response. Log ErrorId and the error codes.
    }
}
```
