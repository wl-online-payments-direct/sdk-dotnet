/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenResponse
    {
        /// <summary>
        /// Object containing card details
        /// </summary>
        public TokenCard Card { get; set; }

        /// <summary>
        /// Object containing eWallet details
        /// </summary>
        public TokenEWallet EWallet { get; set; }

        public ExternalTokenLinked ExternalTokenLinked { get; set; }

        /// <summary>
        /// ID of the token
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Temporary tokens have a lifespan of two hours and can only be used once.
        /// </summary>
        public bool? IsTemporary { get; set; }

        /// <summary>
        /// Represents a linked network token
        /// </summary>
        public NetworkTokenLinked NetworkTokenLinked { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
