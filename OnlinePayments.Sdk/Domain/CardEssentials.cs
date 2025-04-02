/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardEssentials
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// The masked credit/debit card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Expiry date of the card
        /// Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}
