using System.Threading.Tasks;
using OnlinePayments.Sdk;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant;

namespace Examples
{
    public class ClientIntegrationExample
    {
        private readonly IMerchantClient _merchantClient;
        private readonly IOrderStore _orders;

        public ClientIntegrationExample(IMerchantClient merchantClient, IOrderStore orders)
        {
            _merchantClient = merchantClient;
            _orders = orders;
        }

        // [START client-session-create]
        // Creates the session that a Client SDK (JavaScript, iOS, Android, Flutter...) needs to encrypt card data.
        public async Task<SessionResponse> CreateClientSession()
        {
            SessionResponse session = await _merchantClient.Sessions.CreateSession(new SessionRequest());

            // Send ClientSessionId, CustomerId, ClientApiUrl and AssetUrl to the app. Never send your API key.
            return session;
        }
        // [END client-session-create]

        // [START client-encrypted-payment]
        // The Client SDK returns an encrypted string; the app posts it to your server.
        public async Task<PaymentStep> Pay(
            string orderId, string encryptedCustomerInput, long amountInCents, string currencyCode,
            CustomerDevice device, string returnUrl)
        {
            var request = new CreatePaymentRequest
            {
                EncryptedCustomerInput = encryptedCustomerInput,
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
        // [END client-encrypted-payment]
    }
}
