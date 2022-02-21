/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ErrorResponse
    {
        /// <summary>
        /// Unique reference, for debugging purposes, of this error response<para />
        /// </summary>
        public string ErrorId { get; set; } = null;

        /// <summary>
        /// List of one or more errors<para />
        /// </summary>
        public IList<APIError> Errors { get; set; } = null;
    }
}
