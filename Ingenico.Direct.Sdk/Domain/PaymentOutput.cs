/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Amount that has been paid<para />
        /// </summary>
        public long? AmountPaid { get; set; } = null;

        /// <summary>
        /// Object containing the card payment method details<para />
        /// </summary>
        public CardPaymentMethodSpecificOutput CardPaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Object containing the mobile payment method details<para />
        /// </summary>
        public MobilePaymentMethodSpecificOutput MobilePaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        /// <summary>
        /// Object containing the redirect payment product details<para />
        /// </summary>
        public RedirectPaymentMethodSpecificOutput RedirectPaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;

        /// <summary>
        /// Object containing the SEPA direct debit details<para />
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificOutput SepaDirectDebitPaymentMethodSpecificOutput { get; set; } = null;
    }
}
