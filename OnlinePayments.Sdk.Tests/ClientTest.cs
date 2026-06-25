using Moq;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Logging;
using OnlinePayments.Sdk.Merchant;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk;

[TestFixture]
public class ClientTest
{
    [TestCase]
    public void WithClientMetaInfo_WithVariousInputs_ReturnsCorrectClientInstances()
    {
        var clientFirst = FactoryTest.CreateClient();
        AssertNoClientHeaders(clientFirst);

        var clientSecond = clientFirst.WithClientMetaInfo(null);
        Assert.That(clientSecond, Is.SameAs(clientFirst));

        var clientMetaInfo = DefaultMarshaller.Instance.Marshal(new Dictionary<string, string> { { "test", "test" } });
        var clientThird = clientFirst.WithClientMetaInfo(clientMetaInfo);

        Assert.That(clientThird, Is.Not.SameAs(clientFirst));
        AssertClientHeaders(clientThird, clientMetaInfo);

        var clientForth = clientThird.WithClientMetaInfo(clientMetaInfo);
        Assert.That(clientForth, Is.SameAs(clientThird));

        var clientFifth = clientThird.WithClientMetaInfo(null);
        Assert.That(clientFifth, Is.Not.SameAs(clientThird));
        AssertNoClientHeaders(clientFifth);

        // nothing can be said about client1 and client5 being the same or not
    }

    private static void AssertClientHeaders(IClient client, string clientMetaInfo)
    {
        var headers = GetHeaders(client);

        var headerValue = clientMetaInfo.ToBase64String();

        Assert.That(headers.FirstOrDefault(v => v.Equals(new RequestHeader("X-GCS-ClientMetaInfo", headerValue))), Is.Not.Null);
    }

    private static void AssertNoClientHeaders(IClient client)
    {
        var headers = GetHeaders(client);

        Assert.That(headers, Is.Empty);
    }

    private static IEnumerable<RequestHeader> GetHeaders(IClient client)
    {
        // ApiResource.ClientHeaders is protected, so this test class has no access to it; use reflection to get it
        return client.GetPrivateProperty<IEnumerable<RequestHeader>>("ClientHeaders");
    }

    [TestCase]
    public void CloseIdleConnections_WhenNotPooled_IsNoOp()
    {
        // No-op because done automatically by system.
    }

    [TestCase]
    public void CloseIdleConnections_WhenPooled_IsNoOp()
    {
        // No-op because done automatically by system.
    }

    [TestCase]
    public void CloseExpiredConnections_WhenNotPooled_IsNoOp()
    {
        // No-op because done automatically by system.
    }

    [TestCase]
    public void CloseExpiredConnections_WhenPooled_IsNoOp()
    {
        // No-op because done automatically by system.
    }

    [Test]
    public void EnableLogging_WithValidLogger_DelegatesToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);
        Mock<ICommunicatorLogger> loggerMock = new();

        client.EnableLogging(loggerMock.Object);

        communicatorMock.Verify(c => c.EnableLogging(loggerMock.Object), Times.Once);
    }

    [Test]
    public void DisableLogging_WhenCalled_DelegatesToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);

        client.DisableLogging();

        communicatorMock.Verify(c => c.DisableLogging(), Times.Once);
    }

    [Test]
    public void EnableLoggingAndDisableLogging_MultipleTimes_DelegatesEachCallToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);
        Mock<ICommunicatorLogger> firstLoggerMock = new();
        Mock<ICommunicatorLogger> secondLoggerMock = new();

        client.EnableLogging(firstLoggerMock.Object);
        client.DisableLogging();
        client.EnableLogging(secondLoggerMock.Object);
        client.DisableLogging();

        communicatorMock.Verify(c => c.EnableLogging(firstLoggerMock.Object), Times.Once);
        communicatorMock.Verify(c => c.EnableLogging(secondLoggerMock.Object), Times.Once);
        communicatorMock.Verify(c => c.DisableLogging(), Times.Exactly(2));
    }

    [Test]
    public void SetBodyObfuscator_WithNullValue_DelegatesToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);
        BodyObfuscator capturedValue = BodyObfuscator.DefaultObfuscator;
        communicatorMock.SetupSet(c => c.BodyObfuscator = It.IsAny<BodyObfuscator>())
            .Callback<BodyObfuscator>(v => capturedValue = v);

        client.BodyObfuscator = null;

        Assert.That(capturedValue, Is.Null);
    }

    [Test]
    public void SetHeaderObfuscator_WithNullValue_DelegatesToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);
        HeaderObfuscator capturedValue = HeaderObfuscator.DefaultObfuscator;
        communicatorMock.SetupSet(c => c.HeaderObfuscator = It.IsAny<HeaderObfuscator>())
            .Callback<HeaderObfuscator>(v => capturedValue = v);

        client.HeaderObfuscator = null;

        Assert.That(capturedValue, Is.Null);
    }

    [Test]
    public void Dispose_WhenCalled_DelegatesToCommunicator()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);

        client.Dispose();

        communicatorMock.Verify(c => c.Dispose(), Times.Once);
    }

    [Test]
    public void Dispose_ViaUsingStatement_DoesNotThrow()
    {
        Mock<ICommunicator> communicatorMock = new();
        Assert.DoesNotThrow(() =>
        {
            using Client client = new(communicatorMock.Object);
        });
    }

    [Test]
    public void WithNewMerchant_WithValidMerchantId_ReturnsMerchantClientInstance()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);

        var merchantClient = client.WithNewMerchant("merchant-001");

        Assert.That(merchantClient, Is.Not.Null);
        Assert.That(merchantClient, Is.InstanceOf<IMerchantClient>());
    }

    [Test]
    public void WithNewMerchant_WithDifferentMerchantIds_ReturnsDifferentInstances()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);

        var firstMerchantClient = client.WithNewMerchant("merchant-1");
        var secondMerchantClient = client.WithNewMerchant("merchant-2");

        Assert.That(firstMerchantClient, Is.Not.SameAs(secondMerchantClient));
    }

    [Test]
    public void WithClientMetaInfo_WithEmptyString_CreatesNewInstance()
    {
        var client = FactoryTest.CreateClient();
        AssertNoClientHeaders(client);

        var newClient = client.WithClientMetaInfo("");

        Assert.That(newClient, Is.Not.SameAs(client));
    }

    [Test]
    public void WithNewMerchant_WithEmptyMerchantId_ReturnsMerchantClient()
    {
        Mock<ICommunicator> communicatorMock = new();
        Client client = new(communicatorMock.Object);

        var merchantClient = client.WithNewMerchant("");

        Assert.That(merchantClient, Is.Not.Null);
        Assert.That(merchantClient, Is.InstanceOf<IMerchantClient>());
    }
}
