/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreatePaymentRequest
    {
        public CardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; } = null;

        public string EncryptedCustomerInput { get; set; } = null;

        public FraudFields FraudFields { get; set; } = null;

        public MobilePaymentMethodSpecificInput MobilePaymentMethodSpecificInput { get; set; } = null;

        public Order Order { get; set; } = null;

        public RedirectPaymentMethodSpecificInput RedirectPaymentMethodSpecificInput { get; set; } = null;
    }
}
