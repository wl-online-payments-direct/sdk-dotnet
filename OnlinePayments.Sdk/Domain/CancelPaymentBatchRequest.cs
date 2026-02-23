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
    }
}
