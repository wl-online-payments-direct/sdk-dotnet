/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardToken
    {
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
        /// URL to the card product logo.
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// The masked Primary Account Number (PAN).
        /// </summary>
        public string MaskedPan { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Product name of the card
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// This is a validated card token available for later use.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithCardholderName(string value)
        {
            CardholderName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithExpiryDate(string value)
        {
            ExpiryDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithLogoUrl(string value)
        {
            LogoUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithMaskedPan(string value)
        {
            MaskedPan = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithProductName(string value)
        {
            ProductName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardToken WithToken(string value)
        {
            Token = value;
            return this;
        }
    }
}
