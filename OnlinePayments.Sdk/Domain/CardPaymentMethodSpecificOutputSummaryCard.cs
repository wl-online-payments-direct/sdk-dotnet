/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificOutputSummaryCard
    {
        /// <summary>
        /// The masked credit/debit card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutputSummaryCard WithCardNumber(string value)
        {
            CardNumber = value;
            return this;
        }
    }
}
