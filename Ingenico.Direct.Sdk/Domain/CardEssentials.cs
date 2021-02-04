/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CardEssentials
    {
        /// <summary>
        /// The complete credit/debit card number<para />
        /// </summary>
        public string CardNumber { get; set; } = null;

        /// <summary>
        /// Expiry date of the card <para />
        ///  Format: MMYY<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}
