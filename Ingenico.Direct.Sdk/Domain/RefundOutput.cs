/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundOutput
    {
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public long? AmountPaid { get; set; } = null;

        public RefundCardMethodSpecificOutput CardRefundMethodSpecificOutput { get; set; } = null;

        public RefundEWalletMethodSpecificOutput EWalletRefundMethodSpecificOutput { get; set; } = null;

        public RefundMobileMethodSpecificOutput MobileRefundMethodSpecificOutput { get; set; } = null;

        public string PaymentMethod { get; set; } = null;

        public RefundRedirectMethodSpecificOutput RedirectRefundMethodSpecificOutput { get; set; } = null;

        public PaymentReferences References { get; set; } = null;
    }
}
