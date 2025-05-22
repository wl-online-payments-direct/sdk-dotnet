/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ApplePayLineItem
    {
        /// <summary>
        /// A required value that’s the monetary amount of the line item.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// A required value that’s a short, localized description of the line item.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The time that the payment occurs as part of a successful transaction.
        /// </summary>
        public string PaymentTiming { get; set; }

        /// <summary>
        /// The date of the final payment. Example 2022-01-01T00:00:00
        /// </summary>
        public string RecurringPaymentEndDate { get; set; }

        /// <summary>
        /// The number of interval units that make up the total payment interval.
        /// </summary>
        public long? RecurringPaymentIntervalCount { get; set; }

        /// <summary>
        /// The amount of time — in calendar units, such as day, month, or year — that represents a fraction of the total payment interval.
        /// </summary>
        public string RecurringPaymentIntervalUnit { get; set; }

        /// <summary>
        /// The date of the first payment. Example 2022-01-01T00:00:00
        /// </summary>
        public string RecurringPaymentStartDate { get; set; }
    }
}
