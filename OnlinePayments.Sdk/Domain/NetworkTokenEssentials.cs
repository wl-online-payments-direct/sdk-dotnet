/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class NetworkTokenEssentials
    {
        /// <summary>
        /// The first digits of the network token number from left to right with a minimum of 6 digits.<para />
        /// </summary>
        public string Bin { get; set; } = null;

        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// The masked Payment Token associated with the Card used for the purchase. <para />
        /// Note: This is called Payment Token in the EMVCo documentation.<para />
        /// </summary>
        public string NetworkToken { get; set; } = null;

        /// <summary>
        /// The expiry date of the network token.<para />
        /// Format: MMYY<para />
        /// </summary>
        public string TokenExpiryDate { get; set; } = null;
    }
}
