/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant.Services
{
    /// <summary>
    /// Query parameters for 'Get Privacy Policy'.
    /// </summary>
    public class GetPrivacyPolicyParams : AbstractParamRequest
    {
        /// <summary>
        /// Locale in which the privacy policy will be returned.<para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// ID of the specific payment product for which you wish to retrieve the privacy policy. When none is provided you will receive a complete policy for all the payment methods available for the specified merchantId.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            IList<RequestParam> result = new List<RequestParam>();
            if (Locale != null)
            {
                result.Add(new RequestParam("locale", Locale));
            }
            if (PaymentProductId != null)
            {
                result.Add(new RequestParam("paymentProductId", PaymentProductId.ToString()));
            }
            return result;
        }
    }
}
