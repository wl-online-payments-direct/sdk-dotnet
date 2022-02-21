/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderLineDetails
    {
        /// <summary>
        /// Discount on the line item, with the last two digits implied as decimal places<para />
        /// </summary>
        public long? DiscountAmount { get; set; } = null;

        /// <summary>
        /// Product or UPC Code<para />
        /// </summary>
        public string ProductCode { get; set; } = null;

        /// <summary>
        /// The name of the product.<para />
        /// </summary>
        public string ProductName { get; set; } = null;

        /// <summary>
        /// The price of one unit of the product, the value should be zero or greater<para />
        /// </summary>
        public long? ProductPrice { get; set; } = null;

        /// <summary>
        /// Code used to classify items that are purchased<para />
        /// </summary>
        public string ProductType { get; set; } = null;

        /// <summary>
        /// Quantity of the units being purchased, should be greater than zero<para />
        /// Note: Must not be all spaces or all zeros<para />
        /// </summary>
        public long? Quantity { get; set; } = null;

        /// <summary>
        /// Tax on the line item, with the last two digits implied as decimal places<para />
        /// </summary>
        public long? TaxAmount { get; set; } = null;

        /// <summary>
        /// Indicates the line item unit of measure; for example: each, kit, pair, gallon, month, etc.<para />
        /// </summary>
        public string Unit { get; set; } = null;
    }
}
