/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3209SpecificOutput
    {
        /// <summary>
        /// This field indicates the text that must be returned and shown to the buyer to be compliant with the law regulating this payment product.
        /// </summary>
        public string BuyerCompliantBankMessage { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3209SpecificOutput WithBuyerCompliantBankMessage(string value)
        {
            BuyerCompliantBankMessage = value;
            return this;
        }
    }
}
