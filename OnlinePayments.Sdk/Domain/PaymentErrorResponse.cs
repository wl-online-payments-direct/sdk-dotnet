/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentErrorResponse
    {
        /// <summary>
        /// Unique reference, for debugging purposes, of this error response<para />
        /// </summary>
        public string ErrorId { get; set; } = null;

        public IList<APIError> Errors { get; set; } = null;

        /// <summary>
        /// Object that contains details on the created payment in case one has been created.<para />
        /// </summary>
        public CreatePaymentResponse PaymentResult { get; set; } = null;
    }
}
