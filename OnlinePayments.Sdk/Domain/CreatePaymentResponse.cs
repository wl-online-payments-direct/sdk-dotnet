/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentResponse
    {
        /// <summary>
        /// This object contains the details of the created payment.
        /// </summary>
        public PaymentCreationOutput CreationOutput { get; set; }

        /// <summary>
        /// This object contains the action, including the needed data, that you should perform next. This could involve showing instructions, displaying the transaction results, or redirecting to a third party to complete the payment.
        /// </summary>
        public MerchantAction MerchantAction { get; set; }

        /// <summary>
        /// This object holds the properties related to the payment.
        /// </summary>
        public PaymentResponse Payment { get; set; }
    }
}
