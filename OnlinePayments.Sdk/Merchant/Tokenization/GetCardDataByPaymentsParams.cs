/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.Tokenization
{
    /// <summary>
    /// Query parameters for
    /// Get sensitive card details by card payment identifiers (/v2/{merchantId}/detokenize/payments)
    /// </summary>
    public class GetCardDataByPaymentsParams : AbstractParamRequest
    {
        /// <summary>
        /// This object contains the details for detokenizing a payment token.
        /// </summary>
        public IList<string> Payments { get; set; }

        public void AddPayments(string value)
        {
            var payments = Payments;
            if (payments == null)
            {
                payments = new List<string>();
                Payments = payments;
            }
            payments.Add(value);
        }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
            if (Payments != null)
            {
                foreach (var paymentsElement in Payments)
                {
                    if (paymentsElement != null)
                    {
                        result.Add(new RequestParam("payments", paymentsElement));
                    }
                }
            }
            return result;
        }
    }
}
