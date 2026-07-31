using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OnlinePayments.Sdk.It.Helpers;

namespace OnlinePayments.Sdk.It;

public abstract class IntegrationTest
{
    private const string HttpClientName = "OnlinePayments.Sdk.IntegrationTests";

    // Built once for the whole test run, mirroring how IHttpClientFactory is
    // meant to be used in a real app: registered once, resolved many times.
    private static readonly ServiceProvider ServiceProvider = BuildServiceProvider();
    private static readonly IHttpClientFactory HttpClientFactory =
        ServiceProvider.GetRequiredService<IHttpClientFactory>();

    private readonly string _merchantId = Environment.GetEnvironmentVariable("onlinePayments_api_merchantId");
    private readonly string _apiKeyId = Environment.GetEnvironmentVariable("onlinePayments_api_apiKeyId");
    private readonly string _secretApiKey = Environment.GetEnvironmentVariable("onlinePayments_api_secretApiKey");

    protected IClient Client { get; private set; }

    [SetUp]
    public void SetUp()
    {
        Client = SetUpClient();
    }

    [TearDown]
    public void TearDown() => Client?.Dispose();

    protected string GetMerchantId()
    {
        return string.IsNullOrEmpty(_merchantId)
            ? throw new InvalidOperationException("Environment variable onlinePayments_api_merchantId must be set.")
            : _merchantId;
    }

    protected SdkTestHelper GetSdkTestHelper()
    {
        return new SdkTestHelper(Client.WithNewMerchant(GetMerchantId()));
    }

    protected CommunicatorConfiguration GetCommunicatorConfiguration()
    {
        return Factory
            .CreateConfiguration(_apiKeyId, _secretApiKey)
            .WithHttpClientFactory(HttpClientFactory, HttpClientName);
    }

    private IClient SetUpClient()
    {
        if (string.IsNullOrEmpty(_apiKeyId) || string.IsNullOrEmpty(_secretApiKey))
        {
            throw new InvalidOperationException(
                "Environment variables onlinePayments_api_apiKeyId and onlinePayments_api_secretApiKey must be set.");
        }

        return Factory.CreateClient(GetCommunicatorConfiguration())
            .WithClientMetaInfo("{\"test\":\"test\"}");
    }

    private static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddHttpClient(HttpClientName, httpClient =>
            {
                // Define the custom timeout value
                httpClient.Timeout = TimeSpan.FromSeconds(30);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                // Define the custom pooled connection lifetime value
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            });

        return services.BuildServiceProvider();
    }

    internal static void DisposeServiceProvider() => ServiceProvider.Dispose();
}
