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

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class DefaultGzipRequestTest
{
    private const int Port = 5361;

    [Test]
    public async Task Post_WithGzipEnabled_SendsGzipCompressedBody()
    {
        string decompressedBody = null;
        string contentEncodingHeader = null;
        string contentTypeHeader = null;

        using MockServer _ = new(Port, "/gzip", (request, response, _) =>
        {
            contentEncodingHeader = request.Headers["Content-Encoding"];
            contentTypeHeader = request.ContentType;

            using (var gzip = new GZipStream(request.InputStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzip, Encoding.UTF8))
            {
                decompressedBody = reader.ReadToEnd();
            }

            response.StatusCode = (int)HttpStatusCode.OK;
            const string jsonResponse = @"{ ""merchantBatchReference"": ""dummy-ref"", ""totalCount"": 2 }";
            var bytes = Encoding.UTF8.GetBytes(jsonResponse);
            response.OutputStream.Write(bytes, 0, bytes.Length);

            return null;
        });

        using var communicator = CreateCommunicatorPointingToLocalhost(Port);

        var requestBody = CreateMinimalRequestBody();
        CallContext callContext = new() { GZip = true };

        await communicator.Post(
            "/gzip",
            null,
            null,
            requestBody,
            null,
            callContext
        ).ConfigureAwait(false);

        Assert.That(contentEncodingHeader, Is.Not.Null);
        Assert.That(decompressedBody, Is.Not.Null);
        Assert.That(contentTypeHeader, Is.Not.Null);

        Assert.That(contentEncodingHeader, Is.EqualTo("gzip"));
        Assert.That(decompressedBody, Is.Not.Empty);
        Assert.That(contentTypeHeader, Does.StartWith("application/json"));

        var jObject = JObject.Parse(decompressedBody);

        var header = jObject["header"];
        Assert.That(header, Is.Not.Null);

        var operationType = header["operationType"];
        Assert.That(operationType, Is.Not.Null);
        Assert.That((string)operationType, Is.EqualTo("CreatePayment"));

        var itemCount = header["itemCount"];
        Assert.That(itemCount, Is.Not.Null);
        Assert.That((int?)itemCount, Is.EqualTo(2));
    }

    [Test]
    public async Task Post_WithGzipDisabled_DoesNotSendContentEncodingHeader()
    {
        string contentEncodingHeader = null;

        using MockServer _ = new(Port, "/gzip", (request, response, _) =>
        {
            contentEncodingHeader = request.Headers["Content-Encoding"];

            response.StatusCode = (int)HttpStatusCode.OK;
            const string jsonResponse = @"{ ""merchantBatchReference"": ""dummy-ref"", ""totalCount"": 2 }";
            var bytes = Encoding.UTF8.GetBytes(jsonResponse);
            response.OutputStream.Write(bytes, 0, bytes.Length);

            return null;
        });

        using var communicator = CreateCommunicatorPointingToLocalhost(Port);

        var requestBody = CreateMinimalRequestBody();
        CallContext callContext = new() { GZip = false };

        await communicator.Post(
            "/gzip",
            null,
            null,
            requestBody,
            null,
            callContext
        ).ConfigureAwait(false);

        Assert.That(contentEncodingHeader, Is.Null);
    }

    private static ICommunicator CreateCommunicatorPointingToLocalhost(int port)
    {
        UriBuilder uriBuilder = new("http", "localhost") { Port = port };

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
        Dictionary<string, object> header = new()
        {
            { "itemCount", 2 },
            { "operationType", "CreatePayment" },
            { "merchantBatchReference", Guid.NewGuid().ToString() }
        };

        Dictionary<string, object> paymentFirst = new()
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

        Dictionary<string, object> paymentSecond = new()
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
            { "createPayments", new List<Dictionary<string, object>> { paymentFirst, paymentSecond } }
        };
    }
}
