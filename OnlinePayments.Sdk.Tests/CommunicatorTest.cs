using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk;

[TestFixture]
public class CommunicatorTest
{
    private const string BaseUriHost = "payment.preprod.online-payments.com";
    private static readonly Uri BaseUri = new("https://payment.preprod.online-payments.com");
    private const string RelativePath = "v1/merchant/20000/convertamount";
    private static readonly Uri AbsoluteUri = new("https://payment.preprod.online-payments.com/v1/merchant/20000/convertamount");

    private Mock<IConnection> _connectionMock;
    private Mock<IAuthenticator> _authenticatorMock;
    private IMetadataProvider _metadataProvider;
    private Mock<IMarshaller> _marshallerMock;

    [SetUp]
    public void SetUp()
    {
        _connectionMock = new Mock<IConnection>();
        _authenticatorMock = new Mock<IAuthenticator>();
        _metadataProvider = new MetadataProvider("OnlinePayments");
        _marshallerMock = new Mock<IMarshaller>();
        _authenticatorMock
            .Setup(a => a.GetAuthorization(
                It.IsAny<HttpMethod>(),
                It.IsAny<Uri>(),
                It.IsAny<IEnumerable<IRequestHeader>>()))
            .ReturnsAsync("dummy-authorization");
    }

    private Communicator CreateCommunicator()
        => new(BaseUri, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider, _marshallerMock.Object);

    private static Stream JsonBodyStream(string json)
        => new MemoryStream(Encoding.UTF8.GetBytes(json));

    private static List<IResponseHeader> JsonHeaders()
        => [new ResponseHeader("Content-Type", "application/json")];

    private static List<IResponseHeader> HtmlHeaders()
        => [new ResponseHeader("Content-Type", "text/html")];

    private static List<IResponseHeader> IdempotenceResponseHeaders()
        =>
        [
            new ResponseHeader("Content-Type", "application/json"),
            new ResponseHeader("X-GCS-Idempotence-Request-Timestamp", "123456789"),
            new ResponseHeader("IdempotencyResponseDatetime", "2026-04-02T10:15:30+00:00")
        ];

    private void SetupGet(HttpStatusCode status, Stream body, List<IResponseHeader> headers,
        Action<IEnumerable<IRequestHeader>> onHeaders = null)
    {
        _connectionMock.Setup(c => c.Get(
            It.IsAny<Uri>(),
            It.IsAny<IEnumerable<IRequestHeader>>(),
            It.IsAny<Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>()
        )).Returns<Uri, IEnumerable<IRequestHeader>, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>(
            (_, reqHeaders, callback) =>
            {
                onHeaders?.Invoke(reqHeaders);

                return Task.FromResult(callback(status, body, headers));
            });
    }

    private void SetupPost(HttpStatusCode status, Stream body, List<IResponseHeader> headers,
        Action<IEnumerable<IRequestHeader>, string> onInvoke = null)
    {
        _connectionMock.Setup(c => c.Post(
            It.IsAny<Uri>(),
            It.IsAny<IEnumerable<IRequestHeader>>(),
            It.IsAny<string>(),
            It.IsAny<Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>()
        )).Returns<Uri, IEnumerable<IRequestHeader>, string, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>(
            (_, reqHeaders, reqBody, callback) =>
            {
                onInvoke?.Invoke(reqHeaders, reqBody);

                return Task.FromResult(callback(status, body, headers));
            });
    }

    private void SetupPut(HttpStatusCode status, Stream body, List<IResponseHeader> headers,
        Action<IEnumerable<IRequestHeader>> onHeaders = null)
    {
        _connectionMock.Setup(c => c.Put(
            It.IsAny<Uri>(),
            It.IsAny<IEnumerable<IRequestHeader>>(),
            It.IsAny<string>(),
            It.IsAny<Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>()
        )).Returns<Uri, IEnumerable<IRequestHeader>, string, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>(
            (_, reqHeaders, _, callback) =>
            {
                onHeaders?.Invoke(reqHeaders);

                return Task.FromResult(callback(status, body, headers));
            });
    }

    private void SetupDelete(HttpStatusCode status, Stream body, List<IResponseHeader> headers,
        Action<IEnumerable<IRequestHeader>> onHeaders = null)
    {
        _connectionMock.Setup(c => c.Delete(
            It.IsAny<Uri>(),
            It.IsAny<IEnumerable<IRequestHeader>>(),
            It.IsAny<Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>()
        )).Returns<Uri, IEnumerable<IRequestHeader>, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, object>>(
            (_, reqHeaders, callback) =>
            {
                onHeaders?.Invoke(reqHeaders);

                return Task.FromResult(callback(status, body, headers));
            });
    }

    [TestCase]
    public void ToAbsoluteUri_WithoutRequestParams_ReturnsAbsoluteUri()
    {
        var communicator = CreateCommunicator();
        var uriFirst = communicator.ToAbsoluteUri("v1/merchant/20000/convertamount", new List<RequestParam>());
        var uriSecond = communicator.ToAbsoluteUri("/v1/merchant/20000/convertamount", new List<RequestParam>());

        Assert.That(uriFirst, Is.EqualTo(AbsoluteUri));
        Assert.That(uriSecond, Is.EqualTo(AbsoluteUri));
    }

    [TestCase]
    public void ToAbsoluteUri_WithRequestParams_ReturnsUriWithEncodedQueryString()
    {
        List<RequestParam> list =
        [
            new("amount", "123"),
            new("source", "USD"),
            new("target", "EUR"),
            new("dummy", "é&%=")
        ];

        var communicator = CreateCommunicator();
        var uriFirst = communicator.ToAbsoluteUri("v1/merchant/20000/convertamount", list);
        var uriSecond = communicator.ToAbsoluteUri("/v1/merchant/20000/convertamount", list);

        Assert.That(uriFirst, Is.EqualTo(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D")));
        Assert.That(uriSecond, Is.EqualTo(new Uri($"https://{BaseUriHost}/v1/merchant/20000/convertamount?amount=123&source=USD&target=EUR&dummy=%C3%A9%26%25%3D")));
    }

    [Test]
    public async Task Get_WhenResponseIsOk_ReturnsUnmarshalledResponse()
    {
        object expected = new();
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(expected);
        SetupGet(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        var result = await CreateCommunicator().Get<object>(RelativePath, null, null, null);

        Assert.That(result, Is.SameAs(expected));
    }

    [Test]
    public async Task Get_WithBodyHandler_PassesResponseBodyToHandler()
    {
        string received = null;
        SetupGet(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        await CreateCommunicator().Get(RelativePath, null, null,
            (stream, _) => { received = new StreamReader(stream).ReadToEnd(); }, null);

        Assert.That(received, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void Get_WithInvalidPath_ThrowsNotFoundExceptionWithPathMessage()
    {
        SetupGet(HttpStatusCode.NotFound, JsonBodyStream("Not found"), HtmlHeaders());

        var exception = Assert.ThrowsAsync<NotFoundException>(async () =>
            await CreateCommunicator().Get<object>("does/not/exist", null, null, null));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("invalid path: does/not/exist"));
    }

    [Test]
    public void Get_WithNonJsonErrorResponse_ThrowsCommunicationException()
    {
        SetupGet(HttpStatusCode.InternalServerError, JsonBodyStream("server error"), HtmlHeaders());

        Assert.ThrowsAsync<CommunicationException>(async () =>
            await CreateCommunicator().Get<object>(RelativePath, null, null, null));
    }

    [Test]
    public async Task Post_WhenResponseIsOk_ReturnsUnmarshalledResponse()
    {
        object body = new();
        object expected = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(expected);
        SetupPost(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        var result = await CreateCommunicator().Post<object>(RelativePath, null, null, body, null);

        Assert.That(result, Is.SameAs(expected));
    }

    [Test]
    public async Task Post_WithBodyHandler_PassesResponseBodyToHandler()
    {
        object body = new();
        string received = null;
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPost(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        await CreateCommunicator().Post(RelativePath, null, null, body,
            (stream, _) => { received = new StreamReader(stream).ReadToEnd(); }, null);

        Assert.That(received, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Post_WithNullBody_SendsNullBodyToConnection()
    {
        string capturedBody = "not-null";
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPost(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), (_, reqBody) => capturedBody = reqBody);

        await CreateCommunicator().Post<object>(RelativePath, null, null, null, null);

        Assert.That(capturedBody, Is.Null);
        _marshallerMock.Verify(m => m.Marshal(It.IsAny<object>()), Times.Never);
    }

    [Test]
    public void Post_WithJsonErrorResponse_ThrowsResponseException()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPost(HttpStatusCode.BadRequest, JsonBodyStream("{\"error\":\"bad request\"}"), JsonHeaders());

        Assert.ThrowsAsync<ResponseException>(async () =>
            await CreateCommunicator().Post<object>(RelativePath, null, null, body, null));
    }

    [Test]
    public void Post_WithNonJsonErrorResponse_ThrowsCommunicationException()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPost(HttpStatusCode.InternalServerError, JsonBodyStream("server error"), HtmlHeaders());

        Assert.ThrowsAsync<CommunicationException>(async () =>
            await CreateCommunicator().Post<object>(RelativePath, null, null, body, null));
    }

    [Test]
    public async Task Put_WhenResponseIsOk_ReturnsUnmarshalledResponse()
    {
        object body = new();
        object expected = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(expected);
        SetupPut(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        var result = await CreateCommunicator().Put<object>(RelativePath, null, null, body, null);

        Assert.That(result, Is.SameAs(expected));
    }

    [Test]
    public async Task Put_WithBodyHandler_PassesResponseBodyToHandler()
    {
        object body = new();
        string received = null;
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPut(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        await CreateCommunicator().Put(RelativePath, null, null, body,
            (stream, _) => { received = new StreamReader(stream).ReadToEnd(); }, null);

        Assert.That(received, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task Put_WithNullBody_DoesNotMarshalBody()
    {
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPut(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders());

        await CreateCommunicator().Put<object>(RelativePath, null, null, null, null);

        _marshallerMock.Verify(m => m.Marshal(It.IsAny<object>()), Times.Never);
    }

    [Test]
    public void Put_WithJsonErrorResponse_ThrowsResponseException()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPut(HttpStatusCode.BadRequest, JsonBodyStream("{\"error\":\"bad request\"}"), JsonHeaders());

        Assert.ThrowsAsync<ResponseException>(async () =>
            await CreateCommunicator().Put<object>(RelativePath, null, null, body, null));
    }

    [Test]
    public void Put_WithNonJsonErrorResponse_ThrowsCommunicationException()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        SetupPut(HttpStatusCode.InternalServerError, JsonBodyStream("server error"), HtmlHeaders());

        Assert.ThrowsAsync<CommunicationException>(async () =>
            await CreateCommunicator().Put<object>(RelativePath, null, null, body, null));
    }

    [Test]
    public async Task Delete_WhenResponseIsOk_ReturnsUnmarshalledResponse()
    {
        object expected = new();
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(expected);
        SetupDelete(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        var result = await CreateCommunicator().Delete<object>(RelativePath, null, null, null);

        Assert.That(result, Is.SameAs(expected));
    }

    [Test]
    public async Task Delete_WithBodyHandler_PassesResponseBodyToHandler()
    {
        string received = null;
        SetupDelete(HttpStatusCode.OK, JsonBodyStream("{\"result\":\"OK\"}"), JsonHeaders());

        await CreateCommunicator().Delete(RelativePath, null, null,
            (stream, _) => { received = new StreamReader(stream).ReadToEnd(); }, null);

        Assert.That(received, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void Delete_WithJsonErrorResponse_ThrowsResponseException()
    {
        SetupDelete(HttpStatusCode.BadRequest, JsonBodyStream("{\"error\":\"bad request\"}"), JsonHeaders());

        Assert.ThrowsAsync<ResponseException>(async () =>
            await CreateCommunicator().Delete<object>(RelativePath, null, null, null));
    }

    [Test]
    public void Delete_WithNonJsonErrorResponse_ThrowsCommunicationException()
    {
        SetupDelete(HttpStatusCode.InternalServerError, JsonBodyStream("server error"), HtmlHeaders());

        Assert.ThrowsAsync<CommunicationException>(async () =>
            await CreateCommunicator().Delete<object>(RelativePath, null, null, null));
    }

    [Test]
    public async Task Get_WithIdempotenceKey_AddsIdempotenceHeaderToRequest()
    {
        IEnumerable<IRequestHeader> capturedHeaders = null;
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupGet(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), h => capturedHeaders = h);

        await CreateCommunicator().Get<object>(RelativePath, null, null,
            new CallContext().WithIdempotenceKey("test-idempotence-key"));

        Assert.That(capturedHeaders.Any(h => h.Name == "X-GCS-Idempotence-Key" && h.Value == "test-idempotence-key"), Is.True);
    }

    [Test]
    public async Task Get_WithoutContext_OmitsIdempotenceHeaderFromRequest()
    {
        IEnumerable<IRequestHeader> capturedHeaders = null;
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupGet(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), h => capturedHeaders = h);

        await CreateCommunicator().Get<object>(RelativePath, null, null, null);

        Assert.That(capturedHeaders.Any(h => h.Name == "X-GCS-Idempotence-Key"), Is.False);
    }

    [Test]
    public async Task Post_WithIdempotenceKey_AddsIdempotenceHeaderToRequest()
    {
        IEnumerable<IRequestHeader> capturedHeaders = null;
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPost(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), (h, _) => capturedHeaders = h);

        await CreateCommunicator().Post<object>(RelativePath, null, null, body,
            new CallContext().WithIdempotenceKey("test-idempotence-key"));

        Assert.That(capturedHeaders.Any(h => h.Name == "X-GCS-Idempotence-Key" && h.Value == "test-idempotence-key"), Is.True);
    }

    [Test]
    public async Task Put_WithIdempotenceKey_AddsIdempotenceHeaderToRequest()
    {
        IEnumerable<IRequestHeader> capturedHeaders = null;
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPut(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), h => capturedHeaders = h);

        await CreateCommunicator().Put<object>(RelativePath, null, null, body,
            new CallContext().WithIdempotenceKey("test-idempotence-key"));

        Assert.That(capturedHeaders.Any(h => h.Name == "X-GCS-Idempotence-Key" && h.Value == "test-idempotence-key"), Is.True);
    }

    [Test]
    public async Task Delete_WithIdempotenceKey_AddsIdempotenceHeaderToRequest()
    {
        IEnumerable<IRequestHeader> capturedHeaders = null;
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupDelete(HttpStatusCode.OK, JsonBodyStream("{}"), JsonHeaders(), h => capturedHeaders = h);

        await CreateCommunicator().Delete<object>(RelativePath, null, null,
            new CallContext().WithIdempotenceKey("test-idempotence-key"));

        Assert.That(capturedHeaders.Any(h => h.Name == "X-GCS-Idempotence-Key" && h.Value == "test-idempotence-key"), Is.True);
    }

    [Test]
    public async Task Get_WithIdempotenceContext_PopulatesIdempotenceFieldsFromResponseHeaders()
    {
        object expected = new();
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(expected);
        SetupGet(HttpStatusCode.OK, JsonBodyStream("{}"), IdempotenceResponseHeaders());

        var context = new CallContext().WithIdempotenceKey("test-key");
        var result = await CreateCommunicator().Get<object>(RelativePath, null, null, context);

        Assert.That(result, Is.SameAs(expected));
        Assert.That(context.IdempotenceKey, Is.EqualTo("test-key"));
        Assert.That(context.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(context.IdempotenceResponseDateTime, Is.EqualTo(DateTimeOffset.Parse("2026-04-02T10:15:30+00:00")));
    }

    [Test]
    public async Task Post_WithIdempotenceContext_PopulatesIdempotenceFieldsFromResponseHeaders()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPost(HttpStatusCode.OK, JsonBodyStream("{}"), IdempotenceResponseHeaders());

        var context = new CallContext().WithIdempotenceKey("test-key");
        await CreateCommunicator().Post<object>(RelativePath, null, null, body, context);

        Assert.That(context.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(context.IdempotenceResponseDateTime, Is.EqualTo(DateTimeOffset.Parse("2026-04-02T10:15:30+00:00")));
    }

    [Test]
    public async Task Put_WithIdempotenceContext_PopulatesIdempotenceFieldsFromResponseHeaders()
    {
        object body = new();
        _marshallerMock.Setup(m => m.Marshal(body)).Returns("{\"request\":\"body\"}");
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupPut(HttpStatusCode.OK, JsonBodyStream("{}"), IdempotenceResponseHeaders());

        var context = new CallContext().WithIdempotenceKey("test-key");
        await CreateCommunicator().Put<object>(RelativePath, null, null, body, context);

        Assert.That(context.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(context.IdempotenceResponseDateTime, Is.EqualTo(DateTimeOffset.Parse("2026-04-02T10:15:30+00:00")));
    }

    [Test]
    public async Task Delete_WithIdempotenceContext_PopulatesIdempotenceFieldsFromResponseHeaders()
    {
        _marshallerMock.Setup(m => m.Unmarshal<object>(It.IsAny<Stream>())).Returns(new object());
        SetupDelete(HttpStatusCode.OK, JsonBodyStream("{}"), IdempotenceResponseHeaders());

        var context = new CallContext().WithIdempotenceKey("test-key");
        await CreateCommunicator().Delete<object>(RelativePath, null, null, context);

        Assert.That(context.IdempotenceRequestTimestamp, Is.EqualTo(123456789L));
        Assert.That(context.IdempotenceResponseDateTime, Is.EqualTo(DateTimeOffset.Parse("2026-04-02T10:15:30+00:00")));
    }

    [Test]
    public void Communicator_WithValidArguments_CreatesInstance()
    {
        Assert.That(CreateCommunicator(), Is.Not.Null);
    }

    [Test]
    public void Communicator_WithNullApiEndpoint_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(null, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithApiEndpointHavingPath_ThrowsArgumentException()
    {
        Uri endpoint = new("https://payment.preprod.online-payments.com/v1");
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(endpoint, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithApiEndpointHavingUserInfo_ThrowsArgumentException()
    {
        Uri endpoint = new("https://user:pass@payment.preprod.online-payments.com");
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(endpoint, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithApiEndpointHavingQuery_ThrowsArgumentException()
    {
        Uri endpoint = new("https://payment.preprod.online-payments.com?key=value");
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(endpoint, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithApiEndpointHavingFragment_ThrowsArgumentException()
    {
        Uri endpoint = new("https://payment.preprod.online-payments.com#section");
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(endpoint, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithNullConnection_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(BaseUri, null, _authenticatorMock.Object, _metadataProvider, _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithNullAuthenticator_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(BaseUri, _connectionMock.Object, null, _metadataProvider, _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithNullMetadataProvider_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(BaseUri, _connectionMock.Object, _authenticatorMock.Object, null,
                _marshallerMock.Object);
        });
    }

    [Test]
    public void Communicator_WithNullMarshaller_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _ = new Communicator(BaseUri, _connectionMock.Object, _authenticatorMock.Object, _metadataProvider, null);
        });
    }

    [Test]
    public void Marshaller_WhenAccessed_IsNotNull()
    {
        Assert.That(CreateCommunicator().Marshaller, Is.Not.Null);
    }

    [Test]
    public void Marshaller_WhenAccessed_ReturnsSameInstance()
    {
        var communicator = CreateCommunicator();

        Assert.That(communicator.Marshaller, Is.SameAs(_marshallerMock.Object));
    }

    [Test]
    public void Dispose_WhenCalled_DisposesConnection()
    {
        var communicator = CreateCommunicator();
        communicator.Dispose();

        _connectionMock.Verify(c => c.Dispose(), Times.Once);
    }

    [Test]
    public void Dispose_ViaUsingStatement_DoesNotThrow()
    {
        using var communicator = CreateCommunicator();

        Assert.That(communicator, Is.Not.Null);
    }
}
