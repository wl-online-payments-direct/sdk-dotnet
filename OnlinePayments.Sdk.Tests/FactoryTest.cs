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
            Assert.AreEqual(new Uri("https://payment.preprod.online-payments.com"), configuration.ApiEndpoint);
            Assert.AreEqual(AuthorizationType.V1HMAC, configuration.AuthorizationType);
            Assert.AreEqual(null, configuration.ConnectTimeout);
            Assert.AreEqual(null, configuration.SocketTimeout?.TotalMilliseconds);
            Assert.AreEqual(100, configuration.MaxConnections);
            Assert.AreEqual(ApiKeyId, configuration.ApiKeyId);
            Assert.AreEqual(SecretApiKey, configuration.SecretApiKey);
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

            Assert.IsInstanceOf<Communicator>(communicatorInterface);
            Communicator communicator = (Communicator)communicatorInterface;
            Assert.AreSame(DefaultMarshaller.Instance, communicator.Marshaller);

            IConnection connection = communicator.Connection;
            Assert.True(connection is DefaultConnection);

            IAuthenticator authenticator = communicator.Authenticator;
            Assert.True(authenticator is V1HmacAuthenticator);
            Assert.AreEqual(AuthorizationType.V1HMAC, GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_authorizationType"));
            Assert.AreEqual(ApiKeyId, GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_apiKeyId"));
            Assert.AreEqual(SecretApiKey, GetInstanceField(typeof(V1HmacAuthenticator), authenticator, "_secretApiKey"));

            IMetadataProvider metaDataProvider = communicator.MetadataProvider;
            Assert.AreEqual(typeof(MetadataProvider), metaDataProvider.GetType());
            IEnumerable<IRequestHeader> requestHeaders = metaDataProvider.ServerMetadataHeaders;
            Assert.AreEqual(1, requestHeaders.Count());
            IRequestHeader requestHeader = requestHeaders.ElementAt(0);
            Assert.AreEqual("X-GCS-ServerMetaInfo", requestHeader.Name);
        }
    }
}
