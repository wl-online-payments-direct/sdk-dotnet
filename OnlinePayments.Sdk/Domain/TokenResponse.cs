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
        /// The CRM (Customer Relationship Management) token group. CRM tokens are available to enhance knowledge of a merchant's customers by attempting to identify the customer.
        /// </summary>
        public CrmToken CrmToken { get; set; }

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
        /// Object containing Network Token details, when the Network Token was created on behalf of the merchant and is activated.
        /// </summary>
        public NetworkTokenLinked NetworkTokenLinked { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
