using System;
using System.Collections.Generic;
using Ingenico.Direct.Sdk.DefaultImpl;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Ingenico ePayments platform factory for several SDK components.
    /// </summary>
    public sealed class Factory
    {
        /// <summary>
        /// Creates a <see cref="CommunicatorConfiguration"/> based on the provided values.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the Direct API.</param>
        /// <param name="integrator">The integrator of the SDK.</param>
        /// <returns>The communicator configuration that can still be changed.</returns>
        public static CommunicatorConfiguration CreateConfiguration(string apiKeyId, string secretApiKey, Uri apiEndpoint, String integrator)
        {
            return new CommunicatorConfiguration()
                .WithApiEndpoint(apiEndpoint)
                .WithApiKeyId(apiKeyId)
                .WithSecretApiKey(secretApiKey)
                .WithIntegrator(integrator);
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorConfiguration"/> based on the configuration
        /// values in <c>configurationDictionary</c>, <c>apiKeyId</c> and
        /// <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <returns>The communicator configuration that can still be changed.</returns>
        public static CommunicatorConfiguration CreateConfiguration(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            var configuration = new CommunicatorConfiguration(configurationDictionary);
            if (apiKeyId != null)
            {
                configuration.ApiKeyId = apiKeyId;
            }
            if (secretApiKey != null)
            {
                configuration.SecretApiKey = secretApiKey;
            }
            return configuration;
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file,
        /// <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the Direct API.</param>
        /// <param name="integrator">The integrator of the SDK.</param>
        public static ICommunicator CreateCommunicator(string apiKeyId, string secretApiKey, Uri apiEndpoint, String integrator)
        {
            CommunicatorConfiguration configuration = CreateConfiguration(apiKeyId, secretApiKey, apiEndpoint, integrator);
            return CreateCommunicator(configuration);
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the configuration values
        /// <c>configurationDictionary</c>, <c>apiKeyId</c> and
        /// <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static ICommunicator CreateCommunicator(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            CommunicatorConfiguration configuration = CreateConfiguration(configurationDictionary, apiKeyId, secretApiKey);
            return CreateCommunicator(configuration);
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed configuration.
        /// </summary>
        public static ICommunicator CreateCommunicator(CommunicatorConfiguration configuration)
        {
            return CreateCommunicator(
                configuration.ApiEndpoint,
                new DefaultConnection(
                    configuration.SocketTimeout,
                    // connection timeout not supported
                    configuration.ProxyConfiguration,
                    configuration.MaxConnections),
                new DefaultAuthenticator(
                    configuration.AuthorizationType,
                            configuration.ApiKeyId,
                            configuration.SecretApiKey
                ),
                new MetaDataProviderBuilder(configuration.Integrator)
                    {
                        ShoppingCartExtension = configuration.ShoppingCartExtension
                    }.Build());
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The Ingenico ePayments platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metaDataProvider">The <see cref="MetaDataProvider"/> to use.</param>
        public static ICommunicator CreateCommunicator(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, MetaDataProvider metaDataProvider)
        {
            return new CommunicatorBuilder()
                .WithApiEndpoint(apiEndpoint)
                .WithConnection(connection)
                .WithMetaDataProvider(metaDataProvider)
                .WithAuthenticator(authenticator)
                .WithMarshaller(DefaultMarshaller.Instance)
                .Build();
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The Ingenico ePayments platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metaDataProvider">The <see cref="MetaDataProvider"/> to use.</param>
        public static IClient CreateClient(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, MetaDataProvider metaDataProvider)
        {
            return CreateClient(CreateCommunicator(apiEndpoint, connection, authenticator, metaDataProvider));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file,
        /// <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the Direct API.</param>
        /// <param name="integrator">The integrator of the SDK.</param>
        public static IClient CreateClient(string apiKeyId, string secretApiKey, Uri apiEndpoint, String integrator)
        {
            return CreateClient(CreateCommunicator(apiKeyId, secretApiKey, apiEndpoint, integrator));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the configuration values in
        /// <c>configurationDictionary</c>, <codecapiKeyId</c> and
        /// <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static IClient CreateClient(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            return CreateClient(CreateCommunicator(configurationDictionary, apiKeyId, secretApiKey));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the passed configuration.
        /// </summary>
        public static IClient CreateClient(CommunicatorConfiguration configuration)
        {
            return CreateClient(CreateCommunicator(configuration));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the passed communicator.
        /// </summary>
        /// <param name="communicator">The shared communicator to use.</param>
        public static IClient CreateClient(ICommunicator communicator)
        {
            return new Client(communicator);
        }

        Factory() { }
    }
}
