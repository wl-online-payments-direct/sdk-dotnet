/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PayoutErrorResponse
    {
        public string ErrorId { get; set; }

        /// <summary>
        /// This field contains the set of errors encountered during the process.
        /// </summary>
        public IList<APIError> Errors { get; set; }

        public PayoutResult PayoutResult { get; set; }
    }
}
