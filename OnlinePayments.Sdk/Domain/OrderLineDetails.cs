/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderLineDetails
    {
        /// <summary>
        /// Amount in the smallest currency unit, i.e.:
        /// <list type="bullet">
        ///   <item><description>EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34</description></item>
        ///   <item><description>KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234</description></item>
        ///   <item><description>JPY is a zero-decimal currency, the value 1234 will result in JPY 1234</description></item>
        /// </list>
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
        /// Amount in the smallest currency unit, i.e.:
        /// <list type="bullet">
        ///   <item><description>EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34</description></item>
        ///   <item><description>KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234</description></item>
        ///   <item><description>JPY is a zero-decimal currency, the value 1234 will result in JPY 1234</description></item>
        /// </list>
        /// </summary>
        public long? TaxAmount { get; set; }

        /// <summary>
        /// Indicates the line item unit of measure; for example: each, kit, pair, gallon, month, etc.
        /// </summary>
        public string Unit { get; set; }
    }
}
