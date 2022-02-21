using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.It
{
    public class CreateSessionTest : IntegrationTest
    {
        /**
         * Smoke Test for products service.
         */
        [TestCase]
        public async Task Test()
        {
            var lParams = new SessionRequest();

            using (Client client = GetClient())
            {
                var l = Logging.SystemConsoleCommunicatorLogger.Instance;
                var response = await client
                    .WithNewMerchant(GetMerchantId())
                    .Sessions
                    .CreateSession(lParams)
                    .ConfigureAwait(false);
            }
        }
    }
}
