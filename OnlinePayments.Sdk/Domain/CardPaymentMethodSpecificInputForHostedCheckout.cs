/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInputForHostedCheckout
    {
        /// <summary>
        /// * true - Hosted Checkout will allow to show cards grouped as one payment method<para />
        /// * false - Default - Hosted Checkout will show cards as separate payment methods<para />
        /// </summary>
        public bool? GroupCards { get; set; } = null;

        /// <summary>
        /// This array contains the payment product identifiers representing the brands. For co-badged cards, this displays their available brands in the order defined by this array, when groupCards is activated.<para />
        /// </summary>
        public IList<int?> PaymentProductPreferredOrder { get; set; } = null;
    }
}
