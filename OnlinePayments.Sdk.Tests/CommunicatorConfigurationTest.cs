using NUnit.Framework;
using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Authentication;

namespace OnlinePayments.Sdk
{
    [TestFixture]
    public class CommunicatorConfigurationTest
    {
        const string BaseUriHost = "payment.preprod.online-payments.com";
        private const string AuthType = "v1HMAC";

        [TestCase]
        public void TestConstructFromPropertiesWithoutProxy()
        {
            var configuration = CreateBasicConfiguration();

            AssertBasicConfigurationSettings(configuration);
            Assert.That(configuration.MaxConnections, Is.EqualTo(CommunicatorConfiguration.DefaultMaxConnections));
            Assert.That(configuration.ApiKeyId, Is.Null);
            Assert.That(configuration.SecretApiKey, Is.Null);

            Assert.That(configuration.Proxy, Is.Null);
            Assert.That(configuration.ProxyUri, Is.Null);
            Assert.That(configuration.ProxyUserName, Is.Null);
            Assert.That(configuration.ProxyPassword, Is.Null);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithProxyWithoutAuthentication()
        {
            var configuration = CreateBasicConfiguration()
                .WithProxyUri(new Uri("http://proxy.example.org:3128"));

            AssertBasicConfigurationSettings(configuration);
            Assert.That(configuration.MaxConnections, Is.EqualTo(CommunicatorConfiguration.DefaultMaxConnections));
            Assert.That(configuration.ApiKeyId, Is.Null);
            Assert.That(configuration.SecretApiKey, Is.Null);

            var proxy = configuration.Proxy;
            Assert.That(proxy, Is.Not.Null);
            AssertBasicProxySettings(proxy);
            Assert.That(proxy.Username, Is.Null);
            Assert.That(proxy.Password, Is.Null);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithProxyWithAuthentication()
        {
            var configuration = CreateBasicConfiguration()
                .WithProxyUri(new Uri("http://proxy.example.org:3128"))
                .WithProxyUserName("proxy-username")
                .WithProxyPassword("proxy-password");

            AssertBasicConfigurationSettings(configuration);
            Assert.That(configuration.MaxConnections, Is.EqualTo(CommunicatorConfiguration.DefaultMaxConnections));
            Assert.That(configuration.ApiKeyId, Is.Null);
            Assert.That(configuration.SecretApiKey, Is.Null);

            var proxy = configuration.Proxy;
            Assert.That(proxy, Is.Not.Null);
            AssertBasicProxySettings(proxy);
            Assert.That(proxy.Username, Is.EqualTo("proxy-username"));
            Assert.That(proxy.Password, Is.EqualTo("proxy-password"));
        }

        [TestCase]
        public void TestConstructFromPropertiesWithMaxConnections()
        {
            var configuration = CreateBasicConfiguration()
                .WithMaxConnections(100);

            AssertBasicConfigurationSettings(configuration);
            Assert.That(configuration.MaxConnections, Is.EqualTo(100));
            Assert.That(configuration.ApiKeyId, Is.Null);
            Assert.That(configuration.SecretApiKey, Is.Null);

            // In original tests was null, but not anymore, because of app config configuration
            //Assert.Null(configuration.ProxyConfiguration);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostAndScheme()
        {
            var properties = new Dictionary<string, string>
            {
                ["onlinePayments.api.endpoint.scheme"] = "http",
                ["onlinePayments.api.endpoint.host"] = BaseUriHost,
                ["onlinePayments.api.authorizationType"] = AuthType,
                ["onlinePayments.api.connectTimeout"] = "20000",
                ["onlinePayments.api.socketTimeout"] = "10000"
            };

            var configuration = new CommunicatorConfiguration(properties);

            Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"http://{BaseUriHost}")));
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostAndPort()
        {
            var properties = new Dictionary<string, string>
            {
                ["onlinePayments.api.endpoint.port"] = "8443",
                ["onlinePayments.api.endpoint.host"] = BaseUriHost,
                ["onlinePayments.api.authorizationType"] = AuthType,
                ["onlinePayments.api.connectTimeout"] = "20000",
                ["onlinePayments.api.socketTimeout"] = "10000"
            };

            var configuration = new CommunicatorConfiguration(properties);

            Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"https://{BaseUriHost}:8443")));
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostSchemeAndPort()
        {
            var properties = new Dictionary<string, string>
            {
                ["onlinePayments.api.endpoint.port"] = "8080",
                ["onlinePayments.api.endpoint.host"] = BaseUriHost,
                ["onlinePayments.api.endpoint.scheme"] = "http",
                ["onlinePayments.api.authorizationType"] = AuthType,
                ["onlinePayments.api.connectTimeout"] = "20000",
                ["onlinePayments.api.socketTimeout"] = "10000"
            };

            var configuration = new CommunicatorConfiguration(properties);

            Assert.That(configuration.ApiEndpoint, Is .EqualTo(new Uri($"http://{BaseUriHost}:8080")));
        }

        [TestCase]
        public void TestConstructFromPropertiesWithIPv6Host()
        {
            var properties = new Dictionary<string, string>
            {
                ["onlinePayments.api.endpoint.host"] = "::1",
                ["onlinePayments.api.authorizationType"] = AuthType,
                ["onlinePayments.api.connectTimeout"] = "20000",
                ["onlinePayments.api.socketTimeout"] = "10000"
            };

            var configuration = new CommunicatorConfiguration(properties);

            Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri("https://[::1]")));
        }

        private static CommunicatorConfiguration CreateBasicConfiguration()
        {
            return new CommunicatorConfiguration()
                .WithApiEndpoint(new Uri($"https://{BaseUriHost}"))
                .WithAuthorizationType(AuthorizationType.V1HMAC)
                .WithConnectTimeout(20000)
                .WithSocketTimeout(10000);
        }

        private static void AssertBasicConfigurationSettings(CommunicatorConfiguration configuration)
        {
            Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"https://{BaseUriHost}")));
            Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
            Assert.That(configuration.ConnectTimeout?.TotalMilliseconds, Is.EqualTo(20000));
            Assert.That(configuration.SocketTimeout?.TotalMilliseconds, Is.EqualTo(10000));
        }

        /// <summary>
        /// Checks validity of basic proxy settings of a proxy with uri http://proxy.example.org:3128.
        /// </summary>
        /// <param name="proxy">Proxy.</param>
        private static void AssertBasicProxySettings(Proxy proxy)
        {
            Assert.That(proxy.Uri.Scheme, Is.EqualTo("http"));
            Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.org"));
            Assert.That(proxy.Uri.Port, Is.EqualTo(3128));
        }
    }
}
