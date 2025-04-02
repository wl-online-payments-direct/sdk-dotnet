/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for
    /// Get payment product networks (/v2/{merchantId}/products/{paymentProductId}/networks)
    /// </summary>
    public class GetPaymentProductNetworksParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Amount in cents and always having 2 decimals
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// This allows you to filter networks based on their support for recurring or not
        /// <list type="bullet">
        ///   <item><description>true</description></item>
        ///   <item><description>false</description></item>
        /// </list>
        /// </summary>
        public bool? IsRecurring { get; set; }

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
            if (Amount != null)
            {
                result.Add(new RequestParam("amount", Amount.ToString()));
            }
            if (IsRecurring != null)
            {
                result.Add(new RequestParam("isRecurring", IsRecurring.ToString().ToLower()));
            }
            return result;
        }
    }
}
