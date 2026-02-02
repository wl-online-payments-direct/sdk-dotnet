/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class NetworkTokenData
    {
        /// <summary>
        /// The card holder's name on the card associated with the Network Token.
        /// </summary>
        public string CardholderName { get; set; }

        /// <summary>
        /// The Token Cryptogram is a dynamic one-time use value that is used to verify the authenticity of the transaction and the integrity of the data used in the generation of the Token Cryptogram. Visa calls this the Token Authentication Verification Value (TAVV) cryptogram.
        /// </summary>
        public string Cryptogram { get; set; }

        /// <summary>
        /// The Electronic Commerce Indicator linked to the Token Cryptogram that is provided by the token service provider during the generation of the Token Cryptogram.
        /// </summary>
        public int? Eci { get; set; }

        /// <summary>
        /// Payment Token associated with the Card used for the purchase.
        /// Note: This is called Payment Token in the EMVCo documentation.
        /// </summary>
        public string NetworkToken { get; set; }

        /// <summary>
        /// Token Requestor Identifier used with the token service provider during the creation of the Network Token. Depending on the acquirer, this data might be required in the authorization request. We advise you to provide it for all Network Token initiated transactions.
        /// </summary>
        public string SchemeTokenRequestorId { get; set; }

        /// <summary>
        /// The expiry date of the network token.
        /// Format: MMYY
        /// </summary>
        public string TokenExpiryDate { get; set; }
    }
}
