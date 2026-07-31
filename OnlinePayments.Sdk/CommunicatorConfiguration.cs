using System;
using System.Collections.Generic;
using System.Net.Http;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Configuration for the communicator.
    /// </summary>
    public class CommunicatorConfiguration
    {
        /// <summary>
        /// The default number of maximum connections
        /// </summary>
        public const int DefaultMaxConnections = 10;

        /// <summary>
        /// Gets or sets the Online Payments platform API endpoint URI.
        /// </summary>
        public Uri ApiEndpoint { get; set; }

        /// <summary>
        /// Gets or sets a SocketTimeout to be used by <see cref="DefaultConnection"/>.
        /// </summary>
        [Obsolete("SocketTimeout is not used when IHttpClientFactory is configured. " +
                  "Configure timeout via services.AddHttpClient(...).ConfigureHttpClient(c => c.Timeout = ...) instead.")]
        public TimeSpan? SocketTimeout { get; set; }

        /// <summary>
        /// Gets or sets the maximal number of connections
        /// </summary>
        [Obsolete("MaxConnections is not used when IHttpClientFactory is configured. " +
                  "Configure connection limits via SocketsHttpHandler.PooledConnectionLifetime during services.AddHttpClient(...) registration instead.")]
        public int MaxConnections { get; set; } = DefaultMaxConnections;

        /// <summary>
        /// Gets or sets the type of the authorization.
        /// </summary>
        public AuthorizationType AuthorizationType { get; set; } = AuthorizationType.V1HMAC;

        /// <summary>
        /// Gets or sets an identifier for the secret API key. The <c>apiKeyId</c> can be
        /// retrieved from the Configuration Center. This identifier is visible in
        /// the HTTP request and is also used to identify the correct account.
        /// </summary>
        public string ApiKeyId { get; set; }

        /// <summary>
        /// Gets or sets a shared secret. The shared secret can be retrieved from the
        /// Configuration Center. An <c>apiKeyId</c> and <c>secretApiKey</c> always
        /// go hand-in-hand, the difference is that <c>secretApiKey</c> is never
        /// visible in the HTTP request. This secret is used as input for the HMAC
        /// algorithm.
        /// </summary>
        public string SecretApiKey { get; set; }

        /// <summary>
        /// Gets the proxy object
        /// </summary>
        public Proxy Proxy => ProxyUri != null ? new Proxy { Username = ProxyUserName, Password = ProxyPassword, Uri = ProxyUri } : null;

        /// <summary>
        /// Gets or sets the proxy URI.
        /// </summary>
        [Obsolete("ProxyUri is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public Uri ProxyUri { get; set; }

        /// <summary>
        /// Gets or sets the proxy username.
        /// </summary>
        [Obsolete("ProxyUserName is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public string ProxyUserName { get; set; }

        /// <summary>
        /// Gets or sets the proxy password.
        /// </summary>
        [Obsolete("ProxyPassword is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public string ProxyPassword { get; set; }

        /// <summary>
        /// Gets or sets the integrator.
        /// </summary>
        public string Integrator { get; set; }

        /// <summary>
        /// Gets or sets the shoppingcart extension.
        /// </summary>
        public ShoppingCartExtension ShoppingCartExtension { get; set; }

        /// <summary>
        /// Gets or sets a custom HttpClientHandler to be used by <see cref="DefaultConnection"/>.
        /// </summary>
        [Obsolete("HttpClientHandler is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public HttpClientHandler HttpClientHandler { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IHttpClientFactory"/> to be used by <see cref="DefaultConnection"/>.
        /// When set, <see cref="DefaultConnection"/> will obtain an <see cref="System.Net.Http.HttpClient"/>
        /// from this factory per request instead of managing one internally.
        /// The factory manages handler lifetime, so <see cref="HttpClientName"/> may be used to select a
        /// named registration from <c>services.AddHttpClient(name, ...)</c>.
        /// </summary>
        public IHttpClientFactory HttpClientFactory { get; set; }

        /// <summary>
        /// Gets or sets the logical name of the <see cref="System.Net.Http.HttpClient"/> to request from
        /// <see cref="HttpClientFactory"/>. When <c>null</c> or empty, the unnamed default client is used.
        /// </summary>
        public string HttpClientName { get; set; }

        public CommunicatorConfiguration()
        {

        }

        public CommunicatorConfiguration(IDictionary<string, string> properties)
        {
            if (properties != null)
            {
                ApiEndpoint = GetApiEndpoint(properties);
                AuthorizationType = AuthorizationType.GetValueOf(GetProperty(properties, "onlinePayments.api.authorizationType"));

                var socketTimeout = int.Parse(GetProperty(properties, "onlinePayments.api.socketTimeout"));
                SocketTimeout = socketTimeout >= 0 ? (TimeSpan?)TimeSpan.FromMilliseconds(socketTimeout) : null;

                MaxConnections = GetProperty(properties, "onlinePayments.api.maxConnections", DefaultMaxConnections);

                var proxyUri = GetProperty(properties, "onlinePayments.api.proxy.uri");
                var proxyUser = GetProperty(properties, "onlinePayments.api.proxy.username");
                var proxyPass = GetProperty(properties, "onlinePayments.api.proxy.password");
                if (proxyUri != null)
                {
                    ProxyUri = new Uri(proxyUri);
                    ProxyUserName = proxyUser;
                    ProxyPassword = proxyPass;
                }

                Integrator = GetProperty(properties, "onlinePayments.api.integrator", "");
            }
        }

        internal CommunicatorConfiguration(CommunicatorConfigurationSection section)
        {
            ApiEndpoint = section.ApiEndpoint;
            SocketTimeout = section.SocketTimeout;
            MaxConnections = section.MaxConnections;
            AuthorizationType = AuthorizationType.GetValueOf(section.AuthorizationType);
            ApiKeyId = section.ApiKeyId;
            SecretApiKey = section.SecretApiKey;

            ProxyUri = section.ProxyConfiguration.Uri;
            ProxyUserName = section.ProxyConfiguration.Username;
            ProxyPassword = section.ProxyConfiguration.Password;

            Integrator = section.Integrator;
            ShoppingCartExtension = section.ShoppingCartExtension;
        }

        /// <summary>
        /// Returns this with the API endpoint assigned.
        /// </summary>
        /// <param name="apiEndpoint">API endpoint.</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithApiEndpoint(Uri apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            return this;
        }

        /// <summary>
        /// Returns this with the API key identifier assigned.
        /// </summary>
        /// <param name="apiKeyId">The API key id</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithApiKeyId(string apiKeyId)
        {
            ApiKeyId = apiKeyId;
            return this;
        }

        /// <summary>
        /// Returns this with the secret API key assigned.
        /// </summary>
        /// <param name="secretApiKey">Secret API key.</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithSecretApiKey(string secretApiKey)
        {
            SecretApiKey = secretApiKey;
            return this;
        }

        /// <summary>
        /// Returns this with the type of the authorization assigned.
        /// </summary>
        /// <param name="authorizationType">Authorization type.</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithAuthorizationType(AuthorizationType authorizationType)
        {
            AuthorizationType = authorizationType;
            return this;
        }

        /// <summary>
        /// Returns this with the the socket timeout assigned.
        /// </summary>
        /// <param name="socketTimeout">The socket timeout.</param>
        /// <returns>This.</returns>
        [Obsolete("WithSocketTimeout is not used when IHttpClientFactory is configured. " +
                  "Configure timeout via services.AddHttpClient(...).ConfigureHttpClient(c => c.Timeout = ...) instead.")]
        public CommunicatorConfiguration WithSocketTimeout(int socketTimeout)
        {
            SocketTimeout = TimeSpan.FromMilliseconds(socketTimeout);
            return this;
        }

        /// <summary>
        /// Returns this with the maximum number of connections assigned.
        /// </summary>
        /// <param name="maxConnections">The maximum number of connections.</param>
        /// <returns>This.</returns>
        [Obsolete("WithMaxConnections is not used when IHttpClientFactory is configured. " +
                  "Configure connection limits via SocketsHttpHandler.PooledConnectionLifetime during services.AddHttpClient(...) registration instead.")]
        public CommunicatorConfiguration WithMaxConnections(int maxConnections)
        {
            MaxConnections = maxConnections;
            return this;
        }

        /// <summary>
        /// Returns this with the proxy URI assigned.
        /// </summary>
        /// <param name="proxyUri">The proxy URI.</param>
        /// <returns>This.</returns>
        [Obsolete("WithProxyUri is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public CommunicatorConfiguration WithProxyUri(Uri proxyUri)
        {
            ProxyUri = proxyUri;
            return this;
        }

        /// <summary>
        /// Returns this with the proxy username assigned.
        /// </summary>
        /// <param name="proxyName">The proxy username.</param>
        /// <returns>This.</returns>
        [Obsolete("WithProxyUserName is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public CommunicatorConfiguration WithProxyUserName(string proxyName)
        {
            ProxyUserName = proxyName;
            return this;
        }

        /// <summary>
        /// Returns this with the proxy password assigned.
        /// </summary>
        /// <param name="proxyPassword">The proxy password.</param>
        /// <returns>This.</returns>
        [Obsolete("WithProxyPassword is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public CommunicatorConfiguration WithProxyPassword(string proxyPassword)
        {
            ProxyPassword = proxyPassword;
            return this;
        }

        /// <summary>
        /// Returns this with the integrator assigned.
        /// </summary>
        /// <param name="integrator">The integrator.</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithIntegrator(string integrator)
        {
            Integrator = integrator;
            return this;
        }

        /// <summary>
        /// Returns this with the shopping cart extension assigned.
        /// </summary>
        /// <param name="shoppingCartExtension">The shopping cart extension.</param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithShoppingCartExtension(ShoppingCartExtension shoppingCartExtension)
        {
            ShoppingCartExtension = shoppingCartExtension;
            return this;
        }

        /// <summary>
        /// Returns this with a custom HttpClientHandler assigned.
        /// </summary>
        /// <param name="httpClientHandler">The custom HttpClientHandler.</param>
        /// <returns>This.</returns>
        [Obsolete("WithHttpClientHandler is not used when IHttpClientFactory is configured. " +
                  "Configure the HTTP handler via services.AddHttpClient(...).ConfigurePrimaryHttpMessageHandler(...) instead.")]
        public CommunicatorConfiguration WithHttpClientHandler(HttpClientHandler httpClientHandler)
        {
            HttpClientHandler = httpClientHandler;
            return this;
        }

        /// <summary>
        /// Returns this with an <see cref="IHttpClientFactory"/> assigned.
        /// When set, <see cref="DefaultConnection"/> obtains <see cref="System.Net.Http.HttpClient"/> instances
        /// from the factory per request. This is the recommended approach for ASP.NET Core applications.
        /// </summary>
        /// <param name="httpClientFactory">The factory to use.</param>
        /// <param name="clientName">
        /// The logical name of the client to create. When <c>null</c> or empty, the default unnamed client is used.
        /// </param>
        /// <returns>This.</returns>
        public CommunicatorConfiguration WithHttpClientFactory(IHttpClientFactory httpClientFactory, string clientName = null)
        {
            HttpClientFactory = httpClientFactory;
            HttpClientName = clientName;
            return this;
        }

        private static string GetProperty(IDictionary<string, string> properties, string name, string defaultValue = null)
        {
            return properties.TryGetValue(name, out var value) ? value : defaultValue;
        }

        private static int GetProperty(IDictionary<string, string> properties, string key, int defaultValue)
        {
            var propertyValue = GetProperty(properties, key);
            return int.TryParse(propertyValue, out var propertyInt) ? propertyInt : defaultValue;
        }

        private static Uri GetApiEndpoint(IDictionary<string, string> properties)
        {
            var host = GetProperty(properties, "onlinePayments.api.endpoint.host", "");
            var scheme = GetProperty(properties, "onlinePayments.api.endpoint.scheme", "https");
            var port = GetProperty(properties, "onlinePayments.api.endpoint.port", -1);

            return CreateUri(scheme, host, port);

        }

        private static Uri CreateUri(string scheme, string host, int port)
        {
            try
            {
                return new UriBuilder(scheme: scheme, host: host, portNumber: port).Uri;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentException("Unable to construct API endpoint URI", e);
            }
        }
    }
}
