using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class HostedTokenizationExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public HostedTokenizationExample(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START hosted-tokenization-create]
        // Creates the session for the card form iframe on your checkout page.
        public async Task<CreateHostedTokenizationResponse> CreateSession()
        {
            var request = new CreateHostedTokenizationRequest
            {
                Locale = "en-GB",
                // Optional: the file name of a custom template.
                // Variant = "MyTemplate.html",
            };

            CreateHostedTokenizationResponse response = await _merchantClient.HostedTokenization.CreateHostedTokenization(request);

            // Send response.HostedTokenizationUrl (iframe URL) and response.Sri (script integrity) to the page.
            return response;
        }
        // [END hosted-tokenization-create]

        // [START hosted-tokenization-payment]
        // The page calls tokenizer.submitTokenization() and posts result.hostedTokenizationId to your server.
        public async Task<PaymentStep> Pay(
            string orderId, string hostedTokenizationId, long amountInCents, string currencyCode,
            CustomerDevice device, string returnUrl)
        {
            var request = new CreatePaymentRequest
            {
                HostedTokenizationId = hostedTokenizationId,
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney { Amount = amountInCents, CurrencyCode = currencyCode },
                    References = new OrderReferences { MerchantReference = orderId },
                    Customer = new Customer { Device = device },
                },
                CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInput
                {
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
        // [END hosted-tokenization-payment]
    }
}
