using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It;

public class ConnectionPoolingTest : IntegrationTest
{
    #region ConnectionPooling - Max connections equal to request count

    [TestCase]
    public async Task ConnectionPooling_MaxConnectionsEqualToRequestCount_HandlesConcurrentRequests()
    {
        await TestConnectionPooling(requestCount: 10, maxConnections: 10);
    }

    #endregion

    #region ConnectionPooling - Max connections less than request count

    [TestCase]
    public async Task ConnectionPooling_MaxConnectionsLessThanRequestCount_HandlesConcurrentRequests()
    {
        await TestConnectionPooling(requestCount: 10, maxConnections: 5);
    }

    #endregion

    #region ConnectionPooling - Max connections one

    [TestCase]
    public async Task ConnectionPooling_MaxConnectionsOne_HandlesConcurrentRequests()
    {
        await TestConnectionPooling(requestCount: 10, maxConnections: 1);
    }

    #endregion

    private async Task TestConnectionPooling(int requestCount, int maxConnections)
    {
        var configuration = GetCommunicatorConfiguration().WithMaxConnections(maxConnections);
        using var communicator = Factory.CreateCommunicator(configuration);

        string merchantId = GetMerchantId();
        var barrier = new SemaphoreSlim(0);

        List<Task<TestConnection>> tasks = Enumerable.Range(0, requestCount)
            .Select(_ => RunRequest(barrier, communicator, merchantId))
            .ToList();

        barrier.Release(requestCount);

        TestConnection[] results = await Task.WhenAll(tasks);

        foreach (TestConnection result in results)
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null.And.Not.Empty);
        }
    }

    private static async Task<TestConnection> RunRequest(
        SemaphoreSlim barrier,
        ICommunicator communicator,
        string merchantId)
    {
        await barrier.WaitAsync();

        return await Factory.CreateClient(communicator)
            .WithClientMetaInfo("{}")
            .WithNewMerchant(merchantId)
            .Services
            .TestConnection();
    }
}
