using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MockHttpServer;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OnlinePayments.Sdk.Authentication;

namespace OnlinePayments.Sdk.Communication
{
    [TestFixture]
    public class DefaultGzipRequestTest
    {
        private const int Port = 5361;

        [Test]
        public async Task SendsGzipCompressedRequestBody()
        {
            string decompressedBody = null;
            string contentEncodingHeader = null;
            string contentTypeHeader = null;

            using var _ = new MockServer(Port, "/gzip", (request, response, context) =>
            {
                contentEncodingHeader = request.Headers["Content-Encoding"];
                contentTypeHeader = request.ContentType;

                using (var gzip = new GZipStream(request.InputStream, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzip, Encoding.UTF8))
                {
                    decompressedBody = reader.ReadToEnd();
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                var jsonResponse = @"{ ""merchantBatchReference"": ""dummy-ref"", ""totalCount"": 2 }";
                var bytes = Encoding.UTF8.GetBytes(jsonResponse);
                response.OutputStream.Write(bytes, 0, bytes.Length);

                return null;
            });

            using var communicator = CreateCommunicatorPointingToLocalhost(Port);

            var requestBody = CreateMinimalRequestBody();

            var callContext = new CallContext { GZip = true };

            await communicator.Post(
                "/gzip",
                null,
                null,
                requestBody,
                null,
                callContext
            ).ConfigureAwait(false);

            Assert.That(contentEncodingHeader, Is.EqualTo("gzip"));
            Assert.That(decompressedBody, Is.Not.Null.And.Not.Empty);
            Assert.That(contentTypeHeader, Does.StartWith("application/json"));

            var obj = JObject.Parse(decompressedBody);
            Assert.That((string)obj["header"]["operationType"], Is.EqualTo("CreatePayment"));
            Assert.That((int?)obj["header"]["itemCount"], Is.EqualTo(2));
        }

        private static ICommunicator CreateCommunicatorPointingToLocalhost(int port)
        {
            var uriBuilder = new UriBuilder("http", "localhost") { Port = port };

            var configuration = new CommunicatorConfiguration()
                .WithApiEndpoint(uriBuilder.Uri)
                .WithAuthorizationType(AuthorizationType.V1HMAC)
                .WithApiKeyId("api-key-id")
                .WithSecretApiKey("api-key-secret")
                .WithIntegrator("integrator")
                .WithConnectTimeout(5000)
                .WithSocketTimeout(5000);

            return Factory.CreateCommunicator(configuration);
        }

        private static Dictionary<string, object> CreateMinimalRequestBody()
        {
            var header = new Dictionary<string, object>
            {
                { "itemCount", 2 },
                { "operationType", "CreatePayment" },
                { "merchantBatchReference", Guid.NewGuid().ToString() }
            };

            var payment1 = new Dictionary<string, object>
            {
                {
                    "order", new Dictionary<string, object>
                    {
                        {
                            "amountOfMoney", new Dictionary<string, object>
                            {
                                { "amount", 10000 },
                                { "currencyCode", "EUR" }
                            }
                        }
                    }
                }
            };

            var payment2 = new Dictionary<string, object>
            {
                {
                    "order", new Dictionary<string, object>
                    {
                        {
                            "amountOfMoney", new Dictionary<string, object>
                            {
                                { "amount", 20000 },
                                { "currencyCode", "EUR" }
                            }
                        }
                    }
                }
            };

            return new Dictionary<string, object>
            {
                { "header", header },
                { "createPayments", new List<Dictionary<string, object>> { payment1, payment2 } }
            };
        }
    }
}
