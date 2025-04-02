using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Merchant.ProductGroups;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It
{
    public class PaymentProductsGroupsTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for product groups service.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            var lParams = new GetProductGroupParams
            {
                CountryCode = "NL",
                CurrencyCode = "EUR"
            };

            using (IClient client = GetClient())
            {
                PaymentProductGroup response = await client
                    .WithNewMerchant(GetMerchantId())
                    .ProductGroups
                    .GetProductGroup("cards", lParams)
                    .ConfigureAwait(false);

                Assert.IsNotNull(response);
                Assert.IsTrue(string.Equals("cards", response.Id, System.StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
