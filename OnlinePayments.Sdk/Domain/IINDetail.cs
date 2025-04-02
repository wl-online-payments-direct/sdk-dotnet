/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class IINDetail
    {
        /// <summary>
        /// The card's type as categorised by the payment method. Possible values are:
        /// <list type="bullet">
        ///   <item><description>Credit</description></item>
        ///   <item><description>Debit</description></item>
        ///   <item><description>Prepaid</description></item>
        /// </list>
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Populated only if you submitted a payment context.
        /// <list type="bullet">
        ///   <item><description>true - The payment product is allowed in the submitted context.</description></item>
        ///   <item><description>false - The payment product is not allowed in the submitted context. Note that in this case, none of the brands of the card will be allowed in the submitted context.</description></item>
        /// </list>
        /// </summary>
        public bool? IsAllowedInContext { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
