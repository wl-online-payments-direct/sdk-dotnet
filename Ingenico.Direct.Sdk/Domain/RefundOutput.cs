/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public long? AmountPaid { get; set; } = null;

        public RefundCardMethodSpecificOutput CardRefundMethodSpecificOutput { get; set; } = null;

        public RefundEWalletMethodSpecificOutput EWalletRefundMethodSpecificOutput { get; set; } = null;

        public RefundMobileMethodSpecificOutput MobileRefundMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        public RefundRedirectMethodSpecificOutput RedirectRefundMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;
    }
}
