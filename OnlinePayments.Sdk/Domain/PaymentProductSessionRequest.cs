/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductSessionRequest
    {
        /// <summary>
        /// The specific input details needed to create a payment product session for Apple Pay (payment product 302).
        /// </summary>
        public PaymentProductSession302SpecificInput PaymentProductSession302SpecificInput { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductSessionRequest WithPaymentProductSession302SpecificInput(PaymentProductSession302SpecificInput value)
        {
            PaymentProductSession302SpecificInput = value;
            return this;
        }
    }
}
