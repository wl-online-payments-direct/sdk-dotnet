using System;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Builder for a <see cref="Communicator"/> object.
    /// </summary>
    public class CommunicatorBuilder
    {
        private Uri _apiEndpoint;
        private IConnection _connection;
        private MetaDataProvider _metaDataProvider;
        private IAuthenticator _authenticator;
        private IMarshaller _marshaller;

        /// <summary>
        /// Sets the payment platform API endpoint URI to use.
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
        /// Sets the <see cref="MetaDataProvider"/> to use.
        /// </summary>
        /// <param name="metaDataProvider">Meta data provider.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithMetaDataProvider(MetaDataProvider metaDataProvider)
        {
            _metaDataProvider = metaDataProvider;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="IMarshaller"/> to use.
        /// </summary>
        /// <param name="marshaller">Marshaller.</param>
        /// <returns>This.</returns>
        public CommunicatorBuilder WithMarshaller(IMarshaller marshaller)
        {
            _marshaller = marshaller;
            return this;
        }

        /// <summary>
        /// Creates a fully initialized <see cref="Communicator"/> object.
        /// </summary>
        /// <exception cref="ArgumentException">if not all required components are set</exception>
        public Communicator Build()
        {
            return new Communicator(
                _apiEndpoint,
                _connection,
                _authenticator,
                _metaDataProvider,
                _marshaller
            );
        }
    }
}
