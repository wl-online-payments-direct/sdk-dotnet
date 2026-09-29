/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ShippingDetail
    {
        /// <summary>
        /// Amount in the smallest currency unit, i.e.:
        /// <list type="bullet">
        ///   <item><description>EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34</description></item>
        ///   <item><description>KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234</description></item>
        ///   <item><description>JPY is a zero-decimal currency, the value 1234 will result in JPY 1234</description></item>
        /// </list>
        /// </summary>
        public long? ShippingCost { get; set; }

        /// <summary>
        /// Amount in the smallest currency unit, i.e.:
        /// <list type="bullet">
        ///   <item><description>EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34</description></item>
        ///   <item><description>KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234</description></item>
        ///   <item><description>JPY is a zero-decimal currency, the value 1234 will result in JPY 1234</description></item>
        /// </list>
        /// </summary>
        public long? ShippingCostTax { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingDetail WithShippingCost(long? value)
        {
            ShippingCost = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingDetail WithShippingCostTax(long? value)
        {
            ShippingCostTax = value;
            return this;
        }
    }
}
