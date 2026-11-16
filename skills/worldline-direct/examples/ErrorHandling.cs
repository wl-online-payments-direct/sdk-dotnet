using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class ErrorHandlingExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;
        private readonly ILogger<ErrorHandlingExample> _logger;

        public ErrorHandlingExample(IMerchantClient merchantClient, IOrderStore orders, ILogger<ErrorHandlingExample> logger)
        {
            _merchantClient = merchantClient;
            _orders = orders;
            _logger = logger;
        }

        // [START error-handling]
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
        // [END error-handling]
    }
}
