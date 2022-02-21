/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardWithoutCvv
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
        /// Expiry date of the card<para />
        /// Format: MMYY<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}
