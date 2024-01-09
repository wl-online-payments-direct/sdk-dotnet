/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkEvent
    {
        /// <summary>
        /// The date and time the change occurred. The date will contain the UTC offset.<para />
        /// </summary>
        public string DateTime { get; set; } = null;

        /// <summary>
        /// Details of the events. Ex.: email address or phone number of the recipient.<para />
        /// </summary>
        public string Details { get; set; } = null;

        /// <summary>
        /// The type of event that occurred.<para />
        /// </summary>
        public string Type { get; set; } = null;
    }
}
