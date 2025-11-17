/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class NetworkTokenEssentials
    {
        /// <summary>
        /// The first digits of the network token number from left to right with a minimum of 6 digits.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The masked Payment Token associated with the Card used for the purchase.
        /// Note: This is called Payment Token in the EMVCo documentation.
        /// </summary>
        public string NetworkToken { get; set; }

        /// <summary>
        /// Describes the state of the linked network token:
        /// <list type="bullet">
        ///   <item><description>requested - A Network Token has been requested from the scheme.</description></item>
        ///   <item><description>denied - A Network Token request has been denied from the scheme.</description></item>
        ///   <item><description>active - The linked Network Token is active and can be used for the subsequent payment in the payment series.</description></item>
        ///   <item><description>suspended - The linked Network Token is suspended and can not be used for the subsequent payment in the payment series. Instead PAN details would be used for the subsequent payment in the payment series.</description></item>
        ///   <item><description>deleted - The linked Network Token is deleted and can not be used for the subsequent payment in the payment series. Instead PAN details would be used for the subsequent payment in the payment series.</description></item>
        ///   <item><description>failed - An attempt was made to request a Network Token, but it was not successful.</description></item>
        /// </list>
        /// </summary>
        public string NetworkTokenState { get; set; }

        /// <summary>
        /// Whether or not a network token was used in the transaction
        /// </summary>
        public bool? NetworkTokenUsed { get; set; }

        /// <summary>
        /// The expiry date of the network token.
        /// Format: MMYY
        /// </summary>
        public string TokenExpiryDate { get; set; }
    }
}
