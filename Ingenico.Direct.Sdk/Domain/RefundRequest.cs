/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;
    }
}
