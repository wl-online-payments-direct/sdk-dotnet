using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.DefaultImpl;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Payment platform factory for several SDK components.
    /// </summary>
    public sealed class Factory
    {
        /// <summary>
        /// Creates a <see cref="CommunicatorConfiguration"/> based on the provided values.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the payment platform.</param>
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
            return new CommunicatorConfiguration(configurationDictionary)
                .WithApiKeyId(apiKeyId)
                .WithSecretApiKey(secretApiKey);
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorBuilder"/> based on the provided values.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the payment platform.</param>
        /// <param name="integrator">The integrator of the SDK.</param>
        /// <returns>The communicator builder that can still be changed.</returns>
        public static CommunicatorBuilder CreateCommunicatorBuilder(string apiKeyId, string secretApiKey, Uri apiEndpoint, String integrator)
        {
            CommunicatorConfiguration configuration = CreateConfiguration(apiKeyId, secretApiKey, apiEndpoint, integrator);
            return CreateCommunicatorBuilder(configuration);
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorBuilder"/> based on the configuration
        /// values in <c>configurationDictionary</c>, <c>apiKeyId</c> and
        /// <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <returns>The communicator builder that can still be changed.</returns>
        public static CommunicatorBuilder CreateCommunicatorBuilder(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            CommunicatorConfiguration configuration = CreateConfiguration(configurationDictionary, apiKeyId, secretApiKey);
            return CreateCommunicatorBuilder(configuration);
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorBuilder"/> based on the passed configuration.
        /// </summary>
        /// <returns>The communicator builder that can still be changed.</returns>
        public static CommunicatorBuilder CreateCommunicatorBuilder(CommunicatorConfiguration configuration)
        {
            MetaDataProvider metaDataProvider = new MetaDataProviderBuilder(configuration.Integrator)
                .WithShoppingCartExtension(configuration.ShoppingCartExtension)
                .Build();
            return new CommunicatorBuilder()
                .WithApiEndpoint(configuration.ApiEndpoint)
                .WithConnection(new DefaultConnection(
                    configuration.ProxyConfiguration,
                    configuration.SocketTimeout,
                    // connection timeout not supported
                    configuration.MaxConnections))
                .WithAuthenticator(new DefaultAuthenticator(
                    configuration.AuthorizationType,
                    configuration.ApiKeyId,
                    configuration.SecretApiKey
                ))
                .WithMarshaller(DefaultMarshaller.Instance)
                .WithMetaDataProvider(metaDataProvider);
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file,
        /// <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <param name="apiEndpoint">The URI of the payment platform.</param>
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
            return CreateCommunicatorBuilder(configurationDictionary, apiKeyId, secretApiKey)
                .Build();
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed configuration.
        /// </summary>
        public static ICommunicator CreateCommunicator(CommunicatorConfiguration configuration)
        {
            return CreateCommunicatorBuilder(configuration)
                .Build();
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The payment platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metaDataProvider">The <see cref="MetaDataProvider"/> to use.</param>
        public static ICommunicator CreateCommunicator(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, MetaDataProvider metaDataProvider)
        {
            return CreateCommunicator(apiEndpoint, connection, authenticator, metaDataProvider, DefaultMarshaller.Instance);
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The payment platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metaDataProvider">The <see cref="MetaDataProvider"/> to use.</param>
        /// <param name="marshaller">The <see cref="IMarshaller"/> to use.</param>
        public static ICommunicator CreateCommunicator(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, MetaDataProvider metaDataProvider, IMarshaller marshaller)
        {
            return new CommunicatorBuilder()
                .WithApiEndpoint(apiEndpoint)
                .WithConnection(connection)
                .WithMetaDataProvider(metaDataProvider)
                .WithAuthenticator(authenticator)
                .WithMarshaller(marshaller)
                .Build();
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The payment platform API endpoint URI to use.</param>
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
        /// <param name="apiEndpoint">The URI of the payment platform.</param>
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
