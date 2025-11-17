/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.ProductGroups
{
    /// <summary>
    /// Query parameters for
    /// Get product group (/v2/{merchantId}/productgroups/{paymentProductGroupId})
    /// </summary>
    public class GetProductGroupParams : AbstractParamRequest
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code of the transaction
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the amount
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Deprecated: This field has no effect.
        /// </summary>
        [Obsolete("This field has no effect.")]
        public string Locale { get; set; }

        /// <summary>
        /// Whole amount in cents (not containing any decimals)
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// This allows you to filter payment products based on their support for recurring payments.
        /// <list type="bullet">
        ///   <item><description>true - return only payment products that support recurring payments,</description></item>
        ///   <item><description>false - return all payment products that support one-time transactions. Payment products that support recurring products are usually also part of this list.</description></item>
        /// </list>
        /// </summary>
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Allows you to hide elements from the response, reducing the amount of data that needs to be returned to your client. Possible options are:
        /// <list type="bullet">
        ///   <item><description>fields - Do not return any data on fields of the payment product</description></item>
        ///   <item><description>accountsOnFile - Do not return any accounts on file data</description></item>
        ///   <item><description>translations - Do not return any label texts associated with the payment products</description></item>
        ///   <item><description>productsWithoutFields - Do not return products that require any additional data to be captured</description></item>
        ///   <item><description>productsWithoutInstructions - Do not return products that show instructions</description></item>
        ///   <item><description>productsWithRedirects - Do not return products that require a redirect to a third party. Note that products that involve potential redirects related to 3D Secure authentication are not hidden</description></item>
        /// </list>
        /// </summary>
        public IList<string> Hide { get; set; }

        public void AddHide(string value)
        {
            var hide = Hide;
            if (hide == null)
            {
                hide = new List<string>();
                Hide = hide;
            }
            hide.Add(value);
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
