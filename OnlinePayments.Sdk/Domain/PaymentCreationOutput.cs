/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentCreationOutput
    {
        /// <summary>
        /// The external reference identifier for this transaction. Data in this property will also be returned in our report files, allowing you to reconcile them
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Indicates if a new token was created
        /// <list type="bullet">
        ///   <item><description>true - A new token was created</description></item>
        ///   <item><description>false - A token with the same card number already exists and is returned. Please note that the existing token has not been updated. When you want to update other data then the card number, you need to update data stored in the token explicitly, as data is never updated during the creation of a token.</description></item>
        /// </list>
        /// </summary>
        public bool? IsNewToken { get; set; }

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates if tokenization was successful or not. If this value is false, then the token and the isNewToken property will not be set.
        /// </summary>
        public bool? TokenizationSucceeded { get; set; }
    }
}
