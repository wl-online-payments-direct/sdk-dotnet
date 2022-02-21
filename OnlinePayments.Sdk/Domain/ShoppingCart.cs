/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ShoppingCart
    {
        /// <summary>
        /// Deprecated: Use order.shipping.shippingCost for shipping cost. Other amounts are not used.<para />
        /// Determines how the total amount is split into amount types<para />
        /// </summary>
        public IList<AmountBreakdown> AmountBreakdown { get; set; } = null;

        /// <summary>
        /// Object containing information on purchased gift card(s)<para />
        /// </summary>
        public GiftCardPurchase GiftCardPurchase { get; set; } = null;

        /// <summary>
        /// The customer is pre-ordering one or more items<para />
        /// </summary>
        public bool? IsPreOrder { get; set; } = null;

        /// <summary>
        /// Shopping cart data<para />
        /// </summary>
        public IList<LineItem> Items { get; set; } = null;

        /// <summary>
        /// Date (YYYYMMDD) when the preordered item becomes available<para />
        /// </summary>
        public string PreOrderItemAvailabilityDate { get; set; } = null;

        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased item(s)<para />
        /// <para />
        /// true = the customer is re-ordering at least one of the items again<para />
        /// <para />
        /// false = this is the first time the customer is ordering these items<para />
        /// </summary>
        public bool? ReOrderIndicator { get; set; } = null;
    }
}
