/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class MobilePaymentMethodSpecificOutput
    {
        public string AuthorisationCode { get; set; } = null;

        public CardFraudResults FraudResults { get; set; } = null;

        public string Network { get; set; } = null;

        public MobilePaymentData PaymentData { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public ThreeDSecureResults ThreeDSecureResults { get; set; } = null;
    }
}
