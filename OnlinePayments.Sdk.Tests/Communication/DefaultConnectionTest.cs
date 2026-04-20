using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk.Communication
{
    [TestFixture]
    public class DefaultConnectionTest
    {
        private static readonly TimeSpan SocketTimeout = TimeSpan.FromMilliseconds(10000);
        private const int MaxConnections = 100;

        [TestCase]
        public void TestConstructWithoutProxy()
        {
            var connection = new DefaultConnection(SocketTimeout, MaxConnections);
            AssertConnectTimeout(connection);
            AssertNoProxy(connection);
            AssertNonCustomHandler(connection);
        }

        private static void AssertConnectTimeout(DefaultConnection connection)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            Assert.That(httpClient.Timeout, Is.EqualTo(SocketTimeout));
        }

        private static void AssertNoProxy(DefaultConnection connection)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            var handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler") ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler.Proxy, Is.Null);
        }

        private static void AssertProxy(DefaultConnection connection, Proxy proxy)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            var handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler") ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler.UseProxy, Is.True);
            Assert.That(((WebProxy)handler.Proxy).Address, Is.EqualTo(proxy.Uri));
            Assert.That((NetworkCredential)handler.Proxy.Credentials, Is.Null);
        }

        private static void AssertProxyAndAuthentication(DefaultConnection connection, Proxy proxy)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            var handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler") ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler.UseProxy, Is.True);
            Assert.That(((WebProxy)handler.Proxy).Address, Is.EqualTo(proxy.Uri));
            Assert.That((NetworkCredential)handler.Proxy.Credentials, Is.Not.Null);
            Assert.That(((NetworkCredential)handler.Proxy.Credentials).UserName, Is.EqualTo(proxy.Username));
            Assert.That(((NetworkCredential)handler.Proxy.Credentials).Password, Is.EqualTo(proxy.Password));
        }

        private static void AssertNonCustomHandler(DefaultConnection connection)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            var handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler") ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
            Assert.That(handler, Is.Not.InstanceOf<CustomHttpClientHandler>());
        }

        private static void AssertCustomHandler(DefaultConnection connection)
        {
            var httpClientProvider = (Func<HttpClient>)connection.GetPrivateField("_httpClientProvider");
            var httpClient = httpClientProvider();
            var handler = (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("handler") ?? (HttpClientHandler)httpClient.GetPrivateField<HttpMessageInvoker>("_handler");
            Assert.That(handler, Is.InstanceOf<CustomHttpClientHandler>());
        }

        [TestCase]
        public void TestConstructWithProxyWithoutAuthentication()
        {
            var proxy = new Proxy { Uri = new Uri("http://test-proxy")};

            var connection = new DefaultConnection(SocketTimeout, MaxConnections, proxy);
            AssertConnectTimeout(connection);
            AssertProxy(connection, proxy);
            AssertNonCustomHandler(connection);
        }

        [TestCase]
        public void TestConstructWithProxyWithAuthentication()
        {
            var proxy = new Proxy { Uri = new Uri("http://test-proxy") , Username = "test-username", Password = "test-password" };

            var connection = new DefaultConnection(SocketTimeout, MaxConnections, proxy);
            AssertConnectTimeout(connection);
            AssertProxyAndAuthentication(connection, proxy);
            AssertNonCustomHandler(connection);
        }

        [TestCase]
        public void TestConstructWithProxyWithAuthenticationWithHandler()
        {
            var proxy = new Proxy { Uri = new Uri("http://test-proxy"), Username = "test-username", Password = "test-password" };

            var handler = new CustomHttpClientHandler();

            var connection = new DefaultConnection(SocketTimeout, MaxConnections, proxy, handler);
            AssertConnectTimeout(connection);
            AssertProxyAndAuthentication(connection, proxy);
            AssertCustomHandler(connection);
        }

        [TestCase, Ignore("Not implemented because max connections is not testable")]
        public void TestConstructWithMaxConnectionsWithoutProxy()
        {
            throw new NotImplementedException();
        }

        [TestCase, Ignore("Not implemented because max connections is not testable")]
        public void TestConstructWithMaxConnectionsWithProxy()
        {
            throw new NotImplementedException();
        }
    }
}
