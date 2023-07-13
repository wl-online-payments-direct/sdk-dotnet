/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class IINDetail
    {
        /// <summary>
        /// The card's type as categorised by the payment method. Possible values are:<para />
        ///   * Credit<para />
        ///   * Debit<para />
        ///   * Prepaid<para />
        /// </summary>
        public string CardType { get; set; } = null;

        /// <summary>
        /// Populated only if you submitted a payment context.<para />
        /// * true - The payment product is allowed in the submitted context.<para />
        /// * false - The payment product is not allowed in the submitted context. Note that in this case, none of the brands of the card will be allowed in the submitted context.<para />
        /// </summary>
        public bool? IsAllowedInContext { get; set; } = null;

        /// <summary>
        /// The payment product identifier associated with the card. If the card has multiple brands, then we select the most appropriate payment product based on your configuration and the payment context, if you submitted one.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
