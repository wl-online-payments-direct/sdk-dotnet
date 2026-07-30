/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.MerchantBatch
{
    /// <summary>
    /// Query parameters for
    /// Get payments report (/v2/{merchantId}/merchant-batches/{merchantBatchReference}/reports/payments)
    /// </summary>
    public class GetPaymentsReportParams : AbstractParamRequest
    {
        /// <summary>
        /// Opaque cursor for pagination. Omit for the first page, use value from previous response for subsequent pages.
        /// </summary>
        public string Cursor { get; set; }

        /// <summary>
        /// Maximum number of items to return per page.
        /// </summary>
        public int? Limit { get; set; }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
            if (Cursor != null)
            {
                result.Add(new RequestParam("cursor", Cursor));
            }
            if (Limit != null)
            {
                result.Add(new RequestParam("limit", Limit.ToString()));
            }
            return result;
        }
    }
}
