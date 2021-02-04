/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CustomerAccountAuthentication
    {
        /// <summary>
        /// Authentication used by the customer on your website<para />
        /// Possible values are<para />
        ///  * guest = no login occurred, customer is logged in as guest<para />
        ///  * merchant-credentials = the customer logged in using credentials that are specific to you<para />
        ///  * federated-id = the customer logged in using a federated ID<para />
        ///  * issuer-credentials = the customer logged in using credentials from the card issuer (of the card used in this transaction)<para />
        ///  * third-party-authentication = the customer logged in using third-party authentication<para />
        ///  * fido-authentication = the customer logged in using a FIDO authenticator<para />
        /// </summary>
        public string Method { get; set; } = null;

        /// <summary>
        /// Timestamp (YYYYMMDDHHmm) of the authentication of the customer to their account with you<para />
        /// </summary>
        public string UtcTimestamp { get; set; } = null;
    }
}
