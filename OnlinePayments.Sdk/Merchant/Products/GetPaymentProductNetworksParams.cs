/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for 'Get payment product networks'.
    /// </summary>
    public class GetPaymentProductNetworksParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount<para />
        /// </summary>
        public string CurrencyCode { get; set; } = null;

        /// <summary>
        /// Amount in cents and always having 2 decimals<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// This allows you to filter networks based on their support for recurring or not<para />
        /// * true<para />
        /// * false<para />
        /// </summary>
        public bool? IsRecurring { get; set; } = null;

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
