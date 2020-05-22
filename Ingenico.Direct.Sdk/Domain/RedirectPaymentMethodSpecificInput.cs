/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificInput
    {
        public RedirectPaymentProduct809SpecificInput PaymentProduct809SpecificInput { get; set; } = null;

        public RedirectPaymentProduct840SpecificInput PaymentProduct840SpecificInput { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public RedirectionData RedirectionData { get; set; } = null;

        public bool? RequiresApproval { get; set; } = null;

        public string Token { get; set; } = null;

        public bool? Tokenize { get; set; } = null;
    }
}
