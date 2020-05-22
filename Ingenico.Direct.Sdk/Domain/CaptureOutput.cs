/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CaptureOutput
    {
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public long? AmountPaid { get; set; } = null;

        public CardPaymentMethodSpecificOutput CardPaymentMethodSpecificOutput { get; set; } = null;

        public MobilePaymentMethodSpecificOutput MobilePaymentMethodSpecificOutput { get; set; } = null;

        public string PaymentMethod { get; set; } = null;

        public RedirectPaymentMethodSpecificOutput RedirectPaymentMethodSpecificOutput { get; set; } = null;

        public PaymentReferences References { get; set; } = null;

        public SepaDirectDebitPaymentMethodSpecificOutput SepaDirectDebitPaymentMethodSpecificOutput { get; set; } = null;
    }
}
