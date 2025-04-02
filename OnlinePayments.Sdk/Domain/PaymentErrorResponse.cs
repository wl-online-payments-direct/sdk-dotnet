/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentErrorResponse
    {
        /// <summary>
        /// Unique reference, for debugging purposes, of this error response
        /// </summary>
        public string ErrorId { get; set; }

        public IList<APIError> Errors { get; set; }

        /// <summary>
        /// Object that contains details on the created payment in case one has been created.
        /// </summary>
        public CreatePaymentResponse PaymentResult { get; set; }
    }
}
