using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    /// <summary>Browser values collected with JavaScript on the checkout page.</summary>
    public class BrowserInfo
    {
        public int ColorDepth { get; set; }

        public bool JavaEnabled { get; set; }

        public int ScreenHeight { get; set; }

        public int ScreenWidth { get; set; }

        public int TimezoneOffsetUtcMinutes { get; set; }

        public string Locale { get; set; }
    }

    /// <summary>Card details as entered by the customer. Never log or store this object.</summary>
    public class CardInput
    {
        public string Number { get; set; }

        public string HolderName { get; set; }

        /// <summary>MMYY, e.g. 1230 for December 2030.</summary>
        public string ExpiryDate { get; set; }

        public string Cvv { get; set; }
    }

    public static class CustomerDeviceBuilder
    {
        // [START customer-device]
        // 3-D Secure needs details about the customer's browser. Collect the browser values with
        // JavaScript on the checkout page and read the rest from the HTTP request.
        public static CustomerDevice Build(HttpRequest httpRequest, BrowserInfo browser)
        {
            return new CustomerDevice
            {
                AcceptHeader = httpRequest.Headers["Accept"].ToString(),
                UserAgent = httpRequest.Headers["User-Agent"].ToString(),
                IpAddress = httpRequest.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Locale = browser.Locale,
                TimezoneOffsetUtcMinutes = browser.TimezoneOffsetUtcMinutes.ToString(),
                BrowserData = new BrowserData
                {
                    ColorDepth = browser.ColorDepth,
                    JavaEnabled = browser.JavaEnabled,
                    JavaScriptEnabled = true,
                    ScreenHeight = browser.ScreenHeight.ToString(),
                    ScreenWidth = browser.ScreenWidth.ToString(),
                },
            };
        }
        // [END customer-device]
    }

    public static class CreatePaymentResponseHandler
    {
        // [START payment-response-handle]
        // Use for every CreatePayment response: server-to-server, Hosted Tokenization, Hosted Fields
        // and client integration.
        public static PaymentStep Handle(CreatePaymentResponse response, string orderId, IOrderStore orders)
        {
            orders.SavePaymentId(orderId, response.Payment.Id);

            if (response.MerchantAction?.ActionType == "REDIRECT")
            {
                // 3-D Secure challenge or a third-party page. Redirect to the URL exactly as returned.
                // The customer comes back on your return URL; then read the status with GetPaymentDetails.
                return PaymentStep.Redirect(response.MerchantAction.RedirectData.RedirectURL);
            }

            // No customer action needed: the result is already known.
            OrderPaymentState state = PaymentStatusExample.ToOrderState(response.Payment.Status, response.Payment.StatusOutput);
            orders.SaveState(orderId, state);
            return PaymentStep.Done(state);
        }
        // [END payment-response-handle]
    }

    // [START payment-attempt-key]
    // One idempotence key per payment attempt, stored with the order.
    public static class PaymentAttempt
    {
        // Call Start when the customer begins to pay, for example when you show the payment form, and again
        // before a new attempt after a decline or a rejected request. It stores the key before any
        // CreatePayment call.
        public static string Start(string orderId, IOrderStore orders)
        {
            string key = Guid.NewGuid().ToString();
            orders.SaveIdempotenceKey(orderId, key);
            return key;
        }

        // The request that creates the payment reads the stored key. A double submit, a retry after a timeout
        // and a restart then send the same key, so the platform does not create a second payment.
        public static string KeyFor(string orderId, IOrderStore orders)
        {
            string key = orders.GetIdempotenceKey(orderId);
            if (key == null)
            {
                throw new InvalidOperationException("No payment attempt was started for order " + orderId);
            }
            return key;
        }
    }
    // [END payment-attempt-key]

    public class ServerToServerExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public ServerToServerExample(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START server-to-server-create]
        // Card data on your server puts you in scope of PCI DSS SAQ D.
        // Use Hosted Tokenization or Hosted Fields unless you are certified for it.
        public async Task<PaymentStep> PayWithCard(
            string orderId, long amountInCents, string currencyCode, int paymentProductId,
            CardInput card, CustomerDevice device, string returnUrl)
        {
            var request = new CreatePaymentRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                    Customer = new Customer { Device = device },
                },
                CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInput
                {
                    // e.g. 1 = Visa, 3 = Mastercard.
                    PaymentProductId = paymentProductId,
                    Card = new Card
                    {
                        CardNumber = card.Number,
                        CardholderName = card.HolderName,
                        ExpiryDate = card.ExpiryDate,
                        Cvv = card.Cvv,
                    },
                    // SALE: authorised and captured at once. Acquirers that do not support it ignore it.
                    // FINAL_AUTHORIZATION: capture the full amount within 7 days.
                    // PRE_AUTHORIZATION: can be reversed; capture the authorised amount or less within 30 days.
                    AuthorizationMode = "SALE",
                    ThreeDSecure = new ThreeDSecure
                    {
                        RedirectionData = new RedirectionData { ReturnUrl = returnUrl },
                    },
                },
            };

            var context = new CallContext().WithIdempotenceKey(PaymentAttempt.KeyFor(orderId, _orders));
            CreatePaymentResponse response = await _merchantClient.Payments.CreatePayment(request, context);
            return CreatePaymentResponseHandler.Handle(response, orderId, _orders);
        }
        // [END server-to-server-create]
    }
}
