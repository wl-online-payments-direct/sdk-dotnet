/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct840SpecificInput
    {
        /// <summary>
        /// Indicates whether to use PayPal Express Checkout Shortcut.<para />
        ///  * true = When shortcut is enabled, the consumer can select a shipping address during PayPal checkout.<para />
        ///  * false = When shortcut is disabled, the consumer cannot change the shipping address.<para />
        /// Default value is false.<para />
        /// Please note that this field is ignored when order.additionalInput.typeInformation.purchaseType is set to "digital"<para />
        /// </summary>
        public bool? AddressSelectionAtPayPal { get; set; } = null;

        /// <summary>
        /// Free text field that you can use to support reconciliation flow.<para />
        /// </summary>
        public string Custom { get; set; } = null;
    }
}
