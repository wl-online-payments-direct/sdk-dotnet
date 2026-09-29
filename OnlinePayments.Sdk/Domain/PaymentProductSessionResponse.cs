/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductSessionResponse
    {
        /// <summary>
        /// The specific output details of the created payment product session for Apple Pay (payment product 302).
        /// </summary>
        public PaymentProductSession302SpecificOutput PaymentProductSession302SpecificOutput { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductSessionResponse WithPaymentProductSession302SpecificOutput(PaymentProductSession302SpecificOutput value)
        {
            PaymentProductSession302SpecificOutput = value;
            return this;
        }
    }
}
