/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LineItemDetail
    {
        /// <summary>
        /// The unique ID for each line item.
        /// </summary>
        public string LineItemId { get; set; }

        /// <summary>
        /// Quantity of the units being purchased, should be greater than zero Note: Must not be all spaces or all zeros
        /// </summary>
        public long? Quantity { get; set; }
    }
}
