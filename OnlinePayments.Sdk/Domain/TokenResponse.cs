/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenResponse
    {
        /// <summary>
        /// Object containing card details<para />
        /// </summary>
        public TokenCard Card { get; set; } = null;

        /// <summary>
        /// Object containing eWallet details<para />
        /// </summary>
        public TokenEWallet EWallet { get; set; } = null;

        public ExternalTokenLinked ExternalTokenLinked { get; set; } = null;

        /// <summary>
        /// ID of the token<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Temporary tokens have a lifespan of two hours and can only be used once.<para />
        /// </summary>
        public bool? IsTemporary { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
