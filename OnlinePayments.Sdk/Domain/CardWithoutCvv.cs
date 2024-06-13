/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardWithoutCvv
    {
        /// <summary>
        /// The obfuscated card number<para />
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
