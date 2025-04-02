using NUnit.Framework;
using System;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It
{
    public class IdemPotenceTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for idempotence.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            CreatePaymentRequest body = new CreatePaymentRequest
            {
                Order = new Order
                {
                    AmountOfMoney = new AmountOfMoney
                    {
                        CurrencyCode = "EUR",
                        Amount = 100L
                    },
                    Customer = new Customer
                    {
                        Locale = "en",
                        BillingAddress = new Address
                        {
                            CountryCode = "NL"
                        }
                    }
                },
                CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInput
                {
                    PaymentProductId = 1,
                    IsRecurring = false,
                    ThreeDSecure = new(){ SkipAuthentication = true },
                    Card = new Card
                    {
                        CardholderName = "Wile E. Coyote",
                        CardNumber = "4330264936344675",
                        ExpiryDate = "1230",
                        Cvv = "123"
                    }
                }
            };

            string idempotenceKey = Guid.NewGuid().ToString();
            CallContext context = new CallContext().WithIdempotenceKey(idempotenceKey);

            using (IClient client = GetClient())
            {
                CreatePaymentResponse response = await client.WithNewMerchant(GetMerchantId()).Payments.CreatePayment(body, context)
                    .ConfigureAwait(false);
                string paymentId = response.Payment.Id;

                Assert.AreEqual(idempotenceKey, context.IdempotenceKey);
                Assert.Null(context.IdempotenceRequestTimestamp);

                response = await client.WithNewMerchant(GetMerchantId()).Payments.CreatePayment(body, context)
                    .ConfigureAwait(false);

                Assert.AreEqual(paymentId, response.Payment.Id);

                Assert.AreEqual(idempotenceKey, context.IdempotenceKey);
                Assert.NotNull(context.IdempotenceRequestTimestamp);
            }
        }
    }
}
