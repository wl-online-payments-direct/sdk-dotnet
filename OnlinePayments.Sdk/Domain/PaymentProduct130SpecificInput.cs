/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct130SpecificInput
    {
        /// <summary>
        /// Object containing specific data regarding 3-D Secure
        /// </summary>
        public PaymentProduct130SpecificThreeDSecure ThreeDSecure { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct130SpecificInput WithThreeDSecure(PaymentProduct130SpecificThreeDSecure value)
        {
            ThreeDSecure = value;
            return this;
        }
    }
}
