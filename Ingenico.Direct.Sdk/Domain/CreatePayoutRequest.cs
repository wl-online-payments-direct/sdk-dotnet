/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreatePayoutRequest
    {
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public CardPayoutMethodSpecificInput CardPayoutMethodSpecificInput { get; set; } = null;

        public PaymentReferences References { get; set; } = null;
    }
}
