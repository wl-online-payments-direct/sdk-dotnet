/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentBatchRequest
    {
        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string PaymentId { get; set; }

        public SubsequentPaymentRequest Subsequent { get; set; }
    }
}
