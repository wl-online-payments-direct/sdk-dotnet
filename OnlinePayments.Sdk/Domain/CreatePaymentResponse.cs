/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentResponse
    {
        /// <summary>
        /// Object containing the details of the created payment.
        /// </summary>
        public PaymentCreationOutput CreationOutput { get; set; }

        /// <summary>
        /// Object that contains the action, including the needed data, that you should perform next, like showing instructions, showing the transaction results or redirect to a third party to complete the payment
        /// </summary>
        public MerchantAction MerchantAction { get; set; }

        /// <summary>
        /// Object that holds the payment related properties
        /// </summary>
        public PaymentResponse Payment { get; set; }
    }
}
