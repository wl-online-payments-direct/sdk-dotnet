/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentData
    {
        /// <summary>
        /// The obfuscated DPAN. Only the last four digits are visible.
        /// </summary>
        public string Dpan { get; set; }

        /// <summary>
        /// Expiry date of the tokenized card. Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}
