using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class ClientTest
    {
        [TestCase]
        public void TestWithClientMetaInfo()
        {
            var client1 = FactoryTest.CreateClient();
            AssertNoClientHeaders(client1);

            var client2 = client1.WithClientMetaInfo(null);
            Assert.AreSame(client1, client2);

            var clientMetaInfo = DefaultMarshaller.Instance.Marshal(new Dictionary<string, string> { { "test", "test" } });
            var client3 = client1.WithClientMetaInfo(clientMetaInfo);

            Assert.AreNotSame(client1, client3);
            AssertClientHeaders(client3, clientMetaInfo);

            var client4 = client3.WithClientMetaInfo(clientMetaInfo);
            Assert.AreSame(client3, client4);

            var client5 = client3.WithClientMetaInfo(null);
            Assert.AreNotSame(client3, client5);
            AssertNoClientHeaders(client5);

            // nothing can be said about client1 and client5 being the same or not
        }

        private static void AssertClientHeaders(IClient client, string clientMetaInfo)
        {
            var headers = GetHeaders(client);

            var headerValue = clientMetaInfo.ToBase64String();

            Assert.NotNull(headers.FirstOrDefault(v => v.Equals(new RequestHeader("X-GCS-ClientMetaInfo", headerValue))));
        }

        private static void AssertNoClientHeaders(IClient client)
        {
            var headers = GetHeaders(client);
            Assert.IsEmpty(headers);
        }

        private static IEnumerable<RequestHeader> GetHeaders(IClient client)
        {
            // ApiResource.ClientHeaders is protected, so this test class has no access to it; use reflection to get it
            return client.GetPrivateProperty<IEnumerable<RequestHeader>>("ClientHeaders");
        }

        [TestCase]
        public void TestCloseIdleConnectionsNotPooled()
        {
            // No-op because done automatically by system.
        }

        [TestCase]
        public void TestCloseIdleConnectionsPooled()
        {
            // No-op because done automatically by system.
        }

        [TestCase]
        public void TestCloseExpiredConnectionsNotPooled()
        {
            // No-op because done automatically by system.
        }

        [TestCase]
        public void TestCloseExpiredConnectionsPooled()
        {
            // No-op because done automatically by system.
        }
    }
}
