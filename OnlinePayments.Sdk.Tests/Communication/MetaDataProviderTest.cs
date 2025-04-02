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
            Assert.AreEqual(1, requestHeaders.Count());

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
            Assert.AreEqual(4, requestHeaders.Count());
            var requestHeader = requestHeaders.First();
            AssertServerMetaInfo(metadataProvider, requestHeader);

            using (var enumerator = requestHeaders.GetEnumerator())
            {
                enumerator.MoveNext();
                foreach (var additionalHeader in additionalHeaders)
                {
                    Assert.True(enumerator.MoveNext());
                    requestHeader = enumerator.Current;
                    Assert.AreEqual(requestHeader, additionalHeader);
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
            Assert.AreEqual(requestHeader.Name, "X-GCS-ServerMetaInfo");
            Assert.NotNull(requestHeader.Value);

            var data = Convert.FromBase64String(requestHeader.Value);
            var serverMetaInfoJson = Encoding.UTF8.GetString(data);

            var serverMetaInfo = DefaultMarshaller.Instance.Unmarshal<MetadataProvider.ServerMetaInfo>(serverMetaInfoJson);
            Assert.AreEqual(metadataProvider.SdkIdentifier, serverMetaInfo.SdkIdentifier);
            Assert.AreEqual("OnlinePayments", serverMetaInfo.SdkCreator);
            Assert.AreEqual(metadataProvider.PlatformIdentifier, serverMetaInfo.PlatformIdentifier);
        }
    }
}
