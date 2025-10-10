/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.PaymentLinks
{
    /// <summary>
    /// Query parameters for
    /// Get payment links (/v2/{merchantId}/paymentlinks)
    /// </summary>
    public class GetPaymentLinksInBulkParams : AbstractParamRequest
    {
        public string OperationGroupReference { get; set; }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
            if (OperationGroupReference != null)
            {
                result.Add(new RequestParam("operationGroupReference", OperationGroupReference));
            }
            return result;
        }
    }
}
