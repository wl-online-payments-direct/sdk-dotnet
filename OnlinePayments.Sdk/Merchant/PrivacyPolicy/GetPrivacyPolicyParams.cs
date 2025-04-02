/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.PrivacyPolicy
{
    /// <summary>
    /// Query parameters for
    /// Get Privacy Policy (/v2/{merchantId}/services/privacypolicy)
    /// </summary>
    public class GetPrivacyPolicyParams : AbstractParamRequest
    {
        /// <summary>
        /// Locale in which the privacy policy will be returned.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// ID of the specific payment product for which you wish to retrieve the privacy policy. When none is provided you will receive a complete policy for all the payment methods available for the specified merchantId.
        /// </summary>
        public int? PaymentProductId { get; set; }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
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
