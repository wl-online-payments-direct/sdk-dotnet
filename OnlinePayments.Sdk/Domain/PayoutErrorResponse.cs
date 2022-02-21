/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PayoutErrorResponse
    {
        public string ErrorId { get; set; } = null;

        /// <summary>
        /// Contains the set of errors<para />
        /// </summary>
        public IList<APIError> Errors { get; set; } = null;

        public PayoutResult PayoutResult { get; set; } = null;
    }
}
