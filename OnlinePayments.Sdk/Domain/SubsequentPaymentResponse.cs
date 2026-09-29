/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentResponse
    {
        /// <summary>
        /// This object holds the properties related to the payment.
        /// </summary>
        public PaymentResponse Payment { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubsequentPaymentResponse WithPayment(PaymentResponse value)
        {
            Payment = value;
            return this;
        }
    }
}
