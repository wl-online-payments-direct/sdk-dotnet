/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardWithoutCvv
    {
        /// <summary>
        /// The obfuscated card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The card holder's name on the card.
        /// </summary>
        public string CardholderName { get; set; }

        /// <summary>
        /// Expiry date of the card
        /// Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}
