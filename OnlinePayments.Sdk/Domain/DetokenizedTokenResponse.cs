/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DetokenizedTokenResponse
    {
        /// <summary>
        /// The brand of the card (e.g., VISA, MasterCard).
        /// </summary>
        public string CardBrand { get; set; }

        /// <summary>
        /// The expiration date of the card in MMYY format, where MM represents the two-digit month and YY represents the two-digit year. For example, a value of 0529 indicates that the card expires in May 2029.
        /// </summary>
        public string CardExpiryDate { get; set; }

        /// <summary>
        /// The full name of the cardholder as it appears on the card.
        /// </summary>
        public string CardHolderName { get; set; }

        /// <summary>
        /// The card number, encrypted and Base64 encoded for secure transport.
        /// </summary>
        public string EncryptedCardNumber { get; set; }

        /// <summary>
        /// The unique identifier for the payment associated with the token is necessary for tracking.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Reference data associated with the payment scheme for the credentials on file.
        /// </summary>
        public string SchemeReferenceData { get; set; }

        /// <summary>
        /// The unique identifier for the token is required for processing.
        /// </summary>
        public string Token { get; set; }
    }
}
