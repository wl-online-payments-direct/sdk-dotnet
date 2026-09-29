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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubsequentPaymentBatchRequest WithPaymentId(string value)
        {
            PaymentId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubsequentPaymentBatchRequest WithSubsequent(SubsequentPaymentRequest value)
        {
            Subsequent = value;
            return this;
        }
    }
}
