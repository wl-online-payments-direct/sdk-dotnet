/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class Acceptance
    {
        /// <summary>
        /// Worldline application identifier used to transmit the authorization request. This data is transmitted as provided in the authorization request and in the response. It is named ITP (Terminal Application Identification at the Point of Acceptance) in the CB2A protocol.
        /// </summary>
        public string AcceptanceSystemApplicationId { get; set; }

        /// <summary>
        /// It is the authorization processing date and time of the transaction.
        /// </summary>
        public DateTimeOffset? AuthorizationDate { get; set; }

        /// <summary>
        /// Identifier shared with the acquirer during the authorization process. For example, this reference data could be sent by the acquirer in the authorization response, then sent (unchanged) in a subsequent authorization reversal message, to the extent that the acquirer is able to match a reversal message to the associated response message.
        /// </summary>
        public string AuthorizationMessageReference { get; set; }
    }
}
