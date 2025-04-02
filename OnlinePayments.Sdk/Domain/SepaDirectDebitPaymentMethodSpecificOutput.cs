/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Object containing the results of the fraud screening
        /// </summary>
        public FraudResults FraudResults { get; set; }

        /// <summary>
        /// Output that is SEPA Direct Debit specific (i.e. the used mandate)
        /// </summary>
        public PaymentProduct771SpecificOutput PaymentProduct771SpecificOutput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
