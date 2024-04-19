using NUnit.Framework;
using OnlinePayments.Sdk.Merchant.ProductGroups;
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

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

            using (Client client = GetClient())
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
