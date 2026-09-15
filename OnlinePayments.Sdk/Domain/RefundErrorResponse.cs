/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class RefundErrorResponse
    {
        public string ErrorId { get; set; }

        public IList<APIError> Errors { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// </summary>
        public RefundResponse RefundResult { get; set; }
    }
}
