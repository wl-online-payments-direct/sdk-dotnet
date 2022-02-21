/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Query parameters for 'Get payment products'.
    /// </summary>
    public class GetPaymentProductsParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code of the transaction<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount<para />
        /// </summary>
        public string CurrencyCode { get; set; } = null;

        /// <summary>
        /// Locale used in the GUI towards the consumer.<para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// Whole amount in cents (not containing any decimals)<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// This allows you to filter payment products based on their support for recurring payments.<para />
        /// * true - return only payment products that support recurring payments,<para />
        /// * false - return all payment products that support one-time transactions. Payment products that support recurring products are usually also part of this list.<para />
        /// </summary>
        public bool? IsRecurring { get; set; } = null;

        /// <summary>
        /// Allows you to hide elements from the response, reducing the amount of data that needs to be returned to your client. Possible options are:<para />
        /// * fields - Don't return any data on fields of the payment product<para />
        /// * accountsOnFile - Don't return any accounts on file data<para />
        /// * translations - Don't return any label texts associated with the payment products<para />
        /// * productsWithoutFields - Don't return products that require any additional data to be captured<para />
        /// * productsWithoutInstructions - Don't return products that show instructions<para />
        /// * productsWithRedirects - Don't return products that require a redirect to a 3rd party. Note that products that involve potential redirects related to 3D Secure authentication are not hidden<para />
        /// </summary>
        public IList<string> Hide { get; set; } = null;

        public void AddHide(string value)
        {
            IList<string> hide = Hide;
            if (hide == null)
            {
                hide = new List<string>();
                Hide = hide;
            }
            hide.Add(value);
        }

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
            if (Locale != null)
            {
                result.Add(new RequestParam("locale", Locale));
            }
            if (Amount != null)
            {
                result.Add(new RequestParam("amount", Amount.ToString()));
            }
            if (IsRecurring != null)
            {
                result.Add(new RequestParam("isRecurring", IsRecurring.ToString().ToLower()));
            }
            if (Hide != null)
            {
                foreach (var hideElement in Hide)
                {
                    if (hideElement != null)
                    {
                        result.Add(new RequestParam("hide", hideElement));
                    }
                }
            }
            return result;
        }
    }
}
