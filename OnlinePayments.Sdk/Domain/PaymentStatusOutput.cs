/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentStatusOutput
    {
        public IList<APIError> Errors { get; set; }

        /// <summary>
        /// Indicates if the transaction has been authorized
        /// </summary>
        public bool? IsAuthorized { get; set; }

        /// <summary>
        /// Flag indicating if the payment can be cancelled
        /// </summary>
        public bool? IsCancellable { get; set; }

        /// <summary>
        /// Flag indicating if the payment can be refunded
        /// </summary>
        public bool? IsRefundable { get; set; }

        /// <summary>
        /// Highlevel status of the payment, payout or refund.
        /// </summary>
        public string StatusCategory { get; set; }

        /// <summary>
        /// Numeric status code of the legacy API. The value can also be found in the BackOffice and in report files.
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// Timestamp of the latest status change
        /// </summary>
        public string StatusCodeChangeDateTime { get; set; }
    }
}
