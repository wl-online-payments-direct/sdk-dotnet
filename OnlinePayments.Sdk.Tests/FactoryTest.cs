using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class FactoryTest
    {
        public static string ApiKeyId = "someKey";
        public static string SecretApiKey = "someSecret";
        public static IDictionary<string,string> Dict = new Dictionary<string, string> {
                {"onlinePayments.api.integrator", "OnlinePayments"},
                {"onlinePayments.api.endpoint.host", "payment.preprod.online-payments.com"},
                {"onlinePayments.api.authorizationType", "v1HMAC"},
                {"onlinePayments.api.socketTimeout", "-1"},
                {"onlinePayments.api.connectTimeout", "-1"},
                {"onlinePayments.api.maxConnections", "100"}
            };

        public static IClient CreateClient()
        {
            return Factory.CreateClient(Dict, ApiKeyId, SecretApiKey);
        }

        [TestCase]
        public void TestCreateConfiguration()
        {
            CommunicatorConfiguration configuration = Factory.CreateConfiguration(
                Dict, ApiKeyId, SecretApiKey);
            Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri("https://payment.preprod.online-payments.com")));
            Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
            Assert.That(configuration.ConnectTimeout, Is.Null);
            Assert.That(configuration.SocketTimeout?.TotalMilliseconds, Is.Null);
            Assert.That(configuration.MaxConnections, Is.EqualTo(100));
            Assert.That(configuration.ApiKeyId, Is.EqualTo(ApiKeyId));
            Assert.That(configuration.SecretApiKey, Is.EqualTo(SecretApiKey));
        }

        internal static object GetInstanceField(Type type, object instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static;
            FieldInfo field = type.GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }

        [TestCase]
        public void TestCreateCommunicator()
        {
            ICommunicator communicatorInterface = Factory.CreateCommunicator(Dict, ApiKeyId, SecretApiKey);

            Assert.That(communicatorInterface, Is.InstanceOf<Communicator>());
            Communicator communicator = (Communicator)communicatorInterface;
            Assert.That(communicator.Marshaller, Is.SameAs(DefaultMarshaller.Instance));

            IConnection connection = communicator.Connection;
            Assert.That(connection, Is.InstanceOf<DefaultConnection>());

            IAuthenticator authenticator = communicator.Authenticator;
            Assert.That(authenticator, Is.InstanceOf<V1HmacAuthenticator>());
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_authorizationType"), Is.EqualTo(AuthorizationType.V1HMAC));
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_apiKeyId"), Is.EqualTo(ApiKeyId));
            Assert.That(GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_secretApiKey"), Is.EqualTo(SecretApiKey));

            IMetadataProvider metaDataProvider = communicator.MetadataProvider;
            Assert.That(metaDataProvider.GetType(), Is.EqualTo(typeof(MetadataProvider)));
            IEnumerable<IRequestHeader> requestHeaders = metaDataProvider.ServerMetadataHeaders;
            Assert.That(requestHeaders.Count(), Is.EqualTo(1));
            IRequestHeader requestHeader = requestHeaders.ElementAt(0);
            Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
        }
    }
}
