using NUnit.Framework;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.It
{
    [TestFixture]
    public class ConnectionTestTest : IntegrationTest
    {
        /// <summary>
        /// Smoke test for test connection.
        /// </summary>
        [TestCase]
        public async Task Test()
        {
            using (IClient client = GetClient())
            {
                await client.WithNewMerchant(GetMerchantId()).Services.TestConnection()
                    .ConfigureAwait(false);
            }
        }
    }
}
