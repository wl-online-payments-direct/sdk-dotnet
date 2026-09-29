/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CompletePaymentRequest
    {
        public CompletePaymentCardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// The order object contains order-related data;
        /// Please note that this object is required to submit the amount.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentRequest WithCardPaymentMethodSpecificInput(CompletePaymentCardPaymentMethodSpecificInput value)
        {
            CardPaymentMethodSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentRequest WithOrder(Order value)
        {
            Order = value;
            return this;
        }
    }
}
