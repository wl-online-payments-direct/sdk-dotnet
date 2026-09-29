/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateMandateResponse
    {
        /// <summary>
        /// Object containing the created mandate.
        /// </summary>
        public MandateResponse Mandate { get; set; }

        /// <summary>
        /// Object that contains the action, including the needed data, that you should perform next, showing the redirect to a third party to complete the payment or like showing instructions.
        /// </summary>
        public MandateMerchantAction MerchantAction { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateMandateResponse WithMandate(MandateResponse value)
        {
            Mandate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateMandateResponse WithMerchantAction(MandateMerchantAction value)
        {
            MerchantAction = value;
            return this;
        }
    }
}
