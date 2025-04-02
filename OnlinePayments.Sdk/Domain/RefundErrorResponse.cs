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
        /// This object has the numeric representation of the current refund status, timestamp of last status change and performable action on the current refund resource. In case of a rejected refund, detailed error information is listed.
        /// </summary>
        public RefundResponse RefundResult { get; set; }
    }
}
