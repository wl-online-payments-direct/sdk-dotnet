/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatedTokenResponse
    {
        public CardWithoutCvv Card { get; set; }

        public ExternalTokenLinked ExternalTokenLinked { get; set; }

        /// <summary>
        /// Indicates if a new token was created
        /// <list type="bullet">
        ///   <item><description>true - A new token was created</description></item>
        ///   <item><description>false - A token with the same card number already exists and is returned. Please note that the existing token has not been updated. When you want to update other data then the card number, you need to update data stored in the token explicitly, as data is never updated during the creation of a token.</description></item>
        /// </list>
        /// </summary>
        public bool? IsNewToken { get; set; }

        /// <summary>
        /// ID of the token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// This is the status of the token in the hosted tokenization session. Possible values are:
        /// <list type="bullet">
        ///   <item><description>UNCHANGED - The token has not changed</description></item>
        ///   <item><description>CREATED - The token has been created</description></item>
        ///   <item><description>UPDATED - The token has been updated</description></item>
        /// </list>
        /// </summary>
        public string TokenStatus { get; set; }
    }
}
