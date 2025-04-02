/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderLineDetails
    {
        /// <summary>
        /// Discount on the line item, with the last two digits implied as decimal places
        /// </summary>
        public long? DiscountAmount { get; set; }

        /// <summary>
        /// The brand of the product.
        /// </summary>
        public string ProductBrand { get; set; }

        /// <summary>
        /// Product or UPC Code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The price of one unit of the product, the value should be zero or greater
        /// </summary>
        public long? ProductPrice { get; set; }

        /// <summary>
        /// Code used to classify items that are purchased
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Quantity of the units being purchased, should be greater than zero
        /// Note: Must not be all spaces or all zeros
        /// </summary>
        public long? Quantity { get; set; }

        /// <summary>
        /// Tax on the line item, with the last two digits implied as decimal places
        /// </summary>
        public long? TaxAmount { get; set; }

        /// <summary>
        /// Indicates the line item unit of measure; for example: each, kit, pair, gallon, month, etc.
        /// </summary>
        public string Unit { get; set; }
    }
}
