using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OnlinePayments.Sdk.Json;
using static System.Linq.Enumerable;

namespace OnlinePayments.Sdk.Communication
{
    [TestFixture]
    public class MetadataProviderTest
    {
        [TestCase]
        public void TestGetServerMetadataHeadersNoAdditionalHeaders()
        {
            var metadataProvider = new MetadataProvider("OnlinePayments");

            var requestHeaders = metadataProvider.ServerMetadataHeaders;
            Assert.That(requestHeaders.Count(), Is.EqualTo(1));

            var requestHeader = requestHeaders.First();
            AssertServerMetaInfo(metadataProvider, requestHeader);
        }

        [TestCase]
        public void TestGetServerMetadataHeadersWithAdditionalHeaders()
        {
            var additionalHeaders = new List<RequestHeader>
            {
                new RequestHeader("Header1", "Value1"),
                new RequestHeader("Header2", "Value2"),
                new RequestHeader("Header3", "Value3")
            };

            var metadataProvider = new MetadataProviderBuilder("OnlinePayments") { AdditionalRequestHeaders = additionalHeaders }.Build();

            var requestHeaders = metadataProvider.ServerMetadataHeaders;
            Assert.That(requestHeaders.Count(), Is.EqualTo(4));
            var requestHeader = requestHeaders.First();
            AssertServerMetaInfo(metadataProvider, requestHeader);

            using (var enumerator = requestHeaders.GetEnumerator())
            {
                enumerator.MoveNext();
                foreach (var additionalHeader in additionalHeaders)
                {
                    Assert.That(enumerator.MoveNext(), Is.True);
                    requestHeader = enumerator.Current;
                    Assert.That(additionalHeader, Is.EqualTo(requestHeader));
                }
            }
        }

        [TestCase]
        public void TestConstructorWithProhibitedHeaders()
        {
            foreach (var name in MetadataProvider.ProhibitedHeaders)
            {
                var headers = new List<RequestHeader>
                {
                    new RequestHeader("Header1", "Value1"),
                    new RequestHeader(name, "whatever"),
                    new RequestHeader("Header2", "Value2")
                };

                Assert.That(() => new MetadataProviderBuilder("OnlinePayments") { AdditionalRequestHeaders = headers }.Build(), Throws.ArgumentException.With.Message.Contain(name));
            }
        }

        private static void AssertServerMetaInfo(MetadataProvider metadataProvider, IRequestHeader requestHeader)
        {
            Assert.That(requestHeader.Name, Is.EqualTo("X-GCS-ServerMetaInfo"));
            Assert.That(requestHeader.Value, Is.Not.Null);

            var data = Convert.FromBase64String(requestHeader.Value);
            var serverMetaInfoJson = Encoding.UTF8.GetString(data);

            var serverMetaInfo = DefaultMarshaller.Instance.Unmarshal<MetadataProvider.ServerMetaInfo>(serverMetaInfoJson);
            Assert.That(serverMetaInfo.SdkIdentifier, Is.EqualTo(metadataProvider.SdkIdentifier));
            Assert.That(serverMetaInfo.SdkCreator, Is.EqualTo("OnlinePayments"));
            Assert.That(serverMetaInfo.PlatformIdentifier, Is.EqualTo(metadataProvider.PlatformIdentifier));
        }
    }
}
