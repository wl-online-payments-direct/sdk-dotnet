using System;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Builder for a <see cref="ICommunicator"/> object.
    /// </summary>
    public class CommunicatorBuilder
    {
        /// <summary>
        /// Sets the Online Payments platform API endpoint URI to use.
        /// </summary>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithApiEndpoint(Uri apiEndpoint)
        {
            _apiEndpoint = apiEndpoint;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IConnection"/> to use.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithConnection(IConnection connection)
        {
            _connection = connection;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IAuthenticator"/> to use.
        /// </summary>
        /// <param name="authenticator">The authenticator.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithAuthenticator(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IMetadataProvider"/> to use.
        /// </summary>
        /// <param name="metadataProvider">The meta data provider.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithMetadataProvider(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IMarshaller"/> to use.
        /// </summary>
        /// <param name="marshaller">The marshaller.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithMarshaller(IMarshaller marshaller)
        {
            _marshaller = marshaller;
            return this;
        }

        /// <summary>
        /// Creates a fully initialized <see cref="ICommunicator"/> object.
        /// </summary>
        /// <exception cref="ArgumentException">if not all required components are set</exception>
        public ICommunicator Build()
        {
            return new Communicator(
                _apiEndpoint,
                _connection,
                _authenticator,
                _metadataProvider,
                _marshaller
            );
        }

        private Uri _apiEndpoint;

        private IConnection _connection;

        private IMetadataProvider _metadataProvider;

        private IAuthenticator _authenticator;

        private IMarshaller _marshaller;
    }
}
