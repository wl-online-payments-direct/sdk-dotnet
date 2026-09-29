/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatedPaymentOutput
    {
        /// <summary>
        /// This object holds the properties related to the payment.
        /// </summary>
        public PaymentResponse Payment { get; set; }

        public string PaymentStatusCategory { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreatedPaymentOutput WithPayment(PaymentResponse value)
        {
            Payment = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreatedPaymentOutput WithPaymentStatusCategory(string value)
        {
            PaymentStatusCategory = value;
            return this;
        }
    }
}
