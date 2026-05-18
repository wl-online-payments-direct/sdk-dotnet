/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutCardPaymentMethodSpecificOutput
    {
        /// <summary>
        /// This object contains the acceptance information for the card payment authorization.
        /// </summary>
        public Acceptance Acceptance { get; set; }

        /// <summary>
        /// Card Authorization code as returned by the acquirer
        /// </summary>
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Object containing card details
        /// </summary>
        public CardEssentials Card { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}
