/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Product302Recurring
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>first = This transaction is the first of a series of recurring transactions</description></item>
        /// </list>
        /// </summary>
        public string RecurringPaymentSequenceIndicator { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Product302Recurring WithRecurringPaymentSequenceIndicator(string value)
        {
            RecurringPaymentSequenceIndicator = value;
            return this;
        }
    }
}
