/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificInputBase
    {
        /// <summary>
        /// Object containing information specific to SEPA Direct Debit<para />
        /// </summary>
        public SepaDirectDebitPaymentProduct771SpecificInputBase PaymentProduct771SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
