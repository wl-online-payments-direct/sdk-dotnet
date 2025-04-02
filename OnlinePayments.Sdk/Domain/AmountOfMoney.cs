/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AmountOfMoney
    {
        /// <summary>
        /// Amount in the smallest currency unit, i.e.:
        /// <list type="bullet">
        ///   <item><description>EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34</description></item>
        ///   <item><description>KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234</description></item>
        ///   <item><description>JPY is a zero-decimal currency, the value 1234 will result in JPY 1234</description></item>
        /// </list>
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount
        /// </summary>
        public string CurrencyCode { get; set; }
    }
}
