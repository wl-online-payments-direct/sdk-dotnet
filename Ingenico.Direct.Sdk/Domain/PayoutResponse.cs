/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PayoutResponse
    {
        public string Id { get; set; } = null;

        public PayoutOutput PayoutOutput { get; set; } = null;

        public string Status { get; set; } = null;

        public PayoutStatusOutput StatusOutput { get; set; } = null;
    }
}
