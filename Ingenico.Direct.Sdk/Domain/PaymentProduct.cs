/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentProduct
    {
        public bool? AllowsRecurring { get; set; } = null;

        public bool? AllowsTokenization { get; set; } = null;

        public PaymentProductDisplayHints DisplayHints { get; set; } = null;

        public int? Id { get; set; } = null;

        public long? MaxAmount { get; set; } = null;

        public long? MinAmount { get; set; } = null;

        public string PaymentMethod { get; set; } = null;

        public string PaymentProductGroup { get; set; } = null;

        public bool? UsesRedirectionTo3rdParty { get; set; } = null;
    }
}
