/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class ShoppingCart
    {
        public IList<AmountBreakdown> AmountBreakdown { get; set; } = null;

        public GiftCardPurchase GiftCardPurchase { get; set; } = null;

        public bool? IsPreOrder { get; set; } = null;

        public IList<LineItem> Items { get; set; } = null;

        public string PreOrderItemAvailabilityDate { get; set; } = null;

        public bool? ReOrderIndicator { get; set; } = null;
    }
}
