/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentCreationOutput
    {
        /// <summary>
        /// The external reference identifier for this transaction. Data in this property will also be returned in our report files, allowing you to reconcile them<para />
        /// </summary>
        public string ExternalReference { get; set; } = null;

        /// <summary>
        /// Indicates if a new token was created <para />
        ///  * true - A new token was created <para />
        ///  * false - A token with the same card number already exists and is returned. Please note that the existing token has not been updated. When you want to update other data then the card number, you need to update data stored in the token explicitly, as data is never updated during the creation of a token.<para />
        /// </summary>
        public bool? IsNewToken { get; set; } = null;

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.<para />
        /// </summary>
        public string Token { get; set; } = null;

        /// <summary>
        /// Indicates if tokenization was successful or not. If this value is false, then the token and isNewToken properties will not be set.<para />
        /// </summary>
        public bool? TokenizationSucceeded { get; set; } = null;
    }
}
