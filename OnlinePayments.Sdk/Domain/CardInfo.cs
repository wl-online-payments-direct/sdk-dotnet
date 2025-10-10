/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardInfo
    {
        /// <summary>
        /// The complete credit/debit card number (also known as the PAN) is always obfuscated in any of our responses.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
