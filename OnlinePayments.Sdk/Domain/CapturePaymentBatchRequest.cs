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
    }
}
