/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentContext
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// The country the payment takes place in<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// True if the payment is recurring<para />
        /// </summary>
        public bool? IsRecurring { get; set; } = null;
    }
}
