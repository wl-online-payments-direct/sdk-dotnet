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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutCardPaymentMethodSpecificOutput WithAcceptance(Acceptance value)
        {
            Acceptance = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutCardPaymentMethodSpecificOutput WithAuthorisationCode(string value)
        {
            AuthorisationCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutCardPaymentMethodSpecificOutput WithCard(CardEssentials value)
        {
            Card = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutCardPaymentMethodSpecificOutput WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }
    }
}
