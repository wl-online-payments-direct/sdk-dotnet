using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Logging;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class DefaultConnectionTest
{
    private static readonly TimeSpan SocketTimeout = TimeSpan.FromMilliseconds(10000);
    private const int MaxConnections = 100;
    private const int DefaultMaxConnections = 2;

    [TestCase]
    public void DefaultConnectionConstructor_WithDefaultOptions_UsesDefaultConfiguration()
    {
        DefaultConnection connection = new(SocketTimeout);
        AssertConnectTimeout(connection);
        AssertMaxConnections(DefaultMaxConnections);
        AssertNoProxy(connection);
        AssertNonCustomHandler(connection);
    }

    [TestCase]
    public void DefaultConnectionConstructor_WithMaxConnectionsWithoutProxy_UsesConfiguredMaxConnections()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);
        AssertConnectTimeout(connection);
        AssertMaxConnections(MaxConnections);
        AssertNoProxy(connection);
        AssertNonCustomHandler(connection);
    }

    [TestCase]
    public void DefaultConnectionConstructor_WithMaxConnectionsAndProxyWithoutAuthentication_UsesConfiguredProxy()
    {
        Proxy proxy = new(){ Uri = new Uri("http://test-proxy") };
        DefaultConnection connection = new(SocketTimeout, MaxConnections, proxy);

        AssertConnectTimeout(connection);
        AssertMaxConnections(MaxConnections);
        AssertProxy(connection, proxy);
        AssertNonCustomHandler(connection);
    }

    [TestCase]
    public void DefaultConnectionConstructor_WithMaxConnectionsAndProxyWithAuthentication_UsesConfiguredAuthenticatedProxy()
    {
        Proxy proxy = new(){ Uri = new Uri("http://test-proxy"), Username = "test-username", Password = "test-password" };
        DefaultConnection connection = new(SocketTimeout, MaxConnections, proxy);

        AssertConnectTimeout(connection);
        AssertMaxConnections(MaxConnections);
        AssertProxyAndAuthentication(connection, proxy);
        AssertNonCustomHandler(connection);
    }

    [TestCase]
    public void DefaultConnectionConstructor_WithAllOptions_UsesConfiguredConnection()
    {
        Proxy proxy = new(){ Uri = new Uri("http://test-proxy"), Username = "test-username", Password = "test-password" };
        CustomHttpClientHandler handler = new();
        DefaultConnection connection = new(SocketTimeout, MaxConnections, proxy, handler);

        AssertConnectTimeout(connection);
        AssertMaxConnections(MaxConnections);
        AssertProxyAndAuthentication(connection, proxy);
        AssertCustomHandler(connection);
    }

    [TestCase]
    public void SetBodyObfuscator_NullValue_ThrowsArgumentException()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        var exception = Assert.Throws<ArgumentException>(
            () => connection.BodyObfuscator = null
        );

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("bodyObfuscator is required"));
    }

    [TestCase]
    public void SetHeaderObfuscator_NullValue_ThrowsArgumentException()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        var exception = Assert.Throws<ArgumentException>(
            () => connection.HeaderObfuscator = null
        );

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("headerObfuscator is required"));
    }

    [TestCase]
    public void EnableLogging_ValidLogger_DoesNotThrow()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);
        MockCommunicatorLogger logger = new();

        Assert.DoesNotThrow(() => connection.EnableLogging(logger));
    }

    [TestCase]
    public void EnableLogging_NullLogger_DoesNotThrow()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        Assert.DoesNotThrow(() => connection.EnableLogging(null));
    }

    [TestCase]
    public void DisableLogging_ActiveConnection_DoesNotThrow()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        Assert.DoesNotThrow(connection.DisableLogging);
    }

    [TestCase]
    public void CloseIdleConnections_ActiveConnection_DoesNotThrow()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        Assert.DoesNotThrow(() => connection.CloseIdleConnections(TimeSpan.FromSeconds(5)));
    }

    [TestCase]
    public void CloseExpiredConnections_ActiveConnection_DoesNotThrow()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        Assert.DoesNotThrow(connection.CloseExpiredConnections);
    }

    [TestCase]
    public async Task EnableLogging_WithGetRequest_LogsRequestAndResponse()
    {
        CapturingHttpMessageHandler handler = new(_ =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            });

        using DefaultConnection connection = new(
            () => new HttpClient(handler, disposeHandler: false));

        CapturingCommunicatorLogger logger = new();
        connection.EnableLogging(logger);

        await connection.Get(
            new Uri("https://example.com"),
            new List<IRequestHeader>(),
            ResponseHandler);

        Assert.That(logger.LoggedMessages, Has.Count.EqualTo(2));

        return;

        static object ResponseHandler(
            HttpStatusCode statusCode,
            Stream stream,
            IEnumerable<IResponseHeader> responseHeaders) => new object();
    }

    [TestCase]
    public async Task DisableLogging_AfterEnabling_StopsLogging()
    {
        CapturingHttpMessageHandler handler = new(_ =>
            new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });

        using DefaultConnection connection = new(() => new HttpClient(handler, disposeHandler: false));
        CapturingCommunicatorLogger logger = new();
        connection.EnableLogging(logger);
        connection.DisableLogging();

        await connection.Get<object>(new Uri("https://example.com"), new List<IRequestHeader>(), (_, _, _) => null);

        Assert.That(logger.LoggedMessages, Has.Count.EqualTo(0));
    }

    [TestCase]
    public void Dispose_OpenConnection_DisposesSuccessfully()
    {
        DefaultConnection connection = new(SocketTimeout, MaxConnections);

        Assert.DoesNotThrow(connection.Dispose);
    }

    [TestCase]
    public async Task Get_WithRequestHeaders_SendsHeadersWithRequest()
    {
        HttpRequestMessage capturedRequest = null;

        CapturingHttpMessageHandler handler = new(request =>
        {
            capturedRequest = request;

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            };
        });

        using DefaultConnection connection = new(
            () => new HttpClient(handler, disposeHandler: false));

        List<IRequestHeader> headers =
        [
            new RequestHeader("Authorization", "Bearer token123"),
            new RequestHeader("X-Custom-Header", "custom-value")
        ];

        await connection.Get(
            new Uri("https://example.com"),
            headers,
            NoOpCallback);

        Assert.That(capturedRequest, Is.Not.Null);
        var hasAuth = capturedRequest.Headers.TryGetValues("Authorization", out var authValues);
        Assert.That(hasAuth, Is.True);
        Assert.That(authValues?.First(), Is.EqualTo("Bearer token123"));

        var hasCustom = capturedRequest.Headers.TryGetValues("X-Custom-Header", out var customValues);
        Assert.That(hasCustom, Is.True);
        Assert.That(customValues?.First(), Is.EqualTo("custom-value"));

        return;

        static object NoOpCallback(
            HttpStatusCode statusCode,
            Stream stream,
            IEnumerable<IResponseHeader> responseHeaders) => null;
    }

    [TestCase]
    public void Get_WithNoRequestHeaders_DoesNotThrow()
    {
        CapturingHttpMessageHandler handler = new(_ =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            });

        using DefaultConnection connection = new(
            () => new HttpClient(handler, disposeHandler: false));

        Assert.DoesNotThrowAsync(() =>
            connection.Get(
                new Uri("https://example.com"),
                [],
                HandleResponse));

        return;

        static object HandleResponse(HttpStatusCode statusCode, Stream stream,
            IEnumerable<IResponseHeader> responseHeaders) =>
            new();
    }

    [TestCase]
    public void Get_WithEmptyRequestHeaders_DoesNotThrow()
    {
        CapturingHttpMessageHandler handler = new(_ =>
            new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });

        using DefaultConnection connection = new(() => new HttpClient(handler, disposeHandler: false));

        Assert.DoesNotThrowAsync(async () =>
            await connection.Get<object>(new Uri("https://example.com"), new List<IRequestHeader>(), (_, _, _) => null));
    }

    #region Assertion Helpers

    private static void AssertMaxConnections(int expectedMaxConnections)
    {
        Assert.That(ServicePointManager.DefaultConnectionLimit, Is.EqualTo(expectedMaxConnections));
    }

    private static void AssertConnectTimeout(DefaultConnection connection)
    {
        Assert.That(GetHttpClient(connection).Timeout, Is.EqualTo(SocketTimeout));
    }

    private static void AssertNoProxy(DefaultConnection connection)
    {
        var handler = GetHttpClientHandler(connection);

        Assert.That(handler, Is.Not.Null);
        Assert.That(handler.Proxy, Is.Null);
    }

    private static void AssertProxy(DefaultConnection connection, Proxy proxy)
    {
        var handler = GetHttpClientHandler(connection);
        Assert.That(handler, Is.Not.Null);
        Assert.That(handler.UseProxy, Is.True);

        var webProxy = (WebProxy)handler.Proxy;
        Assert.That(webProxy, Is.Not.Null);
        Assert.That(webProxy.Address, Is.EqualTo(proxy.Uri));
        Assert.That(webProxy.Credentials, Is.Null);
    }

    private static void AssertProxyAndAuthentication(DefaultConnection connection, Proxy proxy)
    {
        var handler = GetHttpClientHandler(connection);
        Assert.That(handler, Is.Not.Null);
        Assert.That(handler.UseProxy, Is.True);

        var webProxy = (WebProxy)handler.Proxy;
        Assert.That(webProxy, Is.Not.Null);
        Assert.That(webProxy.Address, Is.EqualTo(proxy.Uri));

        var credentials = (NetworkCredential)webProxy.Credentials;
        Assert.That(credentials, Is.Not.Null);
        Assert.That(credentials.UserName, Is.EqualTo(proxy.Username));
        Assert.That(credentials.Password, Is.EqualTo(proxy.Password));
    }

    private static void AssertNonCustomHandler(DefaultConnection connection)
    {
        Assert.That(GetHttpClientHandler(connection), Is.Not.InstanceOf<CustomHttpClientHandler>());
    }

    private static void AssertCustomHandler(DefaultConnection connection)
    {
        Assert.That(GetHttpClientHandler(connection), Is.InstanceOf<CustomHttpClientHandler>());
    }

    private static HttpClient GetHttpClient(DefaultConnection connection)
    {
        var provider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");

        return provider();
    }

    private static HttpClientHandler GetHttpClientHandler(DefaultConnection connection)
    {
        var httpClient = GetHttpClient(connection);

        return (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler")
               ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
    }

    #endregion

    #region Test Helpers

    private sealed class MockCommunicatorLogger : ICommunicatorLogger
    {
        public void Log(string message) { }
        public void Log(string message, Exception exception) { }
    }

    private sealed class CapturingCommunicatorLogger : ICommunicatorLogger
    {
        public IList<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message) => LoggedMessages.Add(message);
        public void Log(string message, Exception exception) => LoggedMessages.Add(message);
    }

    private sealed class CapturingHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

        internal CapturingHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
            => _handler = handler;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(_handler(request));
    }

    #endregion
}
