/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentMethodSpecificOutput
    {
        /// <summary>
        /// Card Authorization code as returned by the acquirer
        /// </summary>
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Fraud results contained in the CardFraudResults object
        /// </summary>
        public CardFraudResults FraudResults { get; set; }

        /// <summary>
        /// The card network that was used for a mobile payment method operation
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        /// Object containing payment details
        /// </summary>
        public MobilePaymentData PaymentData { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// 3D Secure results object
        /// </summary>
        public ThreeDSecureResults ThreeDSecureResults { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithAuthorisationCode(string value)
        {
            AuthorisationCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithFraudResults(CardFraudResults value)
        {
            FraudResults = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithNetwork(string value)
        {
            Network = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithPaymentData(MobilePaymentData value)
        {
            PaymentData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MobilePaymentMethodSpecificOutput WithThreeDSecureResults(ThreeDSecureResults value)
        {
            ThreeDSecureResults = value;
            return this;
        }
    }
}
