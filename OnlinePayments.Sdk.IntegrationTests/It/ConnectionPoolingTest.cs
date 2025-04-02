using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.It
{
    public class ConnectionPoolingTest : IntegrationTest
    {
        [TestCase(10, 10)]
        [TestCase(10, 5)]
        [TestCase(10, 1)]
        public async Task TestconnectionPooling(int requestCount, int maxConnections)
        {
            var configuration = GetCommunicatorConfiguration().WithMaxConnections(maxConnections);
            using (var communicator = Factory.CreateCommunicator(configuration))
            {
                await ActuallyTestConnectionPooling(communicator, requestCount)
                    .ConfigureAwait(false);
            }
        }

        async Task ActuallyTestConnectionPooling(ICommunicator communicator, int requestCount)
        {
            await Task.WhenAll(Enumerable.Range(0, requestCount)
                               .Select((requestNum) =>
                                          Factory.CreateClient(communicator)
                                          .WithClientMetaInfo("")
                                          .WithNewMerchant(GetMerchantId())
                                          .Services
                                          .TestConnection()
                                     ).ToList()
                              )
                .ConfigureAwait(false);
        }
    }
}
