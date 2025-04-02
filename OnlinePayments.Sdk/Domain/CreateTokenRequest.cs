/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateTokenRequest
    {
        /// <summary>
        /// Object containing the token details for a card
        /// </summary>
        public TokenCardSpecificInput Card { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
