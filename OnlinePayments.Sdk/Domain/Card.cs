/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Card
    {
        /// <summary>
        /// The complete credit/debit card number (also know as the PAN)
        /// The card number is always obfuscated in any of our responses
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The card holder's name on the card.
        /// </summary>
        public string CardholderName { get; set; }

        /// <summary>
        /// Card Verification Value, a 3 or 4 digit code used as an additional security feature for card not present transactions.
        /// </summary>
        public string Cvv { get; set; }

        /// <summary>
        /// Expiry date of the card
        /// Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}
