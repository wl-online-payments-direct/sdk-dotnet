/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardInstallmentDetails
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>first = This transaction is the first of a series of installment transactions</description></item>
        ///   <item><description>subsequent = This transaction is a subsequent transaction in a series of installment transactions
        /// Note: For any first of an installment the system will automatically create a token as you will need to use a token for any subsequent installment transactions. In case a token already exists this is indicated in the response with a value of False for the isNewToken property in the response.</description></item>
        /// </list>
        /// </summary>
        public string InstallmentPaymentSequenceIndicator { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardInstallmentDetails WithInstallmentPaymentSequenceIndicator(string value)
        {
            InstallmentPaymentSequenceIndicator = value;
            return this;
        }
    }
}
