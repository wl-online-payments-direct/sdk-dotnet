/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatedTokenResponse
    {
        public CardWithoutCvv Card { get; set; } = null;

        public ExternalTokenLinked ExternalTokenLinked { get; set; } = null;

        /// <summary>
        /// Indicates if a new token was created <para />
        ///  * true - A new token was created <para />
        ///  * false - A token with the same card number already exists and is returned. Please note that the existing token has not been updated. When you want to update other data then the card number, you need to update data stored in the token explicitly, as data is never updated during the creation of a token.<para />
        /// </summary>
        public bool? IsNewToken { get; set; } = null;

        /// <summary>
        /// ID of the token<para />
        /// </summary>
        public string Token { get; set; } = null;

        /// <summary>
        /// This is the status of the token in the hosted tokenization session. Possible values are:<para />
        /// * UNCHANGED - The token has not changed<para />
        /// * CREATED - The token has been created<para />
        /// * UPDATED - The token has been updated<para />
        /// </summary>
        public string TokenStatus { get; set; } = null;
    }
}
