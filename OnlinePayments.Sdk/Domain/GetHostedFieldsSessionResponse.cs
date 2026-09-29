/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetHostedFieldsSessionResponse
    {
        /// <summary>
        /// The ID of the hosted fields session.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Object containing token information that is used in the hosted fields session
        /// </summary>
        public TokenInfo Token { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetHostedFieldsSessionResponse WithSessionId(string value)
        {
            SessionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetHostedFieldsSessionResponse WithToken(TokenInfo value)
        {
            Token = value;
            return this;
        }
    }
}
