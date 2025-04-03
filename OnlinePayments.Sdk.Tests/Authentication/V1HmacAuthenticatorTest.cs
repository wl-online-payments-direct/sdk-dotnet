using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Authentication
{
    [TestFixture]
    public class V1HmacAuthenticatorTest
    {

        [TestCase]
        public void TestToCanonicalizeHeaderValue()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
            Assert.AreEqual("aap noot", authenticator.ToCanonicalizeHeaderValue("aap\nnoot  "));
            Assert.AreEqual("aap noot", authenticator.ToCanonicalizeHeaderValue(" aap\r\n  noot"));
        }

        [TestCase]
        public void TestToCanonicalizeHeaderValue2()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
            var val1 = authenticator.ToCanonicalizeHeaderValue(" some value  \r\n \n with  some \r\n  spaces ");
            Assert.AreEqual("some value    with  some  spaces", val1);
        }

        [TestCase]
        public void TestToDataToSign()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}"));
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "{\"aap\",\"noot\"}"));
            httpHeaders.Add(new RequestHeader("User-Agent", "Apache-HttpClient/4.3.4 (java 1.5)"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));
            string dataToSign = authenticator.ToDataToSign(HttpMethod.Post, new Uri("http://localhost:8080/v2/9991/services%20bla/convert/amount?aap=noot&mies=geen%20noot"), httpHeaders);

            string expectedStart =
                "POST\napplication/json\n";
            string expectedEnd =
                "x-gcs-clientmetainfo:{\"aap\",\"noot\"}\nx-gcs-servermetainfo:{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}\n/v2/9991/services%20bla/convert/amount?aap=noot&mies=geen noot\n";

            string actualStart = dataToSign.Substring(0, 22);
            string actualEnd = dataToSign.Substring(52, dataToSign.Length-52);

            Assert.AreEqual(expectedStart, actualStart);
            Assert.AreEqual(expectedEnd, actualEnd);
        }

        [TestCase]
        public void TestCreateAuthenticationSignature()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");

            string dataToSign = "DELETE\napplication/json\nFri, 06 Jun 2014 13:39:43 GMT\nx-gcs-clientmetainfo:processed header value\nx-gcs-customerheader:processed header value\nx-gcs-servermetainfo:processed header value\n/v2/9991/tokens/123456789\n";

            string authenticationSignature = authenticator.SignData(dataToSign);

            Assert.AreEqual("eyLWp/Fa20rXs8UHlhD/13ZuqZkAVMJh9Z71n9TrFxM=", authenticationSignature);
        }

        [TestCase]
        public void TestCreateAuthenticationSignature2()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "EC36A74A98D21", "6Kj5HT0MQKC6D8eb7W3lTg71kVKVDSt1");

            string dataToSign = "GET\n\nFri, 06 Jun 2014 13:39:43 GMT\n/v2/9991/tokens/123456789\n";

            string authenticationSignature = authenticator.SignData(dataToSign);

            Assert.AreEqual("Y3E5YaU3oQCt4osEotLGb9W0cMclIzlCpvbaD1KhWxE=", authenticationSignature);
        }

        [TestCase]
        public async Task TestTotalMinimalExample()
        {
            var authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "5e45c937b9db33ae", "I42Zf4pVnRdroHfuHnRiJjJ2B6+22h0yQt/R3nZR8Xg=");
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("User-Agent", "Apache-HttpClient/4.3.4 (java 1.5)"));
            httpHeaders.Add(new RequestHeader("Date", "Fri, 06 Jun 2014 13:39:43 GMT"));
            string signature = await authenticator.GetAuthorization(HttpMethod.Get, new Uri("https://payment.preprod.online-payments.com/v2/1/tokens/123456789"), httpHeaders);
            Assert.AreEqual("GCS v1HMAC:5e45c937b9db33ae:UpOoo/pmmj7tW03IbEcw2WtJURFCKL2/J6hqMc+1h1I=", signature);
        }

        [TestCase]
        public async Task TestTotalFullExample()
        {
            var authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "5e45c937b9db33ae", "I42Zf4pVnRdroHfuHnRiJjJ2B6+22h0yQt/R3nZR8Xg=");
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("User-Agent", "Apache-HttpClient/4.3.4 (java 1.5)"));
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "processed header value"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "processed header value"));
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("X-GCS-CustomerHeader", "processed header value"));
            httpHeaders.Add(new RequestHeader("Date", "Fri, 06 Jun 2014 13:39:43 GMT"));
            string signature = await authenticator.GetAuthorization(HttpMethod.Delete, new Uri("https://payment.preprod.online-payments.com/v2/1/tokens/123456789"), httpHeaders);
            Assert.AreEqual("GCS v1HMAC:5e45c937b9db33ae:TbiTwCCsGsyFFnfWt5Rreg0cGYJeTiofxjuZNSLUuGo=", signature);
        }
    }
}
