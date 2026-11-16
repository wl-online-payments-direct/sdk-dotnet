# .NET SDK reference

How to install and set up `OnlinePayments.Sdk`, and the SDK calls for the API operations used in this skill.
Source code and README: https://github.com/wl-online-payments-direct/sdk-dotnet

## Install

```
dotnet add package OnlinePayments.Sdk
```

For a strong-named assembly use `OnlinePayments.Sdk.StrongName` instead. The SDK targets .NET Standard 2.0
(.NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+).

## Namespaces

| Namespace | Contains |
|---|---|
| `OnlinePayments.Sdk` | `Factory`, `IClient`, `CommunicatorConfiguration`, `CallContext`, the exceptions, `WebhooksEvent` |
| `OnlinePayments.Sdk.Merchant` | `IMerchantClient`; its sub-clients are in namespaces such as `OnlinePayments.Sdk.Merchant.Payments` |
| `OnlinePayments.Sdk.Domain` | All request and response classes (`CreatePaymentRequest`, `Order`, `AmountOfMoney`, ...) |
| `OnlinePayments.Sdk.Webhooks` | `WebhooksHelper`, `InMemorySecretKeyStore`, `ISecretKeyStore`, `SignatureValidationException`, `ApiVersionMismatchException` |
| `OnlinePayments.Sdk.Communication` | `RequestHeader`, `IRequestHeader`, `CommunicationException` |
| `OnlinePayments.Sdk.Json` | `DefaultMarshaller`, `MarshallerSyntaxException` |
| `OnlinePayments.Sdk.Logging` | `ICommunicatorLogger`, `SystemConsoleCommunicatorLogger` |

## Client setup

ASP.NET Core with `IHttpClientFactory` (recommended):

```csharp
// ASP.NET Core: bind and validate the settings once, so that a missing value stops the application at
// startup with a clear message instead of failing on the first payment. Register one client for the
// whole application. It is thread-safe; never create a client per request.
public static void AddPaymentClient(IServiceCollection services)
{
    services.AddOptions<OnlinePaymentsOptions>()
        .BindConfiguration("OnlinePayments")
        .ValidateDataAnnotations()
        .ValidateOnStart();

    services.AddHttpClient("OnlinePayments");

    services.AddSingleton<IClient>(serviceProvider =>
    {
        OnlinePaymentsOptions options = serviceProvider.GetRequiredService<IOptions<OnlinePaymentsOptions>>().Value;
        var configuration = new CommunicatorConfiguration
        {
            ApiEndpoint = new Uri(options.ApiEndpoint),
            ApiKeyId = options.ApiKeyId,
            SecretApiKey = options.ApiSecret,
            Integrator = options.Integrator,
        }.WithHttpClientFactory(serviceProvider.GetRequiredService<IHttpClientFactory>(), "OnlinePayments");

        return Factory.CreateClient(configuration);
    });

    // Every API call goes through the merchant client.
    services.AddSingleton<IMerchantClient>(serviceProvider =>
        serviceProvider.GetRequiredService<IClient>()
            .WithNewMerchant(serviceProvider.GetRequiredService<IOptions<OnlinePaymentsOptions>>().Value.MerchantId));
}
```

The settings are validated at startup: a missing value stops the application with a message that names it. The
integrator is mandatory: `Factory.CreateClient` throws `ArgumentException("integrator is required")` without it.

Without dependency injection, build the same `CommunicatorConfiguration` without `WithHttpClientFactory`, call
`Factory.CreateClient(configuration)` once, keep the `IClient` for the lifetime of the application and dispose it on
shutdown. `IClient` and `IMerchantClient` are thread-safe.

## Conventions

- Every API call is `async` and returns a `Task`. Use `await`; do not block with `.Result` or `.Wait()`.
- Request and response classes use properties with the API names in PascalCase (`order.amountOfMoney` is
  `Order.AmountOfMoney`). Numbers and booleans are nullable (`long?`, `bool?`): compare with `== true`.
- Each property also has a fluent `With...` method, e.g. `new Order().WithAmountOfMoney(...)`.
- The last parameter of every call is an optional `CallContext`. Set the idempotence key with
  `new CallContext().WithIdempotenceKey(key)`. After the call, `context.IdempotenceRequestTimestamp` is set if the
  platform returned the result of an earlier request with the same key.
- `GetHostedCheckoutResponse.CreatedPaymentOutput` holds the `Payment` and a `PaymentStatusCategory`. Decide on
  `Payment.StatusOutput`; it can be missing, so use `statusOutput?.StatusCategory`.
- Members marked `[Obsolete]` are deprecated in the API. Use the replacement named in the message.

## API operations used in this skill

All calls start from the merchant client: `IMerchantClient merchant = client.WithNewMerchant(merchantId)`.

| API operation | SDK call | Used in |
|---|---|---|
| CreateHostedCheckout | `merchant.HostedCheckout.CreateHostedCheckout(CreateHostedCheckoutRequest, context)` | Hosted Checkout, recurring payments |
| GetHostedCheckout | `merchant.HostedCheckout.GetHostedCheckout(hostedCheckoutId)` | Hosted Checkout |
| CreateHostedTokenization | `merchant.HostedTokenization.CreateHostedTokenization(CreateHostedTokenizationRequest)` | Hosted Tokenization |
| CreateHostedFieldsSession | `merchant.HostedFields.CreateHostedFieldsSession(CreateHostedFieldsSessionRequest)` | Hosted Fields |
| CreateSession | `merchant.Sessions.CreateSession(SessionRequest)` | Client integration |
| CreatePayment | `merchant.Payments.CreatePayment(CreatePaymentRequest, context)` | Server-to-server, Hosted Tokenization, Hosted Fields, client integration |
| GetPaymentDetails | `merchant.Payments.GetPaymentDetails(paymentId)` | Payment status, webhooks, error handling |
| CapturePayment | `merchant.Payments.CapturePayment(paymentId, CapturePaymentRequest, context)` | After-payment operations |
| RefundPayment | `merchant.Payments.RefundPayment(paymentId, RefundRequest, context)` | After-payment operations |
| CancelPayment | `merchant.Payments.CancelPayment(paymentId, CancelPaymentRequest, context)` | After-payment operations |
| SubsequentPayment | `merchant.Subsequent.SubsequentPayment(paymentId, SubsequentPaymentRequest, context)` | Recurring payments |
| CreatePaymentLink | `merchant.PaymentLinks.CreatePaymentLink(CreatePaymentLinkRequest, context)` | Payment Links |
| GetPaymentLinkById | `merchant.PaymentLinks.GetPaymentLinkById(paymentLinkId)` | Payment Links |

For anything else, use the API reference; the SDK's sub-clients and method names match the operation names there.

## Exceptions

All in `OnlinePayments.Sdk` unless noted. Catch the specific ones before `ApiException`.

| Exception | When |
|---|---|
| `DeclinedPaymentException` | The error response carries a payment result: a declined payment (seen with 402 and 403), also for `SubsequentPayment`. The body decides, not the status. `CreatePaymentResponse` holds the created payment (`.Payment.Id`). |
| `DeclinedRefundException` | The error response carries a refund result (the body decides, not the status). `RefundResponse` holds it. |
| `IdempotenceException` | 409 on a call with an idempotence key, with a single error with error code `30001002`: a request with the same idempotence key is still running. Has `IdempotenceKey`. |
| `ValidationException` | 400: invalid request, including an operation that the payment's state does not allow (error `id` `ACTION_NOT_ALLOWED_ON_TRANSACTION`). |
| `AuthorizationException` | 403: wrong API key ID, secret or merchant ID (error `id` `ACCESS_TO_MERCHANT_NOT_ALLOWED`), or an action that is not allowed. |
| `ReferenceException` | 404 (object not found), 410, and a 409 that is not the idempotence case above. |
| `PlatformException` | 500, 502, 503. Retry only if an error has `Retriable == true`, with a new idempotence key. |
| `ApiException` | Base class of all the above; any other error status, including 401 and 402 without a payment result. Other `ApiException` subclasses, `ProblemDetailsException` and `DeclinedPayoutException`, are raised by operations this skill does not use. Has `StatusCode`, `ErrorId`, `Errors`, `ResponseBody`. |
| `OnlinePayments.Sdk.Communication.CommunicationException` | No valid response: timeout, connection error, or an error response with an empty body or a content type that is not JSON (a 404 like that raises a plain `NotFoundException`). Not an `ApiException`. |
| `OnlinePayments.Sdk.Webhooks.SignatureValidationException` | Webhook signature check failed: missing, duplicate or wrong `X-GCS-Signature` or `X-GCS-KeyId`. `SecretKeyNotAvailableException` (unknown key ID) is a subclass. |
| `OnlinePayments.Sdk.Webhooks.ApiVersionMismatchException` | `Unmarshal`: the signature is valid but the event has an API version this SDK does not support. Not a `SignatureValidationException`. |
| `OnlinePayments.Sdk.Json.MarshallerSyntaxException` | `Unmarshal`: the signature is valid but the body is not valid JSON. An API call raises it too when the response has a JSON content type but invalid JSON. Not a `SignatureValidationException`. |

`Errors` is a list of `APIError` with `ErrorCode`, `PropertyName`, `Message` and `Retriable`.

`ApiException.Message` is a fixed text (for the declined exceptions it holds the payment or refund ID and status), but `ApiException.ToString()` appends the status code and the `ResponseBody`.
So `logger.LogError(e, ...)` and `e.ToString()` log the response body. That is fine for Hosted Checkout calls, whose
error body is a plain error response. For an error that carries a payment or refund (`DeclinedPaymentException`,
`DeclinedRefundException`), log `ErrorId`, `StatusCode` and the error codes instead.

## Webhooks

`new WebhooksHelper(DefaultMarshaller.Instance, secretKeyStore)` and `helper.Unmarshal(body, headers)`, where `body`
is the raw body (`byte[]` or `string`) and `headers` is a list of `RequestHeader(name, value)`: one object per
received header value. It rejects a repeated `X-GCS-Signature` or `X-GCS-KeyId` header, which a single joined value
would hide. It returns a `WebhooksEvent` with `Id`, `Type`, `Created`, `MerchantId` and one of `Payment`, `Refund`,
`PaymentLink`, `Payout`, `Token`. See `webhooks.md` for the full handler.

`InMemorySecretKeyStore.Instance` is shared by the whole process, and `StoreSecretKey` throws `ArgumentException`
when the key ID is already stored. Call `RemoveSecretKey` first, as the setup code does, so the setup can run twice.

## Logging

`client.EnableLogging(SystemConsoleCommunicatorLogger.Instance)` logs requests and responses with card data and
secrets masked. Implement `ICommunicatorLogger` to send the log to your own logger. Do not log request or response
objects yourself.
