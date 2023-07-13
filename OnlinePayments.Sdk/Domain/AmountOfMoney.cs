/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AmountOfMoney
    {
        /// <summary>
        /// Amount in the smallest currency unit, i.e.:<para />
        /// * EUR is a 2-decimals currency, the value 1234 will result in EUR 12.34<para />
        /// * KWD is a 3-decimals currency, the value 1234 will result in KWD 1.234<para />
        /// * JPY is a zero-decimal currency, the value 1234 will result in JPY 1234<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount<para />
        /// </summary>
        public string CurrencyCode { get; set; } = null;
    }
}
