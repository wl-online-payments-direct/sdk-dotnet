/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class HostedCheckoutSpecificInput
    {
        public bool? IsRecurring { get; set; } = null;

        public string Locale { get; set; } = null;

        public PaymentProductFiltersHostedCheckout PaymentProductFilters { get; set; } = null;

        public string ReturnUrl { get; set; } = null;

        public bool? ShowResultPage { get; set; } = null;

        public string Tokens { get; set; } = null;

        public string Variant { get; set; } = null;
    }
}
