/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentMethodSpecificOutput
    {
        /// <summary>
        /// Card Authorization code as returned by the acquirer<para />
        /// </summary>
        public string AuthorisationCode { get; set; } = null;

        /// <summary>
        /// Fraud results contained in the CardFraudResults object<para />
        /// </summary>
        public CardFraudResults FraudResults { get; set; } = null;

        /// <summary>
        /// The card network that was used for a mobile payment method operation<para />
        /// </summary>
        public string Network { get; set; } = null;

        /// <summary>
        /// Object containing payment details<para />
        /// </summary>
        public MobilePaymentData PaymentData { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// 3D Secure results object<para />
        /// </summary>
        public ThreeDSecureResults ThreeDSecureResults { get; set; } = null;
    }
}
