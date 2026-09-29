/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardWithoutCvv
    {
        /// <summary>
        /// The obfuscated card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// The card holder's name on the card.
        /// </summary>
        public string CardholderName { get; set; }

        /// <summary>
        /// Expiry date of the card
        /// Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardWithoutCvv WithCardNumber(string value)
        {
            CardNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardWithoutCvv WithCardholderName(string value)
        {
            CardholderName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardWithoutCvv WithExpiryDate(string value)
        {
            ExpiryDate = value;
            return this;
        }
    }
}
