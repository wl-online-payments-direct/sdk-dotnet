/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificInput
    {
        /// <summary>
        /// Object containing information specific to SEPA Direct Debit
        /// </summary>
        public SepaDirectDebitPaymentProduct771SpecificInput PaymentProduct771SpecificInput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
