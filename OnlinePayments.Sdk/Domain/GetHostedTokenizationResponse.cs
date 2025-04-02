/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetHostedTokenizationResponse
    {
        public TokenResponse Token { get; set; }

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
