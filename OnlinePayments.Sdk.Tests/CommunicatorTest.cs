using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class CommunicatorTest
    {
        const string BaseUriHost = "payment.preprod.online-payments.com";
        private readonly Uri _baseUri = new Uri("https://payment.preprod.online-payments.com");
        private readonly Mock<IConnection> _connectionMock = new Mock<IConnection>();
        private readonly Mock<IAuthenticator> _authenticatorMock = new Mock<IAuthenticator>();
        private readonly IMetadataProvider _metadataProvider = new MetadataProvider("OnlinePayments");
        private readonly Mock<IMarshaller> _marshallerMock = new Mock<IMarshaller>();

        // TODO: replace v1/merchant/20000/convertamount with a path as necessary

        [TestCase]
        public void TestToUriWithoutRequestParams()
        {
            var communicator = new Communicator(_baseUri, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider, _marshallerMock.Object);
            var uri = communicator.ToAbsoluteUri("v1/merchant/20000/convertamount", new List<RequestParam>());
            var uri2 = communicator.ToAbsoluteUri("/v1/merchant/20000/convertamount", new List<RequestParam>());

            Assert.That(uri, Is.EqualTo(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount")));
            Assert.That(uri2, Is.EqualTo(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount")));
        }

        [TestCase]
        public void TestToUriWithRequestParams()
        {
            var list = new List<RequestParam>
            {
                new RequestParam("amount", "123"),
                new RequestParam("source", "USD"),
                new RequestParam("target", "EUR"),
                new RequestParam("dummy", "é&%=")
            };
            var communicator = new Communicator(_baseUri, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider, _marshallerMock.Object);
            var uri = communicator.ToAbsoluteUri("v1/merchant/20000/convertamount", list);
            var uri2 = communicator.ToAbsoluteUri("/v1/merchant/20000/convertamount", list);

            Assert.AreEqual(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D"), uri);
            Assert.AreEqual(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D"), uri2);
        }
    }
}
