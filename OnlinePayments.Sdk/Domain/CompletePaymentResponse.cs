/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CompletePaymentResponse
    {
        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// </summary>
        public PaymentCreationOutput CreationOutput { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// </summary>
        public MerchantAction MerchantAction { get; set; }

        /// <summary>
        /// This object holds the properties related to the payment.
        /// </summary>
        public PaymentResponse Payment { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentResponse WithCreationOutput(PaymentCreationOutput value)
        {
            CreationOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentResponse WithMerchantAction(MerchantAction value)
        {
            MerchantAction = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentResponse WithPayment(PaymentResponse value)
        {
            Payment = value;
            return this;
        }
    }
}
