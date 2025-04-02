using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePayments.Sdk.Communication
{
    [TestFixture]
    public class MetadataProviderBuilderTest
    {
        [TestCase]
        public void TestWithAdditionalRequestHeader()
        {
            foreach (var a in Parameters)
            {
                CheckWithAdditionalRequestHeader(a.Item1, a.Item2);
            }
        }

        private static void CheckWithAdditionalRequestHeader(string additionalHeaderName, bool isAllowed)
        {
            var additionalRequestHeader = new RequestHeader(additionalHeaderName, Guid.NewGuid().ToString());

            var builder = new MetadataProviderBuilder("OnlinePayments");
            if (isAllowed)
            {
                var metadataProvider = builder.WithAdditionalRequestHeader(additionalRequestHeader).Build();
                var requestHeaders = metadataProvider.ServerMetadataHeaders;
                Assert.AreEqual(2, requestHeaders.Count());

                var requestHeader = requestHeaders.First();
                Assert.AreEqual("X-GCS-ServerMetaInfo", requestHeader.Name);

                requestHeader = requestHeaders.Skip(1).First();
                Assert.AreEqual(requestHeader, additionalRequestHeader);
            }
            else {
                Assert.That(() => builder.WithAdditionalRequestHeader(additionalRequestHeader), Throws.ArgumentException.With.Message.Contains(additionalHeaderName));
            }
        }

        private static IEnumerable<Tuple<string, bool>> Parameters
        {
            get
            {
                foreach (var prohibitedHeaders in MetadataProvider.ProhibitedHeaders)
                {
                    yield return Tuple.Create(prohibitedHeaders, false);
                }
                yield return Tuple.Create("Dummy", true);
                yield return Tuple.Create("Accept", true);
                yield return Tuple.Create("If-None-Match", true);
                yield return Tuple.Create("If-Modified-Since", true);
            }
        }
    }
}
