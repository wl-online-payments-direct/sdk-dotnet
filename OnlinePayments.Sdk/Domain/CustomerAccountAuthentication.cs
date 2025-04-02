/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerAccountAuthentication
    {
        /// <summary>
        /// Data about the authentication procedure of the customer to their account with you
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Authentication used by the customer on your website
        /// Possible values are
        /// <list type="bullet">
        ///   <item><description>guest = no login occurred, customer is logged in as guest</description></item>
        ///   <item><description>merchant-credentials = the customer logged in using credentials that are specific to you</description></item>
        ///   <item><description>federated-id = the customer logged in using a federated ID</description></item>
        ///   <item><description>issuer-credentials = the customer logged in using credentials from the card issuer (of the card used in this transaction)</description></item>
        ///   <item><description>third-party-authentication = the customer logged in using third-party authentication</description></item>
        ///   <item><description>fido-authentication = the customer logged in using a FIDO authenticator</description></item>
        ///   <item><description>cico-b-connect-token = the customer logged in using Check-in/Check-out b.connect</description></item>
        /// </list>
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Timestamp (YYYYMMDDHHmm) of the authentication of the customer to their account with you
        /// </summary>
        public string UtcTimestamp { get; set; }
    }
}
