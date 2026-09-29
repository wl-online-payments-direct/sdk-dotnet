/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class OrderStatusOutput
    {
        public IList<APIError> Errors { get; set; }

        /// <summary>
        /// Flag indicating if the payment can be cancelled
        /// <list type="bullet">
        ///   <item><description>true</description></item>
        ///   <item><description>false</description></item>
        /// </list>
        /// </summary>
        public bool? IsCancellable { get; set; }

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
        public OrderStatusOutput WithErrors(IList<APIError> value)
        {
            Errors = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public OrderStatusOutput WithIsCancellable(bool? value)
        {
            IsCancellable = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public OrderStatusOutput WithStatusCategory(string value)
        {
            StatusCategory = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public OrderStatusOutput WithStatusCode(int? value)
        {
            StatusCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public OrderStatusOutput WithStatusCodeChangeDateTime(string value)
        {
            StatusCodeChangeDateTime = value;
            return this;
        }
    }
}
