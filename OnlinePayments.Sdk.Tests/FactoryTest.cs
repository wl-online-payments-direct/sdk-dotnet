using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk;

[TestFixture]
public class FactoryTest
{
    private const string ApiKeyId = "someKey";
    private const string SecretApiKey = "someSecret";

    private static readonly IDictionary<string, string> ConfigurationProperties = new Dictionary<string, string>
    {
        { "onlinePayments.api.integrator", "OnlinePayments" },
        { "onlinePayments.api.endpoint.host", "payment.preprod.online-payments.com" },
        { "onlinePayments.api.authorizationType", "v1HMAC" },
        { "onlinePayments.api.socketTimeout", "-1" },
        { "onlinePayments.api.connectTimeout", "-1" },
        { "onlinePayments.api.maxConnections", "100" }
    };

    public static IClient CreateClient()
    {
        return Factory.CreateClient(ConfigurationProperties, ApiKeyId, SecretApiKey);
    }

    private static object GetInstanceField(Type type, object instance, string fieldName)
    {
        const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        FieldInfo field = type.GetField(fieldName, bindFlags)
                          ?? throw new ArgumentException($"Field '{fieldName}' not found on type '{type.FullName}'.");

        return field.GetValue(instance);
    }

    [TestFixture]
    public class WhenCreateConfigurationIsCalled
    {
        [TestFixture]
        public class WithValidDictionary
        {
            [Test]
            public void CreateConfiguration_WithValidDictionary_ReturnsExpectedConfiguration()
            {
                var configuration = Factory.CreateConfiguration(ConfigurationProperties, ApiKeyId, SecretApiKey);

                Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri("https://payment.preprod.online-payments.com")));
                Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
                Assert.That(configuration.ConnectTimeout, Is.Null);
                Assert.That(configuration.SocketTimeout, Is.Null);
                Assert.That(configuration.MaxConnections, Is.EqualTo(100));
                Assert.That(configuration.ApiKeyId, Is.EqualTo(ApiKeyId));
                Assert.That(configuration.SecretApiKey, Is.EqualTo(SecretApiKey));
                Assert.That(configuration.Proxy, Is.Null);
            }
        }

        [TestFixture]
        public class WithInvalidDictionary
        {
            private static readonly IDictionary<string, string> InvalidConfigurationProperties = new Dictionary<string, string>
            {
                { "onlinePayments.api.integrator", "OnlinePayments" },
                { "onlinePayments.api.endpoint.host", "payment.preprod.online-payments.com" },
                { "onlinePayments.api.endpoint.port", "99999" },
                { "onlinePayments.api.authorizationType", "v1HMAC" }
            };

            [Test]
            public void CreateConfiguration_WithInvalidEndpointPort_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() =>
                    Factory.CreateConfiguration(InvalidConfigurationProperties, ApiKeyId, SecretApiKey));
            }
        }
    }

    [TestFixture]
    public class WhenCreateCommunicatorBuilderIsCalled
    {
        [Test]
        public void CreateCommunicatorBuilder_WithValidDictionary_ReturnsBuilderWithExpectedConfiguration()
        {
            var builder = Factory.CreateCommunicatorBuilder(ConfigurationProperties, ApiKeyId, SecretApiKey);

            Assert.That(builder, Is.Not.Null);

            var apiEndpoint = (Uri)GetInstanceField(typeof(CommunicatorBuilder), builder, "_apiEndpoint");
            Assert.That(apiEndpoint, Is.EqualTo(new Uri("https://payment.preprod.online-payments.com")));

            var connection = (IConnection)GetInstanceField(typeof(CommunicatorBuilder), builder, "_connection");
            Assert.That(connection, Is.InstanceOf<DefaultConnection>());

            var metadataProvider = (IMetadataProvider)GetInstanceField(typeof(CommunicatorBuilder), builder, "_metadataProvider");
            Assert.That(metadataProvider.GetType(), Is.EqualTo(typeof(MetadataProvider)));

            var authenticator = (IAuthenticator)GetInstanceField(typeof(CommunicatorBuilder), builder, "_authenticator");
            Assert.That(authenticator, Is.InstanceOf<V1HmacAuthenticator>());

            var marshaller = (IMarshaller)GetInstanceField(typeof(CommunicatorBuilder), builder, "_marshaller");
            Assert.That(marshaller, Is.SameAs(DefaultMarshaller.Instance));
        }

        [Test]
        public void CreateCommunicatorBuilder_WithUnsupportedAuthorizationType_ThrowsInvalidOperationException()
        {
            var configuration = new CommunicatorConfiguration()
                .WithApiEndpoint(new Uri("https://payment.example.com"))
                .WithAuthorizationType(null)
                .WithConnectTimeout(1000)
                .WithSocketTimeout(1000)
                .WithMaxConnections(100)
                .WithApiKeyId(ApiKeyId)
                .WithSecretApiKey(SecretApiKey)
                .WithIntegrator("test-integrator");

            Assert.Throws<InvalidOperationException>(() => Factory.CreateCommunicatorBuilder(configuration));
        }
    }

    [TestFixture]
    public class WhenCreateCommunicatorIsCalled
    {
        [Test]
        public void CreateCommunicator_WithValidDictionary_ReturnsExpectedCommunicator()
        {
            var communicatorInterface = Factory.CreateCommunicator(ConfigurationProperties, ApiKeyId, SecretApiKey);

            Assert.That(communicatorInterface, Is.InstanceOf<Communicator>());
            var communicator = (Communicator)communicatorInterface;
            Assert.That(communicator.Marshaller, Is.SameAs(DefaultMarshaller.Instance));

            Assert.That(communicator.Connection, Is.InstanceOf<DefaultConnection>());

            var authenticator = communicator.Authenticator;
            Assert.That(authenticator, Is.InstanceOf<V1HmacAuthenticator>());
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_authorizationType"), Is.EqualTo(AuthorizationType.V1HMAC));
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_apiKeyId"), Is.EqualTo(ApiKeyId));
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_secretApiKey"), Is.EqualTo(SecretApiKey));

            var metadataProvider = communicator.MetadataProvider;
            Assert.That(metadataProvider.GetType(), Is.EqualTo(typeof(MetadataProvider)));
            var requestHeaders = metadataProvider.ServerMetadataHeaders.ToList();
            Assert.That(requestHeaders.Count, Is.EqualTo(1));
            Assert.That(requestHeaders[0].Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        }

    }

    [TestFixture]
    public class WhenCreateCommunicatorWithDirectParametersIsCalled
    {
        [Test]
        public void CreateCommunicator_WithDirectParameters_ReturnsCommunicatorWithProvidedComponents()
        {
            Uri apiEndpoint = new("https://payment.example.com");
            Mock<IConnection> connectionMock = new();
            Mock<IAuthenticator> authenticatorMock = new();
            Mock<IMetadataProvider> metadataProviderMock = new();

            var communicator = (Communicator)Factory.CreateCommunicator(
                apiEndpoint, connectionMock.Object, authenticatorMock.Object, metadataProviderMock.Object);

            Assert.That(communicator, Is.Not.Null);
            Assert.That(communicator.Marshaller, Is.SameAs(DefaultMarshaller.Instance));
            Assert.That(communicator.Connection, Is.SameAs(connectionMock.Object));
            Assert.That(communicator.Authenticator, Is.SameAs(authenticatorMock.Object));
            Assert.That(communicator.MetadataProvider, Is.SameAs(metadataProviderMock.Object));
        }
    }

    [TestFixture]
    public class WhenCreateClientIsCalled
    {
        [Test]
        public void CreateClient_WithValidDictionary_ReturnsClientInstance()
        {
            var client = Factory.CreateClient(ConfigurationProperties, ApiKeyId, SecretApiKey);

            Assert.That(client, Is.Not.Null);
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        public void CreateClient_WithConfiguration_ReturnsClientInstance()
        {
            var configuration = Factory.CreateConfiguration(ConfigurationProperties, ApiKeyId, SecretApiKey);

            var client = Factory.CreateClient(configuration);

            Assert.That(client, Is.Not.Null);
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        public void CreateClient_WithDirectParameters_ReturnsClientInstance()
        {
            Uri apiEndpoint = new("https://payment.example.com");
            Mock<IConnection> connectionMock = new();
            Mock<IAuthenticator> authenticatorMock = new();
            Mock<IMetadataProvider> metadataProviderMock = new();

            var client = Factory.CreateClient(
                apiEndpoint, connectionMock.Object, authenticatorMock.Object, metadataProviderMock.Object);

            Assert.That(client, Is.Not.Null);
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        public void CreateClient_WithCommunicator_ReturnsClientInstance()
        {
            Mock<ICommunicator> communicatorMock = new();

            var client = Factory.CreateClient(communicatorMock.Object);

            Assert.That(client, Is.Not.Null);
            Assert.That(client, Is.InstanceOf<Client>());
        }
    }
}
