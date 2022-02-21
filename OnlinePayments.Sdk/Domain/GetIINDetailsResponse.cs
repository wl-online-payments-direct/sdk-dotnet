/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class GetIINDetailsResponse
    {
        /// <summary>
        /// List of IIN details<para />
        /// </summary>
        public IList<IINDetail> CoBrands { get; set; } = null;

        /// <summary>
        /// The ISO 3166-1 alpha-2 country code of the country where the card was issued. If we don't know where the card was issued, then the countryCode will return the value '99'.<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Populated only if you submitted a payment context.<para />
        /// * true - The payment product is allowed in the submitted context.<para />
        /// * false - The payment product is not allowed in the submitted context. Note that in this case, none of the brands of the card will be allowed in the submitted context.<para />
        /// </summary>
        public bool? IsAllowedInContext { get; set; } = null;

        /// <summary>
        /// The payment product identifier associated with the card. If the card has multiple brands, then we select the most appropriate payment product based on your configuration and the payment context, if you submitted one.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
