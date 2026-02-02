/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInputForHostedCheckout
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Hosted Checkout will show Click to Pay, with cards grouped as one payment method</description></item>
        ///   <item><description>false - Default - Hosted Checkout will show cards as separate payment methods without Click to Pay</description></item>
        /// </list>
        /// </summary>
        public bool? ClickToPay { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Hosted Checkout will allow to show cards grouped as one payment method</description></item>
        ///   <item><description>false - Default - Hosted Checkout will show cards as separate payment methods</description></item>
        /// </list>
        /// </summary>
        public bool? GroupCards { get; set; }

        /// <summary>
        /// This array contains the payment product identifiers representing the brands. For co-badged cards, this displays their available brands in the order defined by this array, when groupCards is activated.
        /// </summary>
        public IList<int?> PaymentProductPreferredOrder { get; set; }

        /// <summary>
        /// Controls the generation and use of a token within a hosted checkout session.
        /// <list type="bullet">
        ///   <item><description>createWithConsent - Presents the payer with a capture consent checkbox to decide whether they would like to tokenize their payment information for future use.</description></item>
        ///   <item><description>createAlways - Tokenizes the payment information automatically without presenting the capture consent checkbox to the payer; please ensure consent is captured on your interface.</description></item>
        ///   <item><description>useExplicitly - The payer can only use the token supplied in cardpaymentmethodspecificinput.token; if the token is invalid or no token is provided, the request will fail.</description></item>
        ///   <item><description>noTokenization - The payer's payment information will not be tokenized and the payer will not be presented with the ability to tokenize their payment information; use this for one-off payments.
        /// Note: This property is not allowed when cardpaymentmethodspecificinput.tokenize is specified.</description></item>
        /// </list>
        /// </summary>
        public string TokenizationMode { get; set; }
    }
}
