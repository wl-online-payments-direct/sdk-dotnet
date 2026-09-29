/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentStatusOutput
    {
        /// <summary>
        /// This field contains the set of errors encountered during the process.
        /// </summary>
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
        /// This is a flag indicating whether the payment can be refunded.
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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithErrors(IList<APIError> value)
        {
            Errors = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithIsAuthorized(bool? value)
        {
            IsAuthorized = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithIsCancellable(bool? value)
        {
            IsCancellable = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithIsRefundable(bool? value)
        {
            IsRefundable = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithStatusCategory(string value)
        {
            StatusCategory = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithStatusCode(int? value)
        {
            StatusCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentStatusOutput WithStatusCodeChangeDateTime(string value)
        {
            StatusCodeChangeDateTime = value;
            return this;
        }
    }
}
