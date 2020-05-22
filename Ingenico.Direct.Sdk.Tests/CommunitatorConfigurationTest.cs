using NUnit.Framework;
using System;
using System.Collections.Generic;
using Ingenico.Direct.Sdk.DefaultImpl;

namespace Ingenico.Direct.Sdk
{
    [TestFixture]
    public class CommunitatorConfigurationTest
    {
        const string BaseUriHost = "payment.preprod.direct.ingenico.com";
        const string AuthType = "v1HMAC";

        [TestCase]
        public void TestConstructFromPropertiesWithoutProxy()
        {
            CommunicatorConfiguration configuration = CreateBasicConfiguration();

            AssertBasicConfigurationSettings(configuration);
            Assert.AreEqual(CommunicatorConfiguration.DefaultMaxConnections, configuration.MaxConnections);
            Assert.Null(configuration.ApiKeyId);
            Assert.Null(configuration.SecretApiKey);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithProxyWithoutAuthentication()
        {
            CommunicatorConfiguration configuration = CreateBasicConfiguration()
                .WithProxyUri(new Uri("http://proxy.example.org:3128"));

            AssertBasicConfigurationSettings(configuration);
            Assert.AreEqual(CommunicatorConfiguration.DefaultMaxConnections, configuration.MaxConnections);
            Assert.Null(configuration.ApiKeyId);
            Assert.Null(configuration.SecretApiKey);

            Assert.NotNull(configuration.ProxyConfiguration);
            ProxyConfiguration proxyFig = configuration.ProxyConfiguration;
            AssertBasicProxySettings(proxyFig);
            Assert.That(proxyFig.Username, Is.Empty);
            Assert.That(proxyFig.Password, Is.Empty);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithProxyWithAuthentication()
        {
            CommunicatorConfiguration configuration = CreateBasicConfiguration()
                                                   .WithProxyUri(new Uri("http://proxy.example.org:3128"))
                                                   .WithProxyUserName("direct-username")
                                                   .WithProxyPassword("direct-password");

            AssertBasicConfigurationSettings(configuration);
            Assert.AreEqual(CommunicatorConfiguration.DefaultMaxConnections, configuration.MaxConnections);
            Assert.Null(configuration.ApiKeyId);
            Assert.Null(configuration.SecretApiKey);

            Assert.NotNull(configuration.ProxyConfiguration);
            ProxyConfiguration proxyFig = configuration.ProxyConfiguration;
            AssertBasicProxySettings(proxyFig);
            Assert.AreEqual("direct-username", proxyFig.Username);
            Assert.AreEqual("direct-password", proxyFig.Password);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithMaxConnections()
        {
            CommunicatorConfiguration configuration = CreateBasicConfiguration()
                                                            .WithMaxConnections(100);

            AssertBasicConfigurationSettings(configuration);
            Assert.AreEqual(100, configuration.MaxConnections);
            Assert.Null(configuration.ApiKeyId);
            Assert.Null(configuration.SecretApiKey);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostAndScheme()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties["direct.api.endpoint.scheme"] = "http";
            properties["direct.api.endpoint.host"] = BaseUriHost;
            properties["direct.api.authorizationType"] = AuthType;
            properties["direct.api.connectTimeout"] = "20000";
            properties["direct.api.socketTimeout"] = "10000";

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(properties);

            Assert.AreEqual(new Uri("http://" + BaseUriHost), configuration.ApiEndpoint);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostAndPort()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties["direct.api.endpoint.port"] = "8443";
            properties["direct.api.endpoint.host"] = BaseUriHost;
            properties["direct.api.authorizationType"] = AuthType;
            properties["direct.api.connectTimeout"] = "20000";
            properties["direct.api.socketTimeout"] = "10000";

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(properties);

            Assert.AreEqual(new Uri("https://" + BaseUriHost + ":8443"), configuration.ApiEndpoint);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithHostSchemeAndPort()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties["direct.api.endpoint.port"] = "8080";
            properties["direct.api.endpoint.host"] = BaseUriHost;
            properties["direct.api.endpoint.scheme"] = "http";
            properties["direct.api.authorizationType"] = AuthType;
            properties["direct.api.connectTimeout"] = "20000";
            properties["direct.api.socketTimeout"] = "10000";

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(properties);

            Assert.AreEqual(new Uri("http://" + BaseUriHost + ":8080"), configuration.ApiEndpoint);
        }

        [TestCase]
        public void TestConstructFromPropertiesWithIPv6Host()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties["direct.api.endpoint.host"] = "::1";
            properties["direct.api.authorizationType"] = AuthType;
            properties["direct.api.connectTimeout"] = "20000";
            properties["direct.api.socketTimeout"] = "10000";

            CommunicatorConfiguration configuration = new CommunicatorConfiguration(properties);

            Assert.AreEqual(new Uri("https://[::1]"), configuration.ApiEndpoint);
        }

        CommunicatorConfiguration CreateBasicConfiguration()
        {
            return new CommunicatorConfiguration()
                .WithApiEndpoint(new Uri("https://" + BaseUriHost))
                .WithAuthorizationType(AuthorizationType.V1HMAC)
                .WithConnectTimeout(20000)
                .WithSocketTimeout(10000);
        }

        void AssertBasicConfigurationSettings(CommunicatorConfiguration configuration)
        {
            Assert.AreEqual(new Uri("https://" + BaseUriHost), configuration.ApiEndpoint);
            Assert.AreEqual(AuthorizationType.V1HMAC, configuration.AuthorizationType);
            Assert.AreEqual(20000, configuration.ConnectTimeout?.TotalMilliseconds);
            Assert.AreEqual(10000, configuration.SocketTimeout?.TotalMilliseconds);
        }

        /// <summary>
        /// Checks validity of basic proxy settings of a proxy with uri http://proxy.example.org:3128.
        /// </summary>
        /// <param name="proxyFig">Proxy fig.</param>
        void AssertBasicProxySettings(ProxyConfiguration proxyFig)
        {
            Assert.AreEqual("http", proxyFig.Scheme);
            Assert.AreEqual("proxy.example.org", proxyFig.Host);
            Assert.AreEqual(3128, proxyFig.Port);
        }
    }
}

