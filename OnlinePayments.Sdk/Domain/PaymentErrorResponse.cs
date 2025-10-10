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
        /// This object contains details about the created payment if one has been generated.
        /// </summary>
        public CreatePaymentResponse PaymentResult { get; set; }
    }
}
