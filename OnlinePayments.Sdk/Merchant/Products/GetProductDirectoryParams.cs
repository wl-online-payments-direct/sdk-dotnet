/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for 'Get payment product directory'.
    /// </summary>
    public class GetProductDirectoryParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency of the transaction<para />
        /// </summary>
        public string CurrencyCode { get; set; } = null;

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            IList<RequestParam> result = new List<RequestParam>();
            if (CountryCode != null)
            {
                result.Add(new RequestParam("countryCode", CountryCode));
            }
            if (CurrencyCode != null)
            {
                result.Add(new RequestParam("currencyCode", CurrencyCode));
            }
            return result;
        }
    }
}
