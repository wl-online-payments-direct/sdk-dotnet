using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using MockHttpServer;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class DefaultConnectionLoggerTest
{
    private const int Port = 5359;

    private const string GetWithQueryParamsJson = @"{
   ""convertedAmount"" : 4547504
}";
    private static readonly string GetWithQueryParamsRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'GET'
  uri:          '/v1/get?source=EUR&target=USD&amount=1000'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape("'");
    private static readonly string GetWithQueryParamsResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '200'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
   ""convertedAmount"" : 4547504
}'");

    private const string CreatedJson = @"{
    ""payment"": {
        ""id"": ""000000123410000595980000100001"",
        ""status"": ""PENDING_APPROVAL""
    }
}";
    private static readonly string PostWithCreatedResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'POST'
  uri:          '/v1/created'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********"", Content-Type=""application/json""") + "[^']*" + Regex.Escape(@"'
  content-type: 'application/json'
  body:         '{""card"":{""cvv"":""***"",""cardNumber"":""************3456"",""expiryDate"":""**20""}}'");
    private static readonly string PostWithCreatedResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '201'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")(?=('|.*, )Location=""http://localhost/v1/created/000000123410000595980000100001"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""payment"": {
        ""id"": ""000000123410000595980000100001"",
        ""status"": ""PENDING_APPROVAL""
    }
}'");

    private const string PostWithBadRequestResponseJson = @"{
    ""errorId"": ""0953f236-9e54-4f23-9556-d66bc757dda8"",
    ""errors"": [
        {
            ""code"": ""21000020"",
            ""requestId"": ""24146"",
            ""message"": ""VALUE **************** OF FIELD CREDITCARDNUMBER DID NOT PASS THE LUHNCHECK"",
            ""httpStatusCode"": 400
        }
    ]
}";
    private static readonly string PostWithBadRequestResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'POST'
  uri:          '/v1/bad-request'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape(@"'
  content-type: 'application/json'
  body:         '{""card"":{""cvv"":""***"",""cardNumber"":""************3456"",""expiryDate"":""**20""}}'");
    private static readonly string PostWithBadRequestResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '400'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""errorId"": ""0953f236-9e54-4f23-9556-d66bc757dda8"",
    ""errors"": [
        {
            ""code"": ""21000020"",
            ""requestId"": ""24146"",
            ""message"": ""VALUE **************** OF FIELD CREDITCARDNUMBER DID NOT PASS THE LUHNCHECK"",
            ""httpStatusCode"": 400
        }
    ]
}'");

    private static readonly string DeleteWithVoidResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'DELETE'
  uri:          '/v1/void'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape("'");
    private static readonly string DeleteWithVoidResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '204'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: ''
  body:         ''");

    private const string GetWithoutQueryParamsJson = @"{
    ""result"": ""OK""
}";
    private static readonly string GetWithoutQueryParamsRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("')") + Regex.Escape(@":
  method:       'GET'
  uri:          '/v1/get'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape("'");
    private static readonly string GetWithoutQueryParamsResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '200'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""result"": ""OK""
}'");

    private static readonly string BinaryRequestRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'POST'
  uri:          '/binaryRequest'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape(@"'
  content-type: 'multipart/form-data; boundary=") + ".*" + Regex.Escape(@"'
  body:         '<binary content>'");
    private static readonly string BinaryRequestResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '204'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: ''
  body:         ''");

    private static readonly string BinaryResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'GET'
  uri:          '/binaryContent'
  headers:      '") + "[^']*" + Regex.Escape("'");
    private static readonly string BinaryResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '200'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/octet-stream'
  body:         '<binary content>'");

    private const string UnknownServerErrorJson = @"{
    ""errorId"": ""fbff1179-7ba4-4894-9021-d8a0011d23a7"",
    ""errors"": [
        {
            ""code"": ""9999"",
            ""message"": ""UNKNOWN_SERVER_ERROR"",
            ""httpStatusCode"": 500
        }
    ]
}";
    private static readonly string UnknownServerErrorResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '500'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""errorId"": ""fbff1179-7ba4-4894-9021-d8a0011d23a7"",
    ""errors"": [
        {
            ""code"": ""9999"",
            ""message"": ""UNKNOWN_SERVER_ERROR"",
            ""httpStatusCode"": 500
        }
    ]
}'");

    private const string NotFoundHtml = "Not Found";
    private static readonly string NotFoundResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '404'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'text/html'
  body:         'Not Found'");

    private static readonly string GenericError = Regex.Escape("Error occurred for outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("')");

    private const string GetWithUtf8ResponseJson = @"{
    ""message"": ""café 日本語""
}";
    private static readonly string GetWithUtf8ResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("')") + Regex.Escape(@":
  method:       'GET'
  uri:          '/v1/get-utf8'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********""") + "[^']*" + Regex.Escape("'");
    private static readonly string GetWithUtf8ResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '200'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""message"": ""café 日本語""
}'");

    private const string PutWithSuccessResponseJson = @"{
    ""result"": ""OK""
}";
    private static readonly string PutWithSuccessResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'PUT'
  uri:          '/v1/put'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********"", Content-Type=""application/json""") + "[^']*" + Regex.Escape(@"'
  content-type: 'application/json'
  body:         '{""key"":""value""}'");
    private static readonly string PutWithSuccessResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '200'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '{
    ""result"": ""OK""
}'");

    private static readonly string PutWithBadRequestResponseRequest = Regex.Escape("Outgoing request (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape(@"'):
  method:       'PUT'
  uri:          '/v1/put-bad-request'
  headers:      'X-GCS-ServerMetaInfo=""") + @"[^""]*" + Regex.Escape(@""", Date=""") + @"[^""]+" + Regex.Escape(@""", Authorization=""********"", Content-Type=""application/json""") + "[^']*" + Regex.Escape(@"'
  content-type: 'application/json'
  body:         '{""key"":""value""}'");
    private static readonly string PutWithBadRequestResponseResponse = Regex.Escape("Incoming response (requestId='") + "([-a-zA-Z0-9]+)" + Regex.Escape("' + '") + "[0-9]*" + Regex.Escape(@"' ms):
  status-code:  '400'
  headers:      ") + @"(?=('|.*, )Server=""[^""]*"")(?=('|.*, )Dummy="""")(?=('|.*, )Date=""[^""]*"")'[^']*'" + Regex.Escape(@"
  content-type: 'application/json'
  body:         '") + Regex.Escape(PostWithBadRequestResponseJson) + "'";

    [TestCase]
    public async Task CommunicatorGet_WithoutQueryParams_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/get", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

                   return GetWithoutQueryParamsJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            var response = await communicator.Get<JObject>("v1/get", new List<IRequestHeader>(), null, null);

            Assert.That(response, Is.Not.Null);
            Assert.That(new JValue("OK"), Is.EqualTo(response["result"]));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, GetWithoutQueryParamsRequest, GetWithoutQueryParamsResponse);
    }

    [TestCase]
    public async Task CommunicatorGet_WithQueryParams_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/get", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

                   return GetWithQueryParamsJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);
            TestParamRequest query = new(
                new RequestParam("source", "EUR"),
                new RequestParam("target", "USD"),
                new RequestParam("amount", "1000")
            );

            var response = await communicator.Get<JObject>("v1/get", new List<IRequestHeader>(), query, null);

            Assert.That(response, Is.Not.Null);
            Assert.That(response["convertedAmount"], Is.EqualTo(new JValue(4547504)));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, GetWithQueryParamsRequest, GetWithQueryParamsResponse);
    }

    [TestCase]
    public async Task CommunicatorDelete_WithVoidResponse_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/void", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)204, new Dictionary<string, string>(), response, contentType: null);

                   return null;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);
            await communicator.Delete<object>("v1/void", new List<IRequestHeader>(), null, null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, DeleteWithVoidResponseRequest, DeleteWithVoidResponseResponse);
    }

    [TestCase]
    public async Task CommunicatorPost_WithCreatedResponse_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/created", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)201, new Dictionary<string, string>(), response, "http://localhost/v1/created/000000123410000595980000100001");

                   return CreatedJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Dictionary<string, string> card = new() {
                { "cvv", "123" },
                { "cardNumber", "1234567890123456" },
                { "expiryDate", "1220" }
            };

            Dictionary<string, object> request = new() {
                { "card", card }
            };

            var response = await communicator.Post<JObject>("v1/created", new List<IRequestHeader>(), null, request, null);

            Assert.That(response, Is.Not.Null);
            Assert.That(response["payment"], Is.InstanceOf<JObject>());

            var paymentToken = response["payment"];

            Assert.That(paymentToken, Is.Not.Null);
            Assert.That(paymentToken, Is.InstanceOf<JObject>());

            var payment = (JObject)paymentToken!;

            var paymentId = payment["id"];
            Assert.That(paymentId, Is.Not.Null);

            var paymentStatus = payment["status"];
            Assert.That(paymentStatus, Is.Not.Null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, PostWithCreatedResponseRequest, PostWithCreatedResponseResponse);
    }

    [TestCase]
    public void CommunicatorPost_WithBadRequestResponse_LogsRequestAndResponse()
    {
        // an exception is thrown after logging the response

        var logger = new TestLogger();

        using (var _ = new MockServer(Port, "/v1/bad-request", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)400, new Dictionary<string, string>(), response);

                   return PostWithBadRequestResponseJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Dictionary<string, string> card = new() {
                { "cvv", "123" },
                { "cardNumber", "1234567890123456" },
                { "expiryDate", "1220" }
            };

            Dictionary<string, object> request = new() {
                { "card", card }
            };

            Assert.CatchAsync(typeof(ResponseException),
                async () => await communicator.Post<object>("v1/bad-request", new List<IRequestHeader>(), null, request, null));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, PostWithBadRequestResponseRequest, PostWithBadRequestResponseResponse);
    }

    [TestCase]
    public async Task CommunicatorPost_BinaryRequestWithKnownLength_LogsBinaryRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/binaryRequest", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)204, new Dictionary<string, string>(), response, contentType: null);

                   return null;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            var data = new byte[1024];
            new Random().NextBytes(data);

            UploadableFile file = new("dummyFile", new MemoryStream(data), "application/octetstream", data.Length);
            MultipartFormDataObject multipart = new();
            multipart.AddFile("file", file);

            await communicator.Post<object>("/binaryRequest", new List<IRequestHeader>(), null, multipart, null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, BinaryRequestRequest, BinaryRequestResponse);
    }

    [TestCase]
    public async Task CommunicatorPost_BinaryRequestWithUnknownLength_LogsBinaryRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/binaryRequest", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)204, new Dictionary<string, string>(), response, contentType: null);

                   return null;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            var data = new byte[1024];
            new Random().NextBytes(data);

            UploadableFile file = new("dummyFile", new MemoryStream(data), "application/octetstream");
            MultipartFormDataObject multipart = new();
            multipart.AddFile("file", file);

            await communicator.Post<object>("/binaryRequest", new List<IRequestHeader>(), null, multipart, null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, BinaryRequestRequest, BinaryRequestResponse);
    }

    [TestCase]
    public async Task ConnectionGet_WithBinaryResponse_LogsRequestAndBinaryResponse()
    {
        TestLogger logger = new();

        var data = new byte[10];
        new Random().NextBytes(data);

        using (var _ = new MockServer(Port, "/binaryContent", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response, null, "application/octet-stream");
                   new MemoryStream(data).CopyTo(response.OutputStream);
               }))

        using (var connection = CreateConnection())
        {
            connection.EnableLogging(logger);

            UriBuilder uriBuilder = new("http", "localhost")
            {
                Port = Port,
                Path = "/binaryContent"
            };

            await connection.Get<object>(uriBuilder.Uri, new List<IRequestHeader>(), (statusCode, stream, _) => {
                MemoryStream memStream = new();
                stream.CopyTo(memStream);

                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(memStream.ToArray(), Is.EqualTo(data));

                return null;
            });
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, BinaryResponseRequest, BinaryResponseResponse);
    }

    [TestCase]
    public async Task CommunicatorDelete_WithVoidContent_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/void", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)204, new Dictionary<string, string>(), response, contentType: null);
                   return null;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            await communicator.Delete("/v1/void", new List<IRequestHeader>(), null, (stream, _) => {
                Assert.That(stream.ReadByte(), Is.EqualTo(-1));
            }, null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, DeleteWithVoidResponseRequest, DeleteWithVoidResponseResponse);
    }

    [TestCase]
    public void CommunicatorGet_WithUnknownServerError_LogsRequestAndErrorResponse()
    {
        // an exception is thrown after logging the response
        // reuse the request from TestGetWithoutQueryParams

        var logger = new TestLogger();

        using (var _ = new MockServer(Port, "/v1/get", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)500, new Dictionary<string, string>(), response);

                   return UnknownServerErrorJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Assert.CatchAsync(typeof(ResponseException),
                async () => await communicator.Get<object>("v1/get", new List<IRequestHeader>(), null, null));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, GetWithoutQueryParamsRequest, UnknownServerErrorResponse);
    }

    [TestCase]
    public void CommunicatorGet_WithNonJsonNotFoundResponse_ThrowsNotFoundException()
    {
        // an exception is thrown after logging the response
        // reuse the request from TestGetWithoutQueryParams

        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/get", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)404, new Dictionary<string, string>(), response, contentType: "text/html");

                   return NotFoundHtml;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Assert.CatchAsync(typeof(NotFoundException),
                async () => await communicator.Get<object>("v1/get", new List<IRequestHeader>(), null, null));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, GetWithoutQueryParamsRequest, NotFoundResponse);
    }

    [TestCase]
    public void CommunicatorGet_WithReadTimeout_ThrowsCommunicationException()
    {
        TestLogger logger = new();

        using var communicator = CreateCommunicator(10);
        var safeCommunicator = communicator;

        using MockServer _ = new(Port, "/v1/get", (_, response, _) =>
        {
            AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

            System.Threading.Thread.Sleep(500);

            return GetWithoutQueryParamsJson;
        });

        safeCommunicator.EnableLogging(logger);

        Assert.That((Func<Task>)GetRequest,
            Throws.Exception.TypeOf(typeof(CommunicationException))
                .And.InnerException.TypeOf(typeof(TaskCanceledException)));

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var errorEntry = logger.Entries.ElementAt(1);

        Assert.That(errorEntry.Message, Is.Not.Null);
        Assert.That(errorEntry.Thrown, Is.Not.Null);

        AssertRequestAndError(
            requestEntry.Message,
            errorEntry.Message,
            GetWithoutQueryParamsRequest);

        return;

        async Task GetRequest() =>
            await safeCommunicator.Get<object>(
                "v1/get",
                new List<IRequestHeader>(),
                null,
                null);
    }

    [TestCase]
    public async Task CommunicatorGet_LoggingDisabledBeforeResponse_LogsOnlyRequest()
    {
        TestLogger logger = new();

        using var communicator = CreateCommunicator();
        var localCommunicator = communicator;

        using MockServer _ = new(Port, "/v1/get", (_, response, _) =>
        {
            AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

            localCommunicator.DisableLogging();

            return GetWithoutQueryParamsJson;
        });

        localCommunicator.EnableLogging(logger);

        var response = await localCommunicator.Get<JObject>(
            "v1/get",
            new List<IRequestHeader>(),
            null,
            null);

        Assert.That(response, Is.Not.Null);
        Assert.That(new JValue("OK"), Is.EqualTo(response["result"]));

        Assert.That(logger.Entries, Has.Count.EqualTo(1));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        AssertRequest(requestEntry.Message, GetWithoutQueryParamsRequest);
    }

    [TestCase]
    public async Task CommunicatorGet_LoggingEnabledAfterRequest_LogsOnlyResponse()
    {
        // logging is disabled after the request is logged but before the response is logged
        // reuse the request and response from TestGetWithoutQueryParams

        TestLogger logger = new();

        using var communicator = CreateCommunicator();
        var localCommunicator = communicator;

        using MockServer _ = new(Port, "/v1/get", (_, response, _) =>
        {
            AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

            localCommunicator.EnableLogging(logger);

            return GetWithoutQueryParamsJson;
        });

        var response = await localCommunicator.Get<JObject>(
            "v1/get",
            new List<IRequestHeader>(),
            null,
            null);

        Assert.That(response, Is.Not.Null);
        Assert.That(new JValue("OK"), Is.EqualTo(response["result"]));

        Assert.That(logger.Entries, Has.Count.EqualTo(1));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        AssertResponse(requestEntry.Message, GetWithoutQueryParamsResponse);
    }

    [TestCase]
    public void CommunicatorGet_LoggingEnabledAfterRequest_LogsOnlyError()
    {
        // logging is enabled after the request is logged but before the error is logged
        // reuse the request and response from TestGetWithoutQueryParams

        TestLogger logger = new();

        using var communicator = CreateCommunicator(100);
        var localCommunicator = communicator;

        using MockServer _ = new(Port, "/v1/get", (_, response, _) =>
        {
            AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);

            localCommunicator.EnableLogging(logger);

            System.Threading.Thread.Sleep(500);

            return GetWithoutQueryParamsJson;
        });

        Assert.That(async () => await localCommunicator.Get<object>(
                "v1/get",
                new List<IRequestHeader>(),
                null,
                null),
            Throws.Exception.TypeOf(typeof(CommunicationException))
                .And.InnerException.TypeOf(typeof(TaskCanceledException)));

        Assert.That(logger.Entries, Has.Count.EqualTo(1));

        var errorEntry = logger.Entries.First();

        Assert.That(errorEntry.Message, Is.Not.Null);
        Assert.That(errorEntry.Thrown, Is.Not.Null);

        AssertError(errorEntry.Message);
    }

    [TestCase]
    public async Task CommunicatorGet_WithUtf8Response_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/get-utf8", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);
                   return GetWithUtf8ResponseJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            var response = await communicator.Get<JObject>("v1/get-utf8", new List<IRequestHeader>(), null, null);

            Assert.That(response, Is.Not.Null);
            Assert.That(response["message"], Is.EqualTo(new JValue("café 日本語")));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, GetWithUtf8ResponseRequest, GetWithUtf8ResponseResponse);
    }

    [TestCase]
    public async Task CommunicatorPut_WithSuccessResponse_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/put", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);
                   return PutWithSuccessResponseJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Dictionary<string, string> body = new() { { "key", "value" } };
            var response = await communicator.Put<JObject>("v1/put", new List<IRequestHeader>(), null, body, null);

            Assert.That(response, Is.Not.Null);
            Assert.That(response["result"], Is.EqualTo(new JValue("OK")));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, PutWithSuccessResponseRequest, PutWithSuccessResponseResponse);
    }

    [TestCase]
    public void CommunicatorPut_WithBadRequestResponse_LogsRequestAndResponse()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/put-bad-request", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)400, new Dictionary<string, string>(), response);
                   return PostWithBadRequestResponseJson;
               }))

        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);

            Dictionary<string, string> body = new() { { "key", "value" } };

            Assert.CatchAsync(typeof(ResponseException),
                async () => await communicator.Put<object>("v1/put-bad-request", new List<IRequestHeader>(), null, body, null));
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(2));

        var requestEntry = logger.Entries.First();

        Assert.That(requestEntry.Message, Is.Not.Null);
        Assert.That(requestEntry.Thrown, Is.Null);

        var responseEntry = logger.Entries.ElementAt(1);

        Assert.That(responseEntry.Message, Is.Not.Null);
        Assert.That(responseEntry.Thrown, Is.Null);

        AssertRequestAndResponse(requestEntry.Message, responseEntry.Message, PutWithBadRequestResponseRequest, PutWithBadRequestResponseResponse);
    }

    [TestCase]
    public async Task CommunicatorGet_AfterLoggingDisabled_LogsNothing()
    {
        TestLogger logger = new();

        using (var _ = new MockServer(Port, "/v1/get", (_, response, _) =>
               {
                   AssignResponse((HttpStatusCode)200, new Dictionary<string, string>(), response);
                   return GetWithoutQueryParamsJson;
               }))
        using (var communicator = CreateCommunicator())
        {
            communicator.EnableLogging(logger);
            communicator.DisableLogging();

            var response = await communicator.Get<JObject>("v1/get", new List<IRequestHeader>(), null, null);

            Assert.That(response, Is.Not.Null);
        }

        Assert.That(logger.Entries, Has.Count.EqualTo(0));
    }

    private static void AssertRequestAndError(string requestMessage, string errorMessage, string requestPattern)
    {
        var requestId = AssertRequest(requestMessage, requestPattern);
        AssertError(errorMessage, requestId);
    }

    private static IConnection CreateConnection(int socketTimeout = 50000)
    {
        // Connect timeout not implemented
        return new DefaultConnection(TimeSpan.FromMilliseconds(socketTimeout));
    }

    private static ICommunicator CreateCommunicator(int socketTimeout = 50000)
    {
        var connection = CreateConnection(socketTimeout);
        TestAuthenticator authenticator = new();
        MetadataProvider metadataProvider = new("OnlinePayments");
        UriBuilder uriBuilder = new("http", "localhost")
        {
            Port = Port
        };

        return Factory.CreateCommunicator(uriBuilder.Uri, connection, authenticator, metadataProvider);
    }

    private static void AssertRequestAndResponse(string requestMessage, string responseMessage, string requestPattern, string responsePattern)
    {
        var requestId = AssertRequest(requestMessage, requestPattern);

        AssertResponse(responseMessage, responsePattern, requestId);
    }

    private static string AssertRequest(string requestMessage, string requestPattern)
    {
        Assert.That(requestMessage, Does.Match(requestPattern));
        var requestMatches = Regex.Match(requestMessage, requestPattern);
        var requestId = requestMatches.Groups[1].Value;

        return requestId;
    }

    private static void AssertResponse(string responseMessage, string responsePattern, string requestId = null)
    {
        Assert.That(responseMessage, Does.Match(responsePattern));
        var responseMatch = Regex.Match(responseMessage, responsePattern);

        var responseRequestId = responseMatch.Groups[1].Value;
        if (requestId != null)
        {
            Assert.That(responseRequestId, Is.EqualTo(requestId), $"response requestId '{responseRequestId}' does not match request requestId '{requestId}'");
        }
    }

    private static void AssertError(string message, string requestId = null)
    {
        Assert.That(message, Does.Match(GenericError));

        var responseMatch = Regex.Match(message, GenericError);

        var errorRequestId = responseMatch.Groups[1].Value;

        if (requestId != null)
        {
            Assert.That(requestId, Is.EqualTo(errorRequestId), $"error requestId '{errorRequestId}' does not match earlier requestId '{requestId}'");
        }
    }

    private static void AssignResponse(HttpStatusCode statusCode, IDictionary additionalHeaders, HttpListenerResponse response, string location = null, string contentType = "application/json")
    {
        response.StatusCode = (int)statusCode;
        if (contentType != null)
        {
            response.Headers.Add("Content-Type", contentType);
        }

        response.Headers.Add("Dummy", null);

        if (location != null)
        {
            response.Headers.Add("Location", location);
        }

        foreach (KeyValuePair<string, string> entry in additionalHeaders)
        {
            response.Headers.Add(entry.Key, entry.Value);
        }
    }

    private class TestLogger : Logging.ICommunicatorLogger
    {
        public IList<TestLoggerEntry> Entries { get; } = new List<TestLoggerEntry>();

        public void Log(string message)
        {
            Log(message, null);
        }

        public void Log(string message, Exception thrown)
        {
            Entries.Add(new TestLoggerEntry(message, thrown));
        }
    }

    private class TestLoggerEntry(string message, Exception thrown)
    {
        public string Message { get; } = message;
        public Exception Thrown { get; } = thrown;
    }

    private class TestParamRequest : AbstractParamRequest
    {
        private readonly List<RequestParam> _parameters;
        internal TestParamRequest(params RequestParam[] parameters)
        {
            _parameters = parameters.ToList();
        }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            return _parameters;
        }
    }
}
