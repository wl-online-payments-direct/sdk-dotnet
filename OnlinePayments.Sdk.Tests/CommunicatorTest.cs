using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class CommunicatorTest
    {
        const string BaseUriString = "https://payment.preprod.online-payments.com";
        private const string ConvertAmountPath = "v2/merchant/20000/convertamount";
        readonly Uri baseUri = new Uri(BaseUriString);
        readonly Mock<IConnection> connectionMock = new Mock<IConnection>();
        readonly Mock<IAuthenticator> authenticatorMock = new Mock<IAuthenticator>();
        readonly Mock<MetaDataProvider> metaDataProviderMock = new Mock<MetaDataProvider>();

        [TestCase]
        public void TestToURIWithoutRequestParams()
        {
            Communicator communicator =
                new Communicator(baseUri, connectionMock.Object, authenticatorMock.Object, metaDataProviderMock.Object, DefaultImpl.DefaultMarshaller.Instance);
            Uri uri = communicator.ToAbsoluteURI(ConvertAmountPath, new List<RequestParam>());
            Uri uri2 = communicator.ToAbsoluteURI($"/{ConvertAmountPath}", new List<RequestParam>());

            Assert.That(uri, Is.EqualTo(new Uri($"{BaseUriString}/{ConvertAmountPath}")));
            Assert.That(uri2, Is.EqualTo(new Uri($"{BaseUriString}/{ConvertAmountPath}")));
        }

        [TestCase]
        public void TestToURIWithRequestParams()
        {
            IList<RequestParam> list = new List<RequestParam>
            {
                new RequestParam("amount", "123"),
                new RequestParam("source", "USD"),
                new RequestParam("target", "EUR"),
                new RequestParam("dummy", "é&%=")
            };

            Communicator communicator =
                new Communicator(baseUri, connectionMock.Object, authenticatorMock.Object, metaDataProviderMock.Object, DefaultImpl.DefaultMarshaller.Instance);
            Uri uri = communicator.ToAbsoluteURI(ConvertAmountPath, list);
            Uri uri2 = communicator.ToAbsoluteURI($"/{ConvertAmountPath}", list);

            Assert.AreEqual(new Uri($"{BaseUriString}/{ConvertAmountPath}?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D"), uri);
            Assert.AreEqual(new Uri($"{BaseUriString}/{ConvertAmountPath}?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D"), uri2);
        }
    }
}
