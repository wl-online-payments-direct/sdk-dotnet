/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for
    /// Get payment product directory (/v2/{merchantId}/products/{paymentProductId}/directory)
    /// </summary>
    public class GetProductDirectoryParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetProductDirectoryParams WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Three-letter ISO currency code representing the currency of the transaction
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetProductDirectoryParams WithCurrencyCode(string value)
        {
            CurrencyCode = value;
            return this;
        }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
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
