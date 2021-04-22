/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk;
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for
    /// <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetProductDirectoryApi">Get payment product directory</a>
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
