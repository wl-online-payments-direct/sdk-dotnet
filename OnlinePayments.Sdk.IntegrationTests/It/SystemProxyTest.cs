using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.It
{
    [TestFixture]
    public class SystemProxyTest : IntegrationTest
    {
        /// <summary>
        /// Smoke Test for using a proxy configured through system properties.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            CommunicatorConfiguration configuration = GetCommunicatorConfiguration();

            using (IClient client = Factory.CreateClient(configuration))
            {
                TestConnection response = await client
                    .WithNewMerchant(GetMerchantId())
                    .Services
                    .TestConnection()
                    .ConfigureAwait(false);

                Assert.NotNull(response.Result);
            }
        }
    }
}
