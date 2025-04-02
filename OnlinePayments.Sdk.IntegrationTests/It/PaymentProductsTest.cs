using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Merchant.Products;
using System.Threading.Tasks;

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

            using (IClient client = GetClient())
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
