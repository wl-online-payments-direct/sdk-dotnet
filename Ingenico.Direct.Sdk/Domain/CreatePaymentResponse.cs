/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreatePaymentResponse
    {
        /// <summary>
        /// Object containing the details of the created payment.<para />
        /// </summary>
        public PaymentCreationOutput CreationOutput { get; set; } = null;

        /// <summary>
        /// Object that contains the action, including the needed data, that you should perform next, like showing instructions, showing the transaction results or redirect to a third party to complete the payment<para />
        /// </summary>
        public MerchantAction MerchantAction { get; set; } = null;

        /// <summary>
        /// Object that holds the payment related properties<para />
        /// </summary>
        public PaymentResponse Payment { get; set; } = null;
    }
}
