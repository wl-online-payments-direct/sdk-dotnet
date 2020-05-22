/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class MobilePaymentMethodSpecificInput
    {
        public string AuthorizationMode { get; set; } = null;

        public DecryptedPaymentData DecryptedPaymentData { get; set; } = null;

        public string EncryptedPaymentData { get; set; } = null;

        public string EphemeralKey { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public string PublicKeyHash { get; set; } = null;

        public bool? RequiresApproval { get; set; } = null;
    }
}
