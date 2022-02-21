/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Object containing the results of the fraud screening<para />
        /// </summary>
        public FraudResults FraudResults { get; set; } = null;

        /// <summary>
        /// Output that is SEPA Direct Debit specific (i.e. the used mandate)<para />
        /// </summary>
        public PaymentProduct771SpecificOutput PaymentProduct771SpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
