/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class SessionResponse
    {
        /// <summary>
        /// The datacenter-specific base url for assets. This value needs to be passed to the Client SDK to make sure that the client software connects to the right datacenter.<para />
        /// </summary>
        public string AssetUrl { get; set; } = null;

        /// <summary>
        /// The datacenter-specific base url for client requests. This value needs to be passed to the Client SDK to make sure that the client software connects to the right datacenter.<para />
        /// </summary>
        public string ClientApiUrl { get; set; } = null;

        /// <summary>
        /// The identifier of the session that has been created.<para />
        /// </summary>
        public string ClientSessionId { get; set; } = null;

        /// <summary>
        /// The session is built up around the customer in the form of the customerId. All client APIs use this customerId in the URI to identify the customer.<para />
        /// </summary>
        public string CustomerId { get; set; } = null;

        /// <summary>
        /// Tokens that are submitted in the request are validated. In case any of the tokens can't be used anymore they are returned in this array. You should most likely remove those tokens from your system.<para />
        /// </summary>
        public IList<string> InvalidTokens { get; set; } = null;
    }
}
