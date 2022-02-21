/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateTokenRequest
    {
        /// <summary>
        /// Object containing the token details for a card<para />
        /// </summary>
        public TokenCardSpecificInput Card { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}
