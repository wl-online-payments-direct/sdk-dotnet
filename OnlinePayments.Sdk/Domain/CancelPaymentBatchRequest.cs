/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CancelPaymentBatchRequest
    {
        public CancelPaymentRequest Cancel { get; set; }

        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CancelPaymentBatchRequest WithCancel(CancelPaymentRequest value)
        {
            Cancel = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CancelPaymentBatchRequest WithPaymentId(string value)
        {
            PaymentId = value;
            return this;
        }
    }
}
