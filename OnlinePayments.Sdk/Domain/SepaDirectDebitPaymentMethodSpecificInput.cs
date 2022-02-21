/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificInput
    {
        /// <summary>
        /// Object containing information specific to SEPA Direct Debit<para />
        /// </summary>
        public SepaDirectDebitPaymentProduct771SpecificInput PaymentProduct771SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
