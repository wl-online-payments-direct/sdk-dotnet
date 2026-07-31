using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It;

public class ConnectionPoolingTest : IntegrationTest
{
    private const string HttpClientName = "ConnectionPoolingTest";

    #region ConnectionPooling - oversubscribed, must not fail or deadlock

    // requestCount is deliberately >> maxConnections so requests are forced to
    // queue for a connection. With requestCount == maxConnections (as in the
    // original test) the limit is never actually exercised.

    [TestCase(50, 10)]
    [TestCase(50, 5)]
    [TestCase(50, 1)]
    public async Task ConnectionPooling_Oversubscribed_HandlesAllRequestsWithoutFailure(int requestCount, int maxConnections)
    {
        var (results, _) = await RunPoolingScenario(requestCount, maxConnections);

        foreach (TestConnection result in results)
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null.And.Not.Empty);
        }
    }

    #endregion

    #region ConnectionPooling - the limit actually has an effect

    // Proves MaxConnectionsPerServer is wired through IHttpClientFactory rather
    // than silently ignored: a tightly-capped pool must take meaningfully
    // longer than a loosely-capped pool for the same request count, because
    // requests are forced to serialize through fewer connections.

    [TestCase]
    public async Task ConnectionPooling_LowerMaxConnections_IsMeasurablySlowerThanHigher()
    {
        const int requestCount = 30;

        var (_, constrainedElapsed) = await RunPoolingScenario(requestCount, maxConnections: 1);
        var (_, unconstrainedElapsed) = await RunPoolingScenario(requestCount, maxConnections: requestCount);

        TestContext.WriteLine($"maxConnections=1 elapsed: {constrainedElapsed}");
        TestContext.WriteLine($"maxConnections={requestCount} elapsed: {unconstrainedElapsed}");

        // Generous ratio to avoid flakiness from network jitter, while still
        // clearly distinguishing "serialized" from "parallel".
        Assert.That(constrainedElapsed.TotalMilliseconds,
            Is.GreaterThan(unconstrainedElapsed.TotalMilliseconds * 2),
            "Capping MaxConnectionsPerServer had no measurable effect on throughput; " +
            "the setting may not be reaching the underlying SocketsHttpHandler.");
    }

    #endregion

    private async Task<(TestConnection[] Results, TimeSpan Elapsed)> RunPoolingScenario(int requestCount, int maxConnections)
    {
        await using var serviceProvider = new ServiceCollection()
            .AddHttpClient(HttpClientName)
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                MaxConnectionsPerServer = maxConnections,
                PooledConnectionLifetime = TimeSpan.FromSeconds(2),
                PooledConnectionIdleTimeout = TimeSpan.FromSeconds(1),
            })
            .Services
            .BuildServiceProvider();

        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

        var configuration = GetCommunicatorConfiguration()
            .WithHttpClientFactory(httpClientFactory, HttpClientName);

        using var client = Factory.CreateClient(configuration);

        string merchantId = GetMerchantId();
        var barrier = new SemaphoreSlim(0);

        List<Task<TestConnection>> tasks = Enumerable.Range(0, requestCount)
            .Select(_ => RunRequest(barrier, client, merchantId))
            .ToList();

        var stopwatch = Stopwatch.StartNew();
        barrier.Release(requestCount);
        TestConnection[] results = await Task.WhenAll(tasks);
        stopwatch.Stop();

        return (results, stopwatch.Elapsed);
    }

    private static async Task<TestConnection> RunRequest(SemaphoreSlim barrier, IClient client, string merchantId)
    {
        await barrier.WaitAsync();

        return await client
            .WithClientMetaInfo("{}")
            .WithNewMerchant(merchantId)
            .Services
            .TestConnection();
    }
}
