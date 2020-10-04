/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class ThreeDSecure
    {
        public string ChallengeCanvasSize { get; set; } = null;

        public string ChallengeIndicator { get; set; } = null;

        public bool? DecoupledIndicator { get; set; } = null;

        public string DecoupledMaxTime { get; set; } = null;

        public string ExemptionRequest { get; set; } = null;

        public ExternalCardholderAuthenticationData ExternalCardholderAuthenticationData { get; set; } = null;

        public int? MerchantFraudRate { get; set; } = null;

        public string PaymentTokenSource { get; set; } = null;

        public ThreeDSecureData PriorThreeDSecureData { get; set; } = null;

        public RedirectionData RedirectionData { get; set; } = null;

        public bool? SecureCorporatePayment { get; set; } = null;

        public bool? SkipAuthentication { get; set; } = null;

        public string ThreeRIIndicator { get; set; } = null;

        public ThreeDSWhitelist Whitelist { get; set; } = null;
    }
}
