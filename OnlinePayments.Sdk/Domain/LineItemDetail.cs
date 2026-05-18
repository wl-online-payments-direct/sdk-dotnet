/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LineItemDetail
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
        /// The unique ID for each line item.
        /// </summary>
        public string LineItemId { get; set; }

        /// <summary>
        /// Quantity of the units being purchased, should be greater than zero Note: Must not be all spaces or all zeros
        /// </summary>
        public long? Quantity { get; set; }
    }
}
