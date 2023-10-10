/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardInfo
    {
        /// <summary>
        /// Provide the complete credit/debit card number (also known as the PAN) for the most accurate results.<para />
        /// </summary>
        public string CardNumber { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
