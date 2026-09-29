/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkEvent
    {
        /// <summary>
        /// The date and time the change occurred. The date will contain the UTC offset.
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// Details of the events. Ex.: email address or phone number of the recipient.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The type of event that occurred.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkEvent WithDateTime(string value)
        {
            DateTime = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkEvent WithDetails(string value)
        {
            Details = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkEvent WithType(string value)
        {
            Type = value;
            return this;
        }
    }
}
