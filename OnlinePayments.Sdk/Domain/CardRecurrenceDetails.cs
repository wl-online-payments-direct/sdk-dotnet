/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardRecurrenceDetails
    {
        /// <summary>
        /// * first = This transaction is the first of a series of recurring transactions<para />
        /// * recurring = This transaction is a subsequent transaction in a series of recurring transactions<para />
        /// <para />
        /// Note: For any first of a recurring the system will automatically create a token as you will need to use a token for any subsequent recurring transactions. In case a token already exists this is indicated in the response with a value of False for the isNewToken property in the response.<para />
        /// </summary>
        public string RecurringPaymentSequenceIndicator { get; set; } = null;
    }
}
