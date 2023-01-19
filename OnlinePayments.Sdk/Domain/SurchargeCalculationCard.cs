/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeCalculationCard
    {
        /// <summary>
        /// The complete credit/debit card number (also know as the PAN)<para />
        /// The card number is always obfuscated in any of our responses<para />
        /// </summary>
        public string CardNumber { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
