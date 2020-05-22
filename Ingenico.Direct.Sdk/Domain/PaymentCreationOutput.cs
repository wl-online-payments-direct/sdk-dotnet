/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentCreationOutput
    {
        public string ExternalReference { get; set; } = null;

        public bool? IsNewToken { get; set; } = null;

        public string Token { get; set; } = null;

        public bool? TokenizationSucceeded { get; set; } = null;
    }
}
