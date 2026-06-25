using System;
using NUnit.Framework;
using OnlinePayments.Sdk.It.Helpers;

namespace OnlinePayments.Sdk.It;

public abstract class IntegrationTest
{
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
        return Factory.CreateConfiguration(_apiKeyId, _secretApiKey);
    }

    private IClient SetUpClient()
    {
        if (string.IsNullOrEmpty(_apiKeyId) || string.IsNullOrEmpty(_secretApiKey))
        {
            throw new InvalidOperationException(
                "Environment variables onlinePayments_api_apiKeyId and onlinePayments_api_secretApiKey must be set.");
        }

        return Factory.CreateClient(_apiKeyId, _secretApiKey).WithClientMetaInfo("{\"test\":\"test\"}");
    }
}
