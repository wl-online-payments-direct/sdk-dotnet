/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenCard
    {
        /// <summary>
        /// An alias for the token. This can be used to visually represent the token.
        /// </summary>
        public string Alias { get; set; }

        public TokenCardData Data { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCard WithAlias(string value)
        {
            Alias = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCard WithData(TokenCardData value)
        {
            Data = value;
            return this;
        }
    }
}
