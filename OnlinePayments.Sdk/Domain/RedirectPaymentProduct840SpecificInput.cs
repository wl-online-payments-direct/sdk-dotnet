/*
 * This file was automatically generated.
 */
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct840SpecificInput
    {
        /// <summary>
        /// To be enabled when Javascript SDK integration is implemented on S2S flow
        /// <list type="bullet">
        ///   <item><description>false = When this flag is disabled the field RedirectionURL is returned by CreatePayment call and should be used in merchant implementation to redirect buyer to PayPal.</description></item>
        ///   <item><description>true = When this flag is enabled the field orderID is returned by CreatePayment call and should be utilized in case merchant has integrated JS SDK button on their S2S implementation
        /// Default value is false.</description></item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "JavaScriptSdkFlow")]
        public bool? JavaScriptSdkFlow { get; set; }

        /// <summary>
        /// Indicates whether to use PayPal Express Checkout Shortcut.
        /// <list type="bullet">
        ///   <item><description>true = When shortcut is enabled, the consumer can select a shipping address during PayPal checkout.</description></item>
        ///   <item><description>false = When shortcut is disabled, the consumer cannot change the shipping address.
        /// Default value is false.
        /// Please note that this field is ignored when order.additionalInput.typeInformation.purchaseType is set to &quot;digital&quot;</description></item>
        /// </list>
        /// </summary>
        public bool? AddressSelectionAtPayPal { get; set; }

        /// <summary>
        /// Free text field that you can use to support reconciliation flow.
        /// </summary>
        public string Custom { get; set; }

        /// <summary>
        /// Indicates whether to allow PayPal Pay Later option.
        /// <list type="bullet">
        ///   <item><description>true = When option is enabled, the consumer can select the PayPal PayLater button given that the merchant meets the eligibility criteria from PayPal.</description></item>
        ///   <item><description>false = When option is disabled, the consumer cannot select the PayPal PayLater button.
        /// Default value is true.</description></item>
        /// </list>
        /// </summary>
        public bool? PayLater { get; set; }
    }
}
