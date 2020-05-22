/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreateHostedCheckoutRequest
    {
        public CardPaymentMethodSpecificInputBase CardPaymentMethodSpecificInput { get; set; } = null;

        public FraudFields FraudFields { get; set; } = null;

        public HostedCheckoutSpecificInput HostedCheckoutSpecificInput { get; set; } = null;

        public Order Order { get; set; } = null;

        public RedirectPaymentMethodSpecificInput RedirectPaymentMethodSpecificInput { get; set; } = null;
    }
}
