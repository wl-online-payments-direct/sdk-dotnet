/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Ingenico.Direct.Sdk.Logging;
using Ingenico.Direct.Sdk.Merchant;
using System;
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Ingenico ePayments platform client. Thread-safe.
    ///
    /// This client and all its child clients are bound to one specific value for the <i>X-GCS-ClientMetaInfo</i> header.
    /// To get a new client with a different header value, use <see cref="WithClientMetaInfo"/>.
    /// </summary>
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

        /// <summary>
        /// Returns a new Client which uses the passed meta data for the <i>X-GCS-ClientMetaInfo</i> header.
        /// </summary>
        /// <param name="clientMetaInfo">JSON string containing the meta data for the client</param>
        /// <exception cref="MarshallerSyntaxException">if the given clientMetaInfo is not a valid JSON string</exception>
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

        /// <summary>
        /// Utility method that delegates the call to this client's communicator.
        /// </summary>
        public void CloseExpiredConnections()
        {
            _communicator.CloseExpiredConnections();
        }

        /// <summary>
        /// Utility method that delegates the call to this client's communicator.
        /// </summary>
        /// <param name="timespan">Idle time.</param>
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
        /// <summary>
        /// Releases any system resources associated with this object.
        /// </summary>
        public void Dispose()
        {
            _communicator.Dispose();
        }
        #endregion

        /// <summary>
        /// Resource /v2/{merchantId}
        /// </summary>
        /// <param name="merchantId">string</param>
        /// <returns>MerchantClient</returns>
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