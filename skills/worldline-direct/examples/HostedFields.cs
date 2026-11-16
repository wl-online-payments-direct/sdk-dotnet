using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class HostedFieldsExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public HostedFieldsExample(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START hosted-fields-create]
        // Creates the session that the Hosted Fields script on your checkout page needs.
        public async Task<CreateHostedFieldsSessionResponse> CreateSession(string checkoutPageOrigin)
        {
            var request = new CreateHostedFieldsSessionRequest
            {
                Locale = "en-GB",
                // The origin of your checkout page, e.g. https://shop.example
                Origin = checkoutPageOrigin,
            };

            CreateHostedFieldsSessionResponse response = await _merchantClient.HostedFields.CreateHostedFieldsSession(request);

            // Send SdkUrl, SdkSri and SessionData to the page. Pass SessionData on unchanged.
            return response;
        }
        // [END hosted-fields-create]

        // [START hosted-fields-payment]
        // The page calls tokenize() and tells your server the card is ready.
        // hostedFieldsSessionId is HostedFieldsSessionId from the CreateSession response; SessionData.HostedFieldsSessionId holds the same value.
        public async Task<PaymentStep> Pay(
            string orderId, string hostedFieldsSessionId, long amountInCents, string currencyCode,
            CustomerDevice device, string returnUrl)
        {
            var request = new CreatePaymentRequest
            {
                HostedFieldsSessionId = hostedFieldsSessionId,
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
        // [END hosted-fields-payment]
    }
}
