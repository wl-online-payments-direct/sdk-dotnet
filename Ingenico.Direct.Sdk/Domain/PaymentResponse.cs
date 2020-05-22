/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentResponse
    {
        public HostedCheckoutSpecificOutput HostedCheckoutSpecificOutput { get; set; } = null;

        public string Id { get; set; } = null;

        public PaymentOutput PaymentOutput { get; set; } = null;

        public string Status { get; set; } = null;

        public PaymentStatusOutput StatusOutput { get; set; } = null;
    }
}
