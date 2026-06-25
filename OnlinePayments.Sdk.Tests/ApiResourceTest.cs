using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk;

[TestFixture]
public class ApiResourceTest
{
    private class TestApiResource : ApiResource
    {
        public TestApiResource(ICommunicator communicator, string clientMetaInfo, IDictionary<string, string> pathContext)
            : base(communicator, clientMetaInfo, pathContext)
        {
        }

        public TestApiResource(ApiResource parent, IDictionary<string, string> pathContext)
            : base(parent, pathContext)
        {
        }

        public new List<RequestHeader> ClientHeaders => base.ClientHeaders;

        public new string InstantiateUri(string uri, IDictionary<string, string> pathContext)
            => base.InstantiateUri(uri, pathContext);

        public ICommunicator ExposedCommunicator => _communicator;
        public string ExposedClientMetaInfo => _clientMetaInfo;
    }

    private static ICommunicator CreateCommunicator() => new Mock<ICommunicator>().Object;

    [TestFixture]
    public class WhenConstructingAsRoot
    {
        [Test]
        public void ShouldThrowWhenCommunicatorIsNull()
        {
            Assert.Throws<ArgumentException>(() => { _ = new TestApiResource(null, null, null); });
        }

        [Test]
        public void ShouldCreateInstanceWithValidCommunicator()
        {
            TestApiResource resource = new(CreateCommunicator(), null, null);

            Assert.That(resource, Is.Not.Null);
        }

        [Test]
        public void ShouldStoreClientMetaInfo()
        {
            TestApiResource resource = new(CreateCommunicator(), "meta-info", null);

            Assert.That(resource.ExposedClientMetaInfo, Is.EqualTo("meta-info"));
        }

        [Test]
        public void ShouldStoreNullClientMetaInfo()
        {
            TestApiResource resource = new(CreateCommunicator(), null, null);

            Assert.That(resource.ExposedClientMetaInfo, Is.Null);
        }

        [Test]
        public void ShouldStoreCommunicator()
        {
            var communicator = CreateCommunicator();
            TestApiResource resource = new(communicator, null, null);

            Assert.That(resource.ExposedCommunicator, Is.SameAs(communicator));
        }
    }

    [TestFixture]
    public class WhenConstructingWithParent
    {
        [Test]
        public void ShouldThrowWhenParentIsNull()
        {
            Assert.Throws<ArgumentException>(() => { _ = new TestApiResource(null, null); });
        }

        [Test]
        public void ShouldCreateInstanceWithParent()
        {
            TestApiResource parent = new(CreateCommunicator(), "meta-info", null);
            TestApiResource child = new(parent, null);

            Assert.That(child, Is.Not.Null);
        }

        [Test]
        public void ShouldAcceptNullPathContext()
        {
            TestApiResource parent = new(CreateCommunicator(), null, null);
            TestApiResource child = new(parent, null);

            Assert.That(child, Is.Not.Null);
        }

        [Test]
        public void ShouldInheritCommunicatorFromParent()
        {
            var communicator = CreateCommunicator();
            TestApiResource parent = new(communicator, null, null);
            TestApiResource child = new(parent, null);

            Assert.That(child.ExposedCommunicator, Is.SameAs(communicator));
        }

        [Test]
        public void ShouldInheritClientMetaInfoFromParent()
        {
            TestApiResource parent = new(CreateCommunicator(), "parent-meta", null);
            TestApiResource child = new(parent, null);

            Assert.That(child.ExposedClientMetaInfo, Is.EqualTo("parent-meta"));
        }
    }

    [TestFixture]
    public class WhenGettingClientHeaders
    {
        [Test]
        public void ShouldReturnEmptyListWhenClientMetaInfoIsNull()
        {
            TestApiResource resource = new(CreateCommunicator(), null, null);

            Assert.That(resource.ClientHeaders, Is.Empty);
        }

        [Test]
        public void ShouldReturnOneHeaderWhenClientMetaInfoIsSet()
        {
            TestApiResource resource = new(CreateCommunicator(), "base64-meta-info", null);

            Assert.That(resource.ClientHeaders.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldHaveCorrectHeaderName()
        {
            TestApiResource resource = new(CreateCommunicator(), "base64-meta-info", null);

            Assert.That(resource.ClientHeaders[0].Name, Is.EqualTo("X-GCS-ClientMetaInfo"));
        }

        [Test]
        public void ShouldHaveCorrectHeaderValue()
        {
            TestApiResource resource = new(CreateCommunicator(), "base64-meta-info", null);

            Assert.That(resource.ClientHeaders[0].Value, Is.EqualTo("base64-meta-info"));
        }

        [Test]
        public void ShouldReturnNewListEachCall()
        {
            TestApiResource resource = new(CreateCommunicator(), "meta", null);
            var headersFirst = resource.ClientHeaders;
            var headersSecond = resource.ClientHeaders;

            Assert.That(headersFirst, Is.Not.SameAs(headersSecond));
        }
    }

    [TestFixture]
    public class WhenInstantiatingUri
    {
        [Test]
        public void ShouldReplaceSinglePlaceholder()
        {
            Dictionary<string, string> pathContext = new() { { "merchantId", "merchant-123" } };
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/{merchantId}/payments", pathContext);

            Assert.That(result, Is.EqualTo("/v2/merchant-123/payments"));
        }

        [Test]
        public void ShouldReplaceMultiplePlaceholders()
        {
            Dictionary<string, string> pathContext = new() {
                { "merchantId", "merchant-123" },
                { "paymentId", "pay-456" }
            };

            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/{merchantId}/payments/{paymentId}", pathContext);

            Assert.That(result, Is.EqualTo("/v2/merchant-123/payments/pay-456"));
        }

        [Test]
        public void ShouldPreserveUnresolvedPlaceholders()
        {
            Dictionary<string, string> pathContext = new() { { "merchantId", "merchant-123" } };
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/{merchantId}/payments/{paymentId}", pathContext);

            Assert.That(result, Is.EqualTo("/v2/merchant-123/payments/{paymentId}"));
        }

        [Test]
        public void ShouldHandleNullPathContext()
        {
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/{merchantId}/payments", null);

            Assert.That(result, Is.EqualTo("/v2/{merchantId}/payments"));
        }

        [Test]
        public void ShouldResolveParentPathContext()
        {
            Dictionary<string, string> parentPathContext = new() { { "merchantId", "merchant-123" } };
            TestApiResource parent = new(CreateCommunicator(), null, parentPathContext);
            TestApiResource child = new(parent, null);
            var result = child.InstantiateUri("/v2/{merchantId}/payments", null);

            Assert.That(result, Is.EqualTo("/v2/merchant-123/payments"));
        }

        [Test]
        public void ShouldResolveChildBeforeParentPathContext()
        {
            Dictionary<string, string> parentPathContext = new() { { "merchantId", "merchant-123" } };
            Dictionary<string, string> childPathContext = new() { { "paymentId", "pay-456" } };
            TestApiResource parent = new(CreateCommunicator(), null, parentPathContext);
            TestApiResource child = new(parent, null);
            var result = child.InstantiateUri("/v2/{merchantId}/payments/{paymentId}", childPathContext);

            Assert.That(result, Is.EqualTo("/v2/merchant-123/payments/pay-456"));
        }

        [Test]
        public void ShouldPreserveUriWithoutPlaceholders()
        {
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/payments", null);

            Assert.That(result, Is.EqualTo("/v2/payments"));
        }

        [Test]
        public void ShouldReplaceAllOccurrencesOfPlaceholder()
        {
            Dictionary<string, string> pathContext = new() { { "id", "999" } };
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/{id}/nested/{id}/deep", pathContext);

            Assert.That(result, Is.EqualTo("/999/nested/999/deep"));
        }

        [Test]
        public void ShouldPreservePlaceholdersWhenPathContextIsEmpty()
        {
            TestApiResource resource = new(CreateCommunicator(), null, new Dictionary<string, string>());
            var result = resource.InstantiateUri("/v2/{merchantId}/payments", null);

            Assert.That(result, Is.EqualTo("/v2/{merchantId}/payments"));
        }

        [Test]
        public void ShouldHandleSpecialCharactersInValues()
        {
            Dictionary<string, string> pathContext = new() { { "merchantId", "abc-123-def" } };
            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v2/{merchantId}/payments", pathContext);

            Assert.That(result, Is.EqualTo("/v2/abc-123-def/payments"));
        }

        [Test]
        public void ShouldHandleNumericValues()
        {
            Dictionary<string, string> pathContext = new() {
                { "version", "2" },
                { "merchantId", "12345" }
            };

            TestApiResource resource = new(CreateCommunicator(), null, null);
            var result = resource.InstantiateUri("/v{version}/{merchantId}/payments", pathContext);

            Assert.That(result, Is.EqualTo("/v2/12345/payments"));
        }
    }
}
