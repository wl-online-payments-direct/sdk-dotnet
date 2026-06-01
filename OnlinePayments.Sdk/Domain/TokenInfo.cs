/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenInfo
    {
        /// <summary>
        /// The expiry date of the network token.
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Temporary tokens have a lifespan of two hours and can only be used once.
        /// </summary>
        public bool? IsTemporary { get; set; }

        /// <summary>
        /// The masked Primary Account Number (PAN).
        /// </summary>
        public string MaskedPan { get; set; }

        /// <summary>
        /// ID of the token
        /// </summary>
        public string TokenId { get; set; }
    }
}
