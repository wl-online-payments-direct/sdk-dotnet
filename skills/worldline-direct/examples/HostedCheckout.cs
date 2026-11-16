using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class HostedCheckoutExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;
        private readonly string _publicBaseUrl;
        private readonly ILogger<HostedCheckoutExample> _logger;

        public HostedCheckoutExample(
            IMerchantClient merchantClient,
            IOrderStore orders,
            IOptions<OnlinePaymentsOptions> options,
            ILogger<HostedCheckoutExample> logger)
        {
            _merchantClient = merchantClient;
            _orders = orders;
            _publicBaseUrl = options.Value.PublicBaseUrl;
            _logger = logger;
        }

        // [START hosted-checkout-create]
        // Returns the URL to redirect the customer to.
        public async Task<string> StartCheckout(string orderId, long amountInCents, string currencyCode)
        {
            var request = new CreateHostedCheckoutRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                },
                HostedCheckoutSpecificInput = new HostedCheckoutSpecificInput
                {
                    ReturnUrl = BuildReturnUrl(orderId),
                    Locale = "en-GB",
                },
            };

            CreateHostedCheckoutResponse response = await CreateHostedCheckoutWithRetry(request);

            // Store both values with the order before the customer leaves your site.
            _orders.SaveHostedCheckout(orderId, response.HostedCheckoutId, response.RETURNMAC);

            // Redirect to this URL exactly as returned. Do not build it from PartialRedirectUrl.
            return response.RedirectUrl;
        }

        // The base of the return URL comes from your configuration, never from the request's Host header:
        // the sender controls that header. Escape the order reference, it ends up in a query string.
        public string BuildReturnUrl(string orderId)
        {
            return _publicBaseUrl.TrimEnd('/') + "/return?orderId=" + Uri.EscapeDataString(orderId);
        }
        // [END hosted-checkout-create]

        // [START hosted-checkout-retry]
        // CreateHostedCheckout does not support idempotent requests: the platform ignores an idempotence key, so
        // every resend creates a new session. That is harmless until the customer pays in it; the unused session
        // expires. Send it again after no answer or after an error marked retriable.
        // The waiting happens inside the customer's request, so the browser waits too: keep the attempts few and
        // the delays short, or move the call to a background job.
        public async Task<CreateHostedCheckoutResponse> CreateHostedCheckoutWithRetry(CreateHostedCheckoutRequest request)
        {
            for (int attempt = 1; ; attempt++)
            {
                try
                {
                    return await _merchantClient.HostedCheckout.CreateHostedCheckout(request);
                }
                catch (CommunicationException) when (attempt < 3)
                {
                    // Timeout or connection error: the session may or may not exist.
                    await Task.Delay(TimeSpan.FromSeconds(attempt));
                }
                catch (ApiException e) when (attempt < 3 && e.Errors.Any(error => error.Retriable == true))
                {
                    // Marked retriable: the request was not processed.
                    await Task.Delay(TimeSpan.FromSeconds(attempt));
                }
                // Any other error is not retried and reaches the caller. The error of a Hosted Checkout call is a
                // plain error response (error ID and errors), so logging the exception is fine here; log at least
                // ErrorId, StatusCode and the error codes.
            }
        }
        // [END hosted-checkout-retry]

        // [START hosted-checkout-return]
        // Called when the customer comes back on your return URL.
        public async Task<OrderPaymentState> HandleReturn(string orderId, string returnMacFromQuery)
        {
            StoredHostedCheckout stored = _orders.GetHostedCheckout(orderId);

            // The platform appends RETURNMAC to the return URL. It identifies the returning customer:
            // a missing or different value means the request does not belong to this checkout.
            if (!SameValue(stored.ReturnMac, returnMacFromQuery))
            {
                throw new InvalidOperationException("RETURNMAC does not match the stored value for order " + orderId);
            }

            // Never trust the redirect alone: read the result from the platform.
            GetHostedCheckoutResponse hostedCheckout;
            try
            {
                hostedCheckout = await _merchantClient.HostedCheckout.GetHostedCheckout(stored.HostedCheckoutId);
            }
            catch (ReferenceException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                // The API reference documents a 404 for this call. If it fails with not found, read the payment
                // instead, with the payment ID that your webhook handler stored. Other errors reach the caller,
                // including the 409 and 410 that the SDK also raises as ReferenceException.
                _logger.LogWarning("GetHostedCheckout failed for order {OrderId}, errorId {ErrorId}, status {StatusCode}",
                    orderId, e.ErrorId, e.StatusCode);
                string paymentId = _orders.GetPaymentId(orderId);
                if (paymentId == null)
                {
                    // No payment ID yet: keep the order pending. The webhook or your reconciliation job settles
                    // it. Do not mark it failed.
                    return OrderPaymentState.Pending;
                }
                PaymentDetailsResponse details = await _merchantClient.Payments.GetPaymentDetails(paymentId);
                OrderPaymentState fallbackState = PaymentStatusExample.ToOrderState(details.Status, details.StatusOutput);
                _orders.SaveState(orderId, fallbackState);
                return fallbackState;
            }

            switch (hostedCheckout.Status)
            {
                case "PAYMENT_CREATED":
                    PaymentResponse payment = hostedCheckout.CreatedPaymentOutput.Payment;
                    _orders.SavePaymentId(orderId, payment.Id);
                    OrderPaymentState state = PaymentStatusExample.ToOrderState(payment.Status, payment.StatusOutput);
                    _orders.SaveState(orderId, state);
                    return state;
                case "CANCELLED_BY_CONSUMER":
                    // The customer cancelled, or the session expired (the created payment is then cancelled with
                    // the error id CANCELLED_BY_EXPIRATION).
                    _orders.SaveState(orderId, OrderPaymentState.Cancelled);
                    return OrderPaymentState.Cancelled;
                default:
                    // IN_PROGRESS: the customer has not finished. A webhook will report the result.
                    return OrderPaymentState.Pending;
            }
        }

        // Compares in constant time, so the comparison does not reveal the stored value. FixedTimeEquals needs
        // .NET Core 2.1+ or .NET 5+; on .NET Framework compare the bytes in a loop that never returns early.
        private static bool SameValue(string expected, string actual)
        {
            if (string.IsNullOrEmpty(expected) || string.IsNullOrEmpty(actual))
            {
                return false;
            }
            return CryptographicOperations.FixedTimeEquals(Encoding.UTF8.GetBytes(expected), Encoding.UTF8.GetBytes(actual));
        }
        // [END hosted-checkout-return]
    }
}
