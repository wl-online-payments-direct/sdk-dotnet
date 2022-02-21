using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using OnlinePayments.Sdk.DefaultImpl;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class FactoryTest
    {
        public static string API_KEY_ID = "someKey";
        public static string SECRET_API_KEY = "someSecret";
        public static IDictionary<string,string> DICT = new Dictionary<string, string> {
                {"onlinePayments.api.integrator", "OnlinePayments"},
                {"onlinePayments.api.endpoint.host", "payment.preprod.online-payments.com"},
                {"onlinePayments.api.authorizationType", "v1HMAC"},
                {"onlinePayments.api.socketTimeout", "-1"},
                {"onlinePayments.api.connectTimeout", "-1"},
                {"onlinePayments.api.maxConnections", "100"}
            };

        [TestCase]
        public void TestCreateConfiguration()
        {
            CommunicatorConfiguration configuration = Factory.CreateConfiguration(
                DICT, API_KEY_ID, SECRET_API_KEY);
            Assert.AreEqual(new Uri("https://payment.preprod.online-payments.com"), configuration.ApiEndpoint);
            Assert.AreEqual(AuthorizationType.V1HMAC, configuration.AuthorizationType);
            Assert.AreEqual(-1, configuration.ConnectTimeout?.TotalMilliseconds);
            Assert.AreEqual(-1, configuration.SocketTimeout?.TotalMilliseconds);
            Assert.AreEqual(100, configuration.MaxConnections);
            Assert.AreEqual(API_KEY_ID, configuration.ApiKeyId);
            Assert.AreEqual(SECRET_API_KEY, configuration.SecretApiKey);
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
            ICommunicator communicatorInterface = Factory.CreateCommunicator(DICT, API_KEY_ID, SECRET_API_KEY);

            Assert.IsInstanceOf<Communicator>(communicatorInterface);
            Communicator communicator = (Communicator)communicatorInterface;
            Assert.AreSame(DefaultMarshaller.Instance, communicator.Marshaller);

            IConnection connection = communicator.Connection;
            Assert.True(connection is DefaultConnection);

            IAuthenticator authenticator = communicator.Authenticator;
            Assert.True(authenticator is DefaultAuthenticator);
            Assert.AreEqual(AuthorizationType.V1HMAC, GetInstanceField(typeof(DefaultAuthenticator), authenticator, "_authorizationType"));
            Assert.AreEqual(API_KEY_ID, GetInstanceField(typeof(DefaultAuthenticator), authenticator, "_apiKeyId"));
            Assert.AreEqual(SECRET_API_KEY, GetInstanceField(typeof(DefaultAuthenticator), authenticator, "_secretApiKey"));

            MetaDataProvider metaDataProvider = communicator.MetaDataProvider;
            Assert.AreEqual(typeof(MetaDataProvider), metaDataProvider.GetType());
            IEnumerable<RequestHeader> requestHeaders = metaDataProvider.ServerMetaDataHeaders;
            Assert.AreEqual(1, requestHeaders.Count());
            RequestHeader requestHeader = requestHeaders.ElementAt(0);
            Assert.AreEqual("X-GCS-ServerMetaInfo", requestHeader.Name);
        }
    }
}
