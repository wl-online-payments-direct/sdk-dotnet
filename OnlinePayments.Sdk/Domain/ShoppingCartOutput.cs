/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ShoppingCartOutput
    {
        /// <summary>
        /// List of lineItemIds and quantities for capture/refund/cancellation.
        /// </summary>
        public IList<LineItemDetail> LineItemDetails { get; set; }
    }
}
