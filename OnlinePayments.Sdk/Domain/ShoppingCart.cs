/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ShoppingCart
    {
        /// <summary>
        /// Deprecated: Use order.shipping.shippingCost for shipping cost. Other amounts are not used.
        /// Determines how the total amount is split into amount types
        /// </summary>
        [Obsolete("Use order.shipping.shippingCost for shipping cost. Other amounts are not used. Determines how the total amount is split into amount types")]
        public IList<AmountBreakdown> AmountBreakdown { get; set; }

        /// <summary>
        /// Object containing information on purchased gift card(s)
        /// </summary>
        public GiftCardPurchase GiftCardPurchase { get; set; }

        /// <summary>
        /// The customer is pre-ordering one or more items
        /// </summary>
        public bool? IsPreOrder { get; set; }

        /// <summary>
        /// Shopping cart data
        /// </summary>
        public IList<LineItem> Items { get; set; }

        /// <summary>
        /// Date (YYYYMMDD) when the preordered item becomes available
        /// </summary>
        public string PreOrderItemAvailabilityDate { get; set; }

        /// <summary>
        /// Indicates whether the cardholder is reordering previously purchased item(s)
        /// <p />
        /// true = the customer is re-ordering at least one of the items again
        /// <p />
        /// false = this is the first time the customer is ordering these items
        /// </summary>
        public bool? ReOrderIndicator { get; set; }
    }
}
