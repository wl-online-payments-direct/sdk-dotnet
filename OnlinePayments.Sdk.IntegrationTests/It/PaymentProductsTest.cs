using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It
{
    public class PaymentProductsTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for products service.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            var lParams = new GetPaymentProductsParams
            {
                CountryCode = "NL",
                CurrencyCode = "EUR"
            };

            using (Client client = GetClient())
            {
                GetPaymentProductsResponse response = await client
                    .WithNewMerchant(GetMerchantId())
                    .Products
                    .GetPaymentProducts(lParams)
                    .ConfigureAwait(false);

                Assert.That(response.PaymentProducts, Is.Not.Empty);
            }
        }
    }
}
