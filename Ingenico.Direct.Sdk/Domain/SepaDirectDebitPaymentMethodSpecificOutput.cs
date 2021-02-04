/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class SepaDirectDebitPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Object containing the results of the fraud screening<para />
        /// </summary>
        public FraudResults FraudResults { get; set; } = null;

        public PaymentProduct771SpecificOutput PaymentProduct771SpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see [payment products](https://support.direct.ingenico.com/documentation/api/reference/index.html#tag/Products) for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
