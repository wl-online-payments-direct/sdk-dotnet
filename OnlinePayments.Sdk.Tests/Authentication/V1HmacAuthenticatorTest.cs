using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Authentication;

[TestFixture]
public class V1HmacAuthenticatorTest
{
    #region Constructor Tests

    [TestFixture]
    public class ConstructorTests
    {
        [TestFixture]
        public class WithThreeParameters
        {
            [TestCase]
            public void Constructor_WithNullSecretApiKey_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", null)
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("secretApiKey is required"));
            }

            [TestCase]
            public void Constructor_WithEmptySecretApiKey_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("secretApiKey is required"));
            }

            [TestCase]
            public void Constructor_WithWhitespaceSecretApiKey_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "   ")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("secretApiKey is required"));
            }

            [TestCase]
            public void Constructor_WithNullApiKeyId_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, null, "secretApiKey")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("apiKeyId is required"));
            }

            [TestCase]
            public void Constructor_WithEmptyApiKeyId_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "", "secretApiKey")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("apiKeyId is required"));
            }

            [TestCase]
            public void Constructor_WithWhitespaceApiKeyId_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "   ", "secretApiKey")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("apiKeyId is required"));
            }

            [TestCase]
            public void Constructor_WithNullAuthorizationType_ThrowsArgumentException()
            {
                ArgumentException exception = Assert.Throws<ArgumentException>(
                    () => _ = new V1HmacAuthenticator(null, "apiKeyId", "secretApiKey")
                );

                Assert.That(exception, Is.Not.Null);
                Assert.That(exception.Message, Does.Contain("authorizationType is required"));
            }

            [TestCase]
            public void Constructor_WithValidParameters_CreatesInstance()
            {
                V1HmacAuthenticator authenticator =
                    new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
                Assert.That(authenticator, Is.Not.Null);
            }
        }

        [TestFixture]
        public class WithCommunicatorConfiguration
        {
            [TestCase]
            public void Constructor_WithValidConfiguration_CreatesInstance()
            {
                CommunicatorConfiguration config = new CommunicatorConfiguration()
                    .WithApiKeyId("configApiKeyId")
                    .WithSecretApiKey("configSecretKey")
                    .WithAuthorizationType(AuthorizationType.V1HMAC);

                V1HmacAuthenticator authenticator = new V1HmacAuthenticator(config);
                Assert.That(authenticator, Is.Not.Null);
            }
        }
    }

    #endregion

    #region GetAuthorization Tests

    [TestFixture]
    public class WhenGettingAuthorization
    {
        private V1HmacAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
        }

        [TestCase]
        public async Task GetAuthorization_WithValidRequest_ContainsV1HmacAuthorizationType()
        {
            string authorization = await _authenticator.GetAuthorization(
                HttpMethod.Post,
                new Uri("http://localhost:8080/v2/1/services%20bla/testconnection?aap=noot&mies=geen%20noot"),
                new List<RequestHeader>()
            );

            Assert.That(authorization, Does.Contain(AuthorizationType.V1HMAC.ToString()));
        }

        [TestCase]
        public async Task GetAuthorization_WithMinimalRequest_ReturnsExpectedHeader()
        {
            V1HmacAuthenticator authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "EC36A74A98D21",
                "6Kj5HT0MQKC6D8eb7W3lTg71kVKVDSt1");

            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("Date", "Fri, 06 Jun 2014 13:39:43 GMT"));

            string authorization = await authenticator.GetAuthorization(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(authorization, Is.EqualTo("GCS v1HMAC:EC36A74A98D21:vCos01y77soPNJOW6kDCm4Bu5b2darAZ09PP7Wa+jRA="));
        }

        [TestCase]
        public async Task GetAuthorization_WithFullRequest_ReturnsExpectedHeader()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "processed header value"));
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "processed header value"));
            httpHeaders.Add(new RequestHeader("X-GCS-CustomerHeader", "processed header value"));
            httpHeaders.Add(new RequestHeader("Date", "Fri, 06 Jun 2014 13:39:43 GMT"));

            string authorization = await _authenticator.GetAuthorization(
                HttpMethod.Delete,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(authorization, Is.EqualTo("GCS v1HMAC:apiKeyId:jXG/ESTtRWawO4OOyxOrtWcQA8XkrZKeoHeGGIj4jws="));
        }

        [TestCase]
        public void GetAuthorization_WithNullHttpMethod_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await _authenticator.GetAuthorization(null, new Uri("http://localhost:8080/v2/1/tokens/2"),
                    new List<RequestHeader>())
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("httpMethod is required"));
        }

        [TestCase]
        public void GetAuthorization_WithEmptyHttpMethod_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await _authenticator.GetAuthorization(new HttpMethod(string.Empty),
                    new Uri("http://localhost:8080/v2/1/tokens/2"),
                    new List<RequestHeader>())
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.ParamName, Does.Contain("method"));
        }

        [TestCase]
        public void GetAuthorization_WithWhitespaceHttpMethod_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await _authenticator.GetAuthorization(new HttpMethod(" "),
                    new Uri("http://localhost:8080/v2/1/tokens/2"),
                    new List<RequestHeader>())
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.ParamName, Does.Contain("method"));
        }

        [TestCase]
        public void GetAuthorization_WithNullResourceUri_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await _authenticator.GetAuthorization(HttpMethod.Get, null, new List<RequestHeader>())
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("resourceUri is required"));
        }

        [TestCase]
        public void GetAuthorization_WithNullResourceUriAndNullHeaders_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await _authenticator.GetAuthorization(HttpMethod.Post, null, null)
            );

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Does.Contain("resourceUri is required"));
        }
    }

    #endregion

    #region ToCanonicalizeHeaderValue Tests

    [TestFixture]
    public class WhenCanonicalizingHeaderValue
    {
        private V1HmacAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithWhitespaceAndNewlines_ReturnsNormalizedValue()
        {
            Assert.That(_authenticator.ToCanonicalizeHeaderValue("aap\nnoot  "), Is.EqualTo("aap noot"));
            Assert.That(_authenticator.ToCanonicalizeHeaderValue(" aap\r\n  noot"), Is.EqualTo("aap noot"));
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithMultipleSpacesAndNewlines_ReturnsNormalizedValue()
        {
            string headerValue = _authenticator.ToCanonicalizeHeaderValue(" some value  \r\n \n with  some \r\n  spaces ");

            Assert.That(headerValue, Is.EqualTo("some value    with  some  spaces"));
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithNullValue_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => _authenticator.ToCanonicalizeHeaderValue(null)
            );

            Assert.That(exception, Is.Not.Null);
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithEmptyValue_ReturnsEmptyString()
        {
            string headerValue = _authenticator.ToCanonicalizeHeaderValue("");

            Assert.That(headerValue, Is.EqualTo(""));
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithWhitespaceOnly_ReturnsEmptyString()
        {
            string headerValue = _authenticator.ToCanonicalizeHeaderValue(" ");

            Assert.That(headerValue, Is.EqualTo(""));
        }

        [TestCase]
        public void ToCanonicalizeHeaderValue_WithCarriageReturn_ReturnsNormalizedValue()
        {
            string headerValue = _authenticator.ToCanonicalizeHeaderValue("a\r\nb\r\nc");

            Assert.That(headerValue, Is.EqualTo("a b c"));
        }
    }

    #endregion

    #region Header Canonicalization via DataToSign Tests

    [TestFixture]
    public class WhenCanonicalizingHeaderNamesThroughDataToSign
    {
        private V1HmacAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
        }

        [TestCase]
        public void ToDataToSign_WithXGcsHeaders_CanonicalizeHeaderNamesToLowercase()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "server-value"));
            httpHeaders.Add(new RequestHeader("X-GCS-CLIENTMETAINFO", "client-value"));
            httpHeaders.Add(new RequestHeader("X-GCS-CustomerHeader", "customer-value"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.Contain("x-gcs-clientmetainfo:client-value\n"));
            Assert.That(dataToSign, Does.Contain("x-gcs-customerheader:customer-value\n"));
            Assert.That(dataToSign, Does.Contain("x-gcs-servermetainfo:server-value\n"));
        }

        [TestCase]
        public void ToDataToSign_WithMultipleXGcsHeaders_SortsHeaderNamesAlphabetically()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "server-value"));
            httpHeaders.Add(new RequestHeader("X-GCS-CustomerHeader", "customer-value"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "client-value"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            int clientIndex = dataToSign.IndexOf(
                "x-gcs-clientmetainfo:client-value\n",
                StringComparison.Ordinal
            );

            int customerIndex = dataToSign.IndexOf(
                "x-gcs-customerheader:customer-value\n",
                StringComparison.Ordinal
            );

            int serverIndex = dataToSign.IndexOf(
                "x-gcs-servermetainfo:server-value\n",
                StringComparison.Ordinal
            );

            Assert.That(clientIndex, Is.LessThan(customerIndex));
            Assert.That(customerIndex, Is.LessThan(serverIndex));
        }

        [TestCase]
        public void ToDataToSign_WithNonXGcsHeaders_ExcludesThemFromCanonicalHeaderBlock()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("User-Agent", "test-agent"));
            httpHeaders.Add(new RequestHeader("Accept", "application/json"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.Not.Contain("user-agent"));
            Assert.That(dataToSign, Does.Not.Contain("accept:application/json"));
        }
    }

    #endregion

    #region ToDataToSign Tests

    [TestFixture]
    public class WhenCreatingDataToSign
    {
        private V1HmacAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
        }

        [TestCase]
        public void ToDataToSign_WithFullRequestHeaders_ReturnsExpectedCanonicalString()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo",
                "{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}"));
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "{\"aap\",\"noot\"}"));
            httpHeaders.Add(new RequestHeader("User-Agent", "Apache-HttpClient/4.3.4 (java 1.5)"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Post,
                new Uri("http://localhost:8080/v2/services%20bla/testconnection?aap=noot&mies=geen%20noot"),
                httpHeaders
            );

            const string expectedStart = "POST\napplication/json\n";
            const string expectedEnd = "x-gcs-clientmetainfo:{\"aap\",\"noot\"}\n"
                                       + "x-gcs-servermetainfo:{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}\n"
                                       + "/v2/services bla/testconnection?aap=noot&mies=geen noot\n";

            string actualStart = dataToSign.Substring(0, 22);
            string actualEnd = dataToSign.Substring(52, dataToSign.Length - 52);

            Assert.That(actualStart, Is.EqualTo(expectedStart));
            Assert.That(actualEnd, Is.EqualTo(expectedEnd));
        }

        [TestCase]
        public void ToDataToSign_WithSpecialCharactersInMerchantId_ReturnsCorrectCanonicalPath()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("X-GCS-ServerMetaInfo", "{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}"));
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("X-GCS-ClientMetaInfo", "{\"aap\",\"noot\"}"));
            httpHeaders.Add(new RequestHeader("User-Agent", "Apache-HttpClient/4.3.4 (java 1.5)"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Post,
                new Uri("http://localhost:8080/v2/spécificCharacterMerchant/testconnection?aap=noot&mies=geen%20noot"),
                httpHeaders
            );

            const string expectedStart = "POST\napplication/json\n";
            const string expectedEnd = "x-gcs-clientmetainfo:{\"aap\",\"noot\"}\n"
                                       + "x-gcs-servermetainfo:{\"platformIdentifier\":\"Windows 7/6.1 Java/1.7 (Oracle Corporation; Java HotSpot(TM) 64-Bit Server VM; 1.7.0_45)\",\"sdkIdentifier\":\"1.0\"}\n"
                                       + "/v2/spécificCharacterMerchant/testconnection?aap=noot&mies=geen noot\n";

            string actualStart = dataToSign[..22];
            string actualEnd = dataToSign[52..];

            Assert.That(actualStart, Is.EqualTo(expectedStart));
            Assert.That(actualEnd, Is.EqualTo(expectedEnd));
        }

        [TestCase]
        public void ToDataToSign_WithNullHeadersList_ReturnsValidCanonicalString()
        {
            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                null
            );

            Assert.That(dataToSign, Does.Contain("GET\n"));
            Assert.That(dataToSign, Does.Contain("/v2/1/tokens/2\n"));
        }

        [TestCase]
        public void ToDataToSign_WithNonXGcsHeaders_ExcludesThemFromResult()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));
            httpHeaders.Add(new RequestHeader("User-Agent", "test-agent"));
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.Contain("GET\n"));
            Assert.That(dataToSign, Does.Contain("application/json\n"));
            Assert.That(dataToSign, Does.Contain("Mon, 07 Jul 2014 12:12:40 GMT\n"));
            Assert.That(dataToSign, Does.Contain("/v2/1/tokens/2\n"));
        }

        [TestCase]
        public void ToDataToSign_WithMissingContentType_AppendsEmptyLine()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Delete,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.StartWith("DELETE\n\n"));
        }

        [TestCase]
        public void ToDataToSign_WithMissingDate_AppendsEmptyLineAfterContentType()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("Content-Type", "application/json"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Put,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.Contain("application/json\n\n"));
        }

        [TestCase]
        public void ToDataToSign_WithUriWithoutQuery_EndsWithPathAndNewline()
        {
            IList<RequestHeader> httpHeaders = new List<RequestHeader>();
            httpHeaders.Add(new RequestHeader("Date", "Mon, 07 Jul 2014 12:12:40 GMT"));

            string dataToSign = _authenticator.ToDataToSign(
                HttpMethod.Get,
                new Uri("http://localhost:8080/v2/1/tokens/2"),
                httpHeaders
            );

            Assert.That(dataToSign, Does.EndWith("/v2/1/tokens/2\n"));
        }
    }

    #endregion

    #region CreateAuthenticationSignature Tests

    [TestFixture]
    public class WhenCreatingAuthenticationSignature
    {
        private V1HmacAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "apiKeyId", "secretApiKey");
        }

        [TestCase]
        public void SignData_WithDeleteRequestData_ReturnsExpectedSignature()
        {
            string dataToSign =
                "DELETE\n"
                + "application/json\n"
                + "Fri, 06 Jun 2014 13:39:43 GMT\n"
                + "x-gcs-clientmetainfo:processed header value\n"
                + "x-gcs-customerheader:processed header value\n"
                + "x-gcs-servermetainfo:processed header value\n"
                + "/v2/1/tokens/2\n";

            string authenticationSignature = _authenticator.SignData(dataToSign);

            Assert.That(authenticationSignature, Is.EqualTo("jXG/ESTtRWawO4OOyxOrtWcQA8XkrZKeoHeGGIj4jws="));
        }

        [TestCase]
        public void SignData_WithGetRequestData_ReturnsExpectedSignature()
        {
            _authenticator = new V1HmacAuthenticator(AuthorizationType.V1HMAC, "EC36A74A98D21", "6Kj5HT0MQKC6D8eb7W3lTg71kVKVDSt1");

            string dataToSign =
                "GET\n"
                + "\n"
                + "Fri, 06 Jun 2014 13:39:43 GMT\n"
                + "/v2/1/tokens/2\n";

            string authenticationSignature = _authenticator.SignData(dataToSign);

            Assert.That(authenticationSignature, Is.EqualTo("vCos01y77soPNJOW6kDCm4Bu5b2darAZ09PP7Wa+jRA="));
        }
    }

    #endregion

    #region AuthorizationType Tests

    [TestFixture]
    public class WhenWorkingWithAuthorizationType
    {
        [TestCase]
        public void ToString_WhenCalledOnV1Hmac_ReturnsV1HmacString()
        {
            Assert.That(AuthorizationType.V1HMAC.ToString(), Is.EqualTo("v1HMAC"));
        }

        [TestCase]
        public void GetValueOf_WithExactV1HmacString_ReturnsV1HmacType()
        {
            Assert.That(AuthorizationType.GetValueOf("v1HMAC"), Is.EqualTo(AuthorizationType.V1HMAC));
        }

        [TestCase]
        public void GetValueOf_WithInvalidInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => AuthorizationType.GetValueOf("invalid")
            );
        }

        [TestCase]
        public void GetValueOf_WithEmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => AuthorizationType.GetValueOf("")
            );
        }

        [TestCase]
        public void GetValueOf_WithUnknownType_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => AuthorizationType.GetValueOf("V2HMAC")
            );
        }
    }

    #endregion
}
