/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentContext
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// The country the payment takes place in
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// True if the payment is recurring
        /// </summary>
        public bool? IsRecurring { get; set; }
    }
}
