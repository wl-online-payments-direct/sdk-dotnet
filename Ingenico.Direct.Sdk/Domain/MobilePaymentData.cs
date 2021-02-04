/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class MobilePaymentData
    {
        /// <summary>
        /// The obfuscated DPAN. Only the last four digits are visible.<para />
        /// </summary>
        public string Dpan { get; set; } = null;

        /// <summary>
        /// Expiry date of the tokenized card. Format: MMYY<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}
