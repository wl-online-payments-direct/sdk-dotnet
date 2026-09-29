/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CapturePaymentBatchRequest
    {
        public CapturePaymentRequest Capture { get; set; }

        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CapturePaymentBatchRequest WithCapture(CapturePaymentRequest value)
        {
            Capture = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CapturePaymentBatchRequest WithPaymentId(string value)
        {
            PaymentId = value;
            return this;
        }
    }
}
