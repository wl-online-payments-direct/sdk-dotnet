/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificOutput
    {
        public FraudResults FraudResults { get; set; } = null;

        public PaymentProduct840SpecificOutput PaymentProduct840SpecificOutput { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public string Token { get; set; } = null;
    }
}
