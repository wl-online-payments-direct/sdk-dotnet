/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Card
    {
        /// <summary>
        /// The complete credit/debit card number (also know as the PAN)<para />
        /// The card number is always obfuscated in any of our responses<para />
        /// </summary>
        public string CardNumber { get; set; } = null;

        /// <summary>
        /// The card holder's name on the card.<para />
        /// </summary>
        public string CardholderName { get; set; } = null;

        /// <summary>
        /// Card Verification Value, a 3 or 4 digit code used as an additional security feature for card not present transactions.<para />
        /// </summary>
        public string Cvv { get; set; } = null;

        /// <summary>
        /// Expiry date of the card<para />
        /// Format: MMYY<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}
