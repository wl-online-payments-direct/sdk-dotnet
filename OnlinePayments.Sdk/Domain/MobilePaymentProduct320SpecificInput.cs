/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MobilePaymentProduct320SpecificInput
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Indicates that the transaction is part of a scheduled recurring sequence. In addition, recurringPaymentSequenceIndicator indicates if the transaction is the first or subsequent in a recurring sequence.</description></item>
        ///   <item><description>false - Indicates that the transaction is not part of a scheduled recurring sequence.
        /// The default value for this property is false.
        /// For HostedCheckout use the hostedCheckoutSpecificInput.isRecurring property instead.</description></item>
        /// </list>
        /// </summary>
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Object containing information specific to Google Pay and recurring.
        /// </summary>
        public Product320Recurring Recurring { get; set; }

        /// <summary>
        /// Object containing specific data regarding 3-D Secure
        /// </summary>
        public GPayThreeDSecure ThreeDSecure { get; set; }

        /// <summary>
        /// Indicates if this transaction should be tokenized
        /// <list type="bullet">
        ///   <item><description>true - Tokenize the transaction. Note that a payment on the payment platform that results in a status REDIRECTED cannot be tokenized in this way.</description></item>
        ///   <item><description>false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments.</description></item>
        /// </list>
        /// </summary>
        public bool? Tokenize { get; set; }
    }
}
