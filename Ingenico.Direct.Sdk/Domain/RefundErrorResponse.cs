/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundErrorResponse
    {
        public string ErrorId { get; set; } = null;

        public IList<APIError> Errors { get; set; } = null;

        /// <summary>
        /// This object has the numeric representation of the current refund status, timestamp of last status change and performable action on the current refund resource. In case of a rejected refund, detailed error information is listed.<para />
        /// </summary>
        public RefundResponse RefundResult { get; set; } = null;
    }
}
