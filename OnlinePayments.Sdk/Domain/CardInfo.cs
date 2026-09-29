/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardInfo
    {
        /// <summary>
        /// Provide the complete credit/debit card number (also known as the PAN) for the most accurate results.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardInfo WithCardNumber(string value)
        {
            CardNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardInfo WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }
    }
}
