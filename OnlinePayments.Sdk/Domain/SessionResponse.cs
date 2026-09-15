/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class SessionResponse
    {
        /// <summary>
        /// The datacenter-specific base url for assets. This value needs to be passed to the Client SDK to make sure that the client software connects to the right datacenter.
        /// </summary>
        public string AssetUrl { get; set; }

        /// <summary>
        /// The datacenter-specific base url for client requests. This value needs to be passed to the Client SDK to make sure that the client software connects to the right datacenter.
        /// </summary>
        public string ClientApiUrl { get; set; }

        /// <summary>
        /// The identifier of the session that has been created.
        /// </summary>
        public string ClientSessionId { get; set; }

        /// <summary>
        /// The session is built up around the customer in the form of the customerId. All client APIs use this customerId in the URI to identify the customer.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Tokens that are submitted in the request are validated. In case any of the tokens can't be used anymore they are returned in this array. You should most likely remove those tokens from your system.
        /// </summary>
        public IList<string> InvalidTokens { get; set; }
    }
}
