using NUnit.Framework;
using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk;

[TestFixture]
public class CommunicatorConfigurationTest
{
    private const string BaseUriHost = "payment.preprod.online-payments.com";
    private const string AuthType = "v1HMAC";

    [TestCase]
    public void CommunicatorConfiguration_WithoutProxy_SetsExpectedDefaults()
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
    public void CommunicatorConfiguration_WithProxyAndNoAuthentication_SetsProxyWithoutCredentials()
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
    public void CommunicatorConfiguration_WithProxyAndAuthentication_SetsProxyWithCredentials()
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
    public void CommunicatorConfiguration_WithHttpsProxy_SetsProxyWithHttpsScheme()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.host"] = BaseUriHost,
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000",
            ["onlinePayments.api.proxy.uri"] = "https://proxy.example.org:443"
        };

        CommunicatorConfiguration configuration = new(properties);

        var proxy = configuration.Proxy;
        Assert.That(proxy, Is.Not.Null);
        Assert.That(proxy.Uri.Scheme, Is.EqualTo("https"));
        Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.org"));
        Assert.That(proxy.Uri.Port, Is.EqualTo(443));
        Assert.That(proxy.Username, Is.Null);
        Assert.That(proxy.Password, Is.Null);
    }

    [TestCase]
    public void CommunicatorConfiguration_WithMaxConnections_SetsConfiguredMaxConnections()
    {
        var configuration = CreateBasicConfiguration()
            .WithMaxConnections(100);

        AssertBasicConfigurationSettings(configuration);
        Assert.That(configuration.MaxConnections, Is.EqualTo(100));
        Assert.That(configuration.ApiKeyId, Is.Null);
        Assert.That(configuration.SecretApiKey, Is.Null);
    }

    [TestCase]
    public void CommunicatorConfiguration_WithHostAndScheme_SetsEndpointWithConfiguredScheme()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.scheme"] = "http",
            ["onlinePayments.api.endpoint.host"] = BaseUriHost,
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000"
        };

        CommunicatorConfiguration configuration = new(properties);

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"http://{BaseUriHost}")));
    }

    [TestCase]
    public void CommunicatorConfiguration_WithHostAndPort_SetsEndpointWithConfiguredPort()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.port"] = "8443",
            ["onlinePayments.api.endpoint.host"] = BaseUriHost,
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000"
        };

        CommunicatorConfiguration configuration = new(properties);

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"https://{BaseUriHost}:8443")));
    }

    [TestCase]
    public void CommunicatorConfiguration_WithHostSchemeAndPort_SetsEndpointWithConfiguredSchemeAndPort()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.port"] = "8080",
            ["onlinePayments.api.endpoint.host"] = BaseUriHost,
            ["onlinePayments.api.endpoint.scheme"] = "http",
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000"
        };

        CommunicatorConfiguration configuration = new(properties);

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri($"http://{BaseUriHost}:8080")));
    }

    [TestCase]
    public void CommunicatorConfiguration_WithIPv6Host_SetsBracketedHttpsEndpoint()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.host"] = "::1",
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000"
        };

        CommunicatorConfiguration configuration = new(properties);

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri("https://[::1]")));
    }

    [TestCase]
    public void CommunicatorConfiguration_WithIntegrator_SetsIntegrator()
    {
        Dictionary<string, string> properties = new() {
            ["onlinePayments.api.endpoint.host"] = BaseUriHost,
            ["onlinePayments.api.authorizationType"] = AuthType,
            ["onlinePayments.api.connectTimeout"] = "20000",
            ["onlinePayments.api.socketTimeout"] = "10000",
            ["onlinePayments.api.integrator"] = "OnlinePayments.Integrator"
        };

        CommunicatorConfiguration configuration = new(properties);

        Assert.That(configuration.Integrator, Is.EqualTo("OnlinePayments.Integrator"));
    }

    [Test]
    public void CommunicatorConfiguration_WhenDefaultConstructed_CreatesValidInstance()
    {
        CommunicatorConfiguration configuration = new();

        Assert.That(configuration, Is.Not.Null);
    }

    [Test]
    public void CommunicatorConfiguration_WhenDefaultConstructed_HasDefaultPropertyValues()
    {
        CommunicatorConfiguration configuration = new();

        Assert.That(configuration.ApiEndpoint, Is.Null);
        Assert.That(configuration.ApiKeyId, Is.Null);
        Assert.That(configuration.SecretApiKey, Is.Null);
        Assert.That(configuration.ConnectTimeout, Is.Null);
        Assert.That(configuration.SocketTimeout, Is.Null);
        Assert.That(configuration.MaxConnections, Is.EqualTo(CommunicatorConfiguration.DefaultMaxConnections));
        Assert.That(configuration.Proxy, Is.Null);
        Assert.That(configuration.Integrator, Is.Null);
        Assert.That(configuration.ShoppingCartExtension, Is.Null);
    }

    [Test]
    public void WithApiEndpoint_WithValidEndpoint_ReturnsSelf()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithApiEndpoint(new Uri("https://payment.example.com"));

        Assert.That(result, Is.SameAs(configuration));
    }

    [Test]
    public void WithApiKeyId_WithValue_ReturnsSelfAndSetsApiKeyId()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithApiKeyId("api-key-id");

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ApiKeyId, Is.EqualTo("api-key-id"));
    }

    [Test]
    public void WithSecretApiKey_WithValue_ReturnsSelfAndSetsSecretApiKey()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithSecretApiKey("secret-key");

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.SecretApiKey, Is.EqualTo("secret-key"));
    }

    [Test]
    public void WithAuthorizationType_WithValue_ReturnsSelfAndSetsAuthorizationType()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithAuthorizationType(AuthorizationType.V1HMAC);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
    }

    [Test]
    public void WithConnectTimeout_WithValue_ReturnsSelfAndSetsConnectTimeout()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithConnectTimeout(20000);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ConnectTimeout?.TotalMilliseconds, Is.EqualTo(20000));
    }

    [Test]
    public void WithSocketTimeout_WithValue_ReturnsSelfAndSetsSocketTimeout()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithSocketTimeout(10000);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.SocketTimeout?.TotalMilliseconds, Is.EqualTo(10000));
    }

    [Test]
    public void WithMaxConnections_WithValue_ReturnsSelfAndSetsMaxConnections()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithMaxConnections(50);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.MaxConnections, Is.EqualTo(50));
    }

    [Test]
    public void WithProxyUri_WithValue_ReturnsSelfAndSetsProxyUri()
    {
        CommunicatorConfiguration configuration = new();
        Uri proxyUri = new("https://proxy.example.com:3128");
        var result = configuration.WithProxyUri(proxyUri);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ProxyUri, Is.EqualTo(proxyUri));
    }

    [Test]
    public void WithProxyUserName_WithValue_ReturnsSelfAndSetsProxyUserName()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithProxyUserName("proxy-user");

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ProxyUserName, Is.EqualTo("proxy-user"));
    }

    [Test]
    public void WithProxyPassword_WithValue_ReturnsSelfAndSetsProxyPassword()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithProxyPassword("proxy-pass");

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ProxyPassword, Is.EqualTo("proxy-pass"));
    }

    [Test]
    public void WithIntegrator_WithValue_ReturnsSelfAndSetsIntegrator()
    {
        CommunicatorConfiguration configuration = new();
        var result = configuration.WithIntegrator("TestIntegrator");

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.Integrator, Is.EqualTo("TestIntegrator"));
    }

    [Test]
    public void WithShoppingCartExtension_WithValue_ReturnsSelfAndSetsShoppingCartExtension()
    {
        CommunicatorConfiguration configuration = new();
        ShoppingCartExtension extension = new("Creator", "Name", "1.0");
        var result = configuration.WithShoppingCartExtension(extension);

        Assert.That(result, Is.SameAs(configuration));
        Assert.That(configuration.ShoppingCartExtension, Is.SameAs(extension));
    }

    [Test]
    public void CommunicatorConfiguration_WhenFluentChained_SetsAllValues()
    {
        ShoppingCartExtension extension = new("Creator", "Name", "1.0");

        var configuration = new CommunicatorConfiguration()
            .WithApiEndpoint(new Uri("https://payment.example.com"))
            .WithApiKeyId("api-key-id")
            .WithSecretApiKey("secret-key")
            .WithAuthorizationType(AuthorizationType.V1HMAC)
            .WithConnectTimeout(20000)
            .WithSocketTimeout(10000)
            .WithMaxConnections(100)
            .WithProxyUri(new Uri("https://proxy.example.com:3128"))
            .WithProxyUserName("proxy-user")
            .WithProxyPassword("proxy-pass")
            .WithIntegrator("TestIntegrator")
            .WithShoppingCartExtension(extension);

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(new Uri("https://payment.example.com")));
        Assert.That(configuration.ApiKeyId, Is.EqualTo("api-key-id"));
        Assert.That(configuration.SecretApiKey, Is.EqualTo("secret-key"));
        Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
        Assert.That(configuration.ConnectTimeout?.TotalMilliseconds, Is.EqualTo(20000));
        Assert.That(configuration.SocketTimeout?.TotalMilliseconds, Is.EqualTo(10000));
        Assert.That(configuration.MaxConnections, Is.EqualTo(100));
        Assert.That(configuration.ProxyUri, Is.EqualTo(new Uri("https://proxy.example.com:3128")));
        Assert.That(configuration.ProxyUserName, Is.EqualTo("proxy-user"));
        Assert.That(configuration.ProxyPassword, Is.EqualTo("proxy-pass"));
        Assert.That(configuration.Integrator, Is.EqualTo("TestIntegrator"));
        Assert.That(configuration.ShoppingCartExtension, Is.SameAs(extension));
    }

    [Test]
    public void ApiEndpoint_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new();
        Uri endpoint = new("https://payment.example.com");

        configuration.ApiEndpoint = endpoint;

        Assert.That(configuration.ApiEndpoint, Is.EqualTo(endpoint));
    }

    [Test]
    public void ApiEndpoint_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            ApiEndpoint = null
        };

        Assert.That(configuration.ApiEndpoint, Is.Null);
    }

    [Test]
    public void ApiKeyId_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            ApiKeyId = "test-api-key-id"
        };

        Assert.That(configuration.ApiKeyId, Is.EqualTo("test-api-key-id"));
    }

    [Test]
    public void ApiKeyId_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            ApiKeyId = null
        };

        Assert.That(configuration.ApiKeyId, Is.Null);
    }

    [Test]
    public void SecretApiKey_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            SecretApiKey = "test-secret-key"
        };

        Assert.That(configuration.SecretApiKey, Is.EqualTo("test-secret-key"));
    }

    [Test]
    public void SecretApiKey_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            SecretApiKey = null
        };

        Assert.That(configuration.SecretApiKey, Is.Null);
    }

    [Test]
    public void AuthorizationType_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            AuthorizationType = AuthorizationType.V1HMAC
        };

        Assert.That(configuration.AuthorizationType, Is.EqualTo(AuthorizationType.V1HMAC));
    }

    [Test]
    public void AuthorizationType_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            AuthorizationType = null
        };

        Assert.That(configuration.AuthorizationType, Is.Null);
    }

    [Test]
    public void ConnectTimeout_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            ConnectTimeout = TimeSpan.FromMilliseconds(20000)
        };

        Assert.That(configuration.ConnectTimeout?.TotalMilliseconds, Is.EqualTo(20000));
    }

    [Test]
    public void ConnectTimeout_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            ConnectTimeout = null
        };

        Assert.That(configuration.ConnectTimeout, Is.Null);
    }

    [Test]
    public void SocketTimeout_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            SocketTimeout = TimeSpan.FromMilliseconds(10000)
        };

        Assert.That(configuration.SocketTimeout?.TotalMilliseconds, Is.EqualTo(10000));
    }

    [Test]
    public void SocketTimeout_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            SocketTimeout = null
        };

        Assert.That(configuration.SocketTimeout, Is.Null);
    }

    [Test]
    public void MaxConnections_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            MaxConnections = 50
        };

        Assert.That(configuration.MaxConnections, Is.EqualTo(50));
    }

    [Test]
    public void Proxy_WhenProxyUriIsNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            ProxyUri = null
        };

        Assert.That(configuration.Proxy, Is.Null);
    }

    [Test]
    public void Integrator_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new()        {
            Integrator = "TestIntegrator"
        };

        Assert.That(configuration.Integrator, Is.EqualTo("TestIntegrator"));
    }

    [Test]
    public void Integrator_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            Integrator = null
        };

        Assert.That(configuration.Integrator, Is.Null);
    }

    [Test]
    public void ShoppingCartExtension_WhenAssigned_ReturnsAssignedValue()
    {
        CommunicatorConfiguration configuration = new();
        ShoppingCartExtension extension = new("Creator", "Name", "1.0");

        configuration.ShoppingCartExtension = extension;

        Assert.That(configuration.ShoppingCartExtension, Is.SameAs(extension));
    }

    [Test]
    public void ShoppingCartExtension_WhenAssignedNull_ReturnsNull()
    {
        CommunicatorConfiguration configuration = new()        {
            ShoppingCartExtension = null
        };

        Assert.That(configuration.ShoppingCartExtension, Is.Null);
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

    private static void AssertBasicProxySettings(Proxy proxy)
    {
        Assert.That(proxy.Uri.Scheme, Is.EqualTo("http"));
        Assert.That(proxy.Uri.Host, Is.EqualTo("proxy.example.org"));
        Assert.That(proxy.Uri.Port, Is.EqualTo(3128));
    }
}
