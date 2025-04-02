using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Online Payments platform factory for several SDK components.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates a <see cref="CommunicatorConfiguration"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        /// <returns>The communicator configuration that can still be changed.</returns>
        public static CommunicatorConfiguration CreateConfiguration(string apiKeyId, string secretApiKey)
        {
            var configurationSection = System.Configuration.ConfigurationManager.GetSection("OnlinePaymentsSdk") as CommunicatorConfigurationSection;
            if (configurationSection == null)
            {
                throw new InvalidOperationException("Unable to load configuration");
            }
            var configuration = new CommunicatorConfiguration(configurationSection);
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
        /// Creates a <see cref="CommunicatorConfiguration"/> based on the configuration
        /// values in <c>configurationDictionary</c>, <c>apiKeyId</c> and <c>secretApiKey</c>.
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
        /// Creates a <see cref="CommunicatorBuilder"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static CommunicatorBuilder CreateCommunicatorBuilder(string apiKeyId, string secretApiKey)
        {
            var configuration = CreateConfiguration(apiKeyId, secretApiKey);
            return CreateCommunicatorBuilder(configuration);
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorBuilder"/> based on the configuration
        /// values in <c>configurationDictionary</c>, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static CommunicatorBuilder CreateCommunicatorBuilder(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            return CreateCommunicatorBuilder(CreateConfiguration(configurationDictionary, apiKeyId, secretApiKey));
        }

        /// <summary>
        /// Creates a <see cref="CommunicatorBuilder"/> based on the passed configuration.
        /// </summary>
        public static CommunicatorBuilder CreateCommunicatorBuilder(CommunicatorConfiguration configuration)
        {
            return new CommunicatorBuilder()
                    .WithApiEndpoint(configuration.ApiEndpoint)
                    .WithConnection(new DefaultConnection(
                            configuration.SocketTimeout,
                            // connect timeout not supported
                            configuration.MaxConnections,
                            configuration.Proxy,
                            configuration.HttpClientHandler
                    ))
                    .WithMetadataProvider(
                        new MetadataProviderBuilder(configuration.Integrator)
                        {
                            ShoppingCartExtension = configuration.ShoppingCartExtension
                        }.Build()
                    )
                    .WithAuthenticator(GetAuthenticator(configuration))
                    .WithMarshaller(DefaultMarshaller.Instance);
        }

        private static IAuthenticator GetAuthenticator(CommunicatorConfiguration configuration)
        {
            var authorizationType = configuration.AuthorizationType;
            if (authorizationType == AuthorizationType.V1HMAC)
            {
                return new V1HmacAuthenticator(configuration);
            }

            throw new InvalidOperationException("Unknown authorizationType " + authorizationType);
         }


        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static ICommunicator CreateCommunicator(string apiKeyId, string secretApiKey)
        {
            var configuration = CreateConfiguration(apiKeyId, secretApiKey);
            return CreateCommunicator(configuration);

        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the configuration values
        /// <c>configurationDictionary</c>, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="configurationDictionary">Dictionary containing configuration.</param>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static ICommunicator CreateCommunicator(IDictionary<string, string> configurationDictionary, string apiKeyId, string secretApiKey)
        {
            var configuration = CreateConfiguration(configurationDictionary, apiKeyId, secretApiKey);
            return CreateCommunicator(configuration);
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed configuration.
        /// </summary>
        public static ICommunicator CreateCommunicator(CommunicatorConfiguration configuration)
        {
            var communicatorBuilder = CreateCommunicatorBuilder(configuration);
            return communicatorBuilder.Build();
        }

        /// <summary>
        /// Creates a <see cref="ICommunicator"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The payment platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metadataProvider">The <see cref="IMetadataProvider"/> to use.</param>
        public static ICommunicator CreateCommunicator(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, IMetadataProvider metadataProvider)
        {
            return new Communicator(apiEndpoint, connection, authenticator, metadataProvider, DefaultMarshaller.Instance);
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the configuration values in
        /// your <c>app.conf</c> or <c>web.conf</c> file, <c>apiKeyId</c> and <c>secretApiKey</c>.
        /// </summary>
        /// <param name="apiKeyId">The API key identifier.</param>
        /// <param name="secretApiKey">The secret API key.</param>
        public static IClient CreateClient(string apiKeyId, string secretApiKey)
        {
            return CreateClient(CreateCommunicator(apiKeyId, secretApiKey));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the configuration values in
        /// <c>configurationDictionary</c>, <c>apiKeyId</c> and <c>secretApiKey</c>.
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
        /// Creates a <see cref="Client"/> based on the passed fields.
        /// </summary>
        /// <param name="apiEndpoint">The payment platform API endpoint URI to use.</param>
        /// <param name="connection">The <see cref="IConnection"/> to use.</param>
        /// <param name="authenticator">The <see cref="IAuthenticator"/> to use.</param>
        /// <param name="metadataProvider">The <see cref="IMetadataProvider"/> to use.</param>
        public static IClient CreateClient(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, IMetadataProvider metadataProvider)
        {
            return CreateClient(CreateCommunicator(apiEndpoint, connection, authenticator, metadataProvider));
        }

        /// <summary>
        /// Creates a <see cref="Client"/> based on the passed communicator.
        /// </summary>
        /// <param name="communicator">The shared communicator to use.</param>
        public static IClient CreateClient(ICommunicator communicator)
        {
            return new Client(communicator);
        }
    }
}
