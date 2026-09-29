/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenCardSpecificInput
    {
        /// <summary>
        /// Object containing the token details for a card
        /// </summary>
        public TokenData Data { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCardSpecificInput WithData(TokenData value)
        {
            Data = value;
            return this;
        }
    }
}
