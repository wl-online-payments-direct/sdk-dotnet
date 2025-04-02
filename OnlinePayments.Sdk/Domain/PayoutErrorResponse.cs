/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PayoutErrorResponse
    {
        public string ErrorId { get; set; }

        public IList<APIError> Errors { get; set; }

        public PayoutResult PayoutResult { get; set; }
    }
}
