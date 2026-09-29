/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundPaymentBatchRequest
    {
        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string PaymentId { get; set; }

        public RefundRequest Refund { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundPaymentBatchRequest WithPaymentId(string value)
        {
            PaymentId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundPaymentBatchRequest WithRefund(RefundRequest value)
        {
            Refund = value;
            return this;
        }
    }
}
