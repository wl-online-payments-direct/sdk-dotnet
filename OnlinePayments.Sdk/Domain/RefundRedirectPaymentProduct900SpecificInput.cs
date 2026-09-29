/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundRedirectPaymentProduct900SpecificInput
    {
        /// <summary>
        /// The reason for the refund, required for Wero payments. This value is sent to the consumer’s bank as part of the Wero refund request and will be shown to the consumer in their banking application. If not provided, the value defaults to &quot;Other&quot;.
        /// </summary>
        public string RefundReason { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRedirectPaymentProduct900SpecificInput WithRefundReason(string value)
        {
            RefundReason = value;
            return this;
        }
    }
}
