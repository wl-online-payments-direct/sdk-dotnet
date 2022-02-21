/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetHostedTokenizationResponse
    {
        public TokenResponse Token { get; set; } = null;

        /// <summary>
        /// This is the status of the token in the hosted tokenization session. Possible values are:<para />
        /// * UNCHANGED - The token has not changed<para />
        /// * CREATED - The token has been created<para />
        /// * UPDATED - The token has been updated<para />
        /// </summary>
        public string TokenStatus { get; set; } = null;
    }
}
