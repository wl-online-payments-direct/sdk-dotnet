/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class AmountOfMoney
    {
        /// <summary>
        /// Amount in cents and always having 2 decimals<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount<para />
        /// </summary>
        public string CurrencyCode { get; set; } = null;
    }
}
