/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CompletePaymentCardPaymentMethodSpecificInput
    {
        public CardWithoutCvv Card { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CompletePaymentCardPaymentMethodSpecificInput WithCard(CardWithoutCvv value)
        {
            Card = value;
            return this;
        }
    }
}
