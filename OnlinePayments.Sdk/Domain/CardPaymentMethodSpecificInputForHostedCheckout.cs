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
    }
}
