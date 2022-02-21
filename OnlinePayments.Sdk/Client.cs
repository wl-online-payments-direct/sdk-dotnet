/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Logging;
using OnlinePayments.Sdk.Merchant;
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk
{
    /// <inheritdoc/>
    public class Client : ApiResource, IClient
    {
        public const string ApiVersion = "v2";

        public Client(ICommunicator communicator) : this(communicator, null)
        {
        }

        Client(ICommunicator communicator, string clientMetaInfo) :
            base(communicator, clientMetaInfo, null)
        {
        }

        /// <inheritdoc/>
        public Client WithClientMetaInfo(string clientMetaInfo)
        {
            if (_clientMetaInfo == null && clientMetaInfo == null)
            {
                return this;
            }
            else if (clientMetaInfo == null)
            {
                return new Client(_communicator, null);
            }
            else
            {
                // Checking to see if this is valid JSON (no JSON parse exceptions)
                _communicator.Unmarshal<object>(clientMetaInfo);
                clientMetaInfo = clientMetaInfo.ToBase64String();

                if (clientMetaInfo.Equals(_clientMetaInfo))
                {
                    return this;
                }
                else
                {
                    return new Client(_communicator, clientMetaInfo);
                }
            }
        }

        /// <inheritdoc/>
        public void CloseExpiredConnections()
        {
            _communicator.CloseExpiredConnections();
        }

        /// <inheritdoc/>
        public void CloseIdleConnections(TimeSpan timespan)
        {
            _communicator.CloseIdleConnections(timespan);
        }

        #region ILoggingCapable support
        public void EnableLogging(ICommunicatorLogger communicatorLogger)
        {
            // delegate to the communicator
            _communicator.EnableLogging(communicatorLogger);
        }

        public void DisableLogging()
        {
            // delegate to the communicator
            _communicator.DisableLogging();
        }
        #endregion

        #region IDisposable support
        /// <inheritdoc/>
        public void Dispose()
        {
            _communicator.Dispose();
        }
        #endregion

        /// <inheritdoc/>
        public IMerchantClient WithNewMerchant(string merchantId)
        {
            IDictionary<string, string> subContext = new Dictionary<string, string>
			{
				{ "merchantId", merchantId }
			};
            return new MerchantClient(this, subContext);
        }
    }
}
