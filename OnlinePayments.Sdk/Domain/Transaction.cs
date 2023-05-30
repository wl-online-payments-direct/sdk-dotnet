/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Transaction
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney Amount { get; set; } = null;

        /// <summary>
        /// This must be the DateTime of the buyer's browser<para />
        /// Entered in the following format: YYYY-MM-DDTHH:MM:SS. If the timestamp is more than a day (86400 seconds) away from the current time, the request will be rejected<para />
        /// </summary>
        public string LocalDateTime { get; set; } = null;
    }
}
