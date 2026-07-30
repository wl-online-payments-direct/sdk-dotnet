/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePayoutRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Object containing the payout details for a card
        /// </summary>
        public CardPayoutMethodSpecificInput CardPayoutMethodSpecificInput { get; set; }

        /// <summary>
        /// <b>Deprecated</b>: It is recommended to use the new merchantReconciliationReference for the same usage, and the new softDescriptor on top only in case you start needing another specific value to be pushed to the cardholder statement.
        /// </summary>
        public string Descriptor { get; set; }

        /// <summary>
        /// This section will contain feedback Urls to provide feedback on the payment.
        /// </summary>
        public Feedbacks Feedbacks { get; set; }

        /// <summary>
        /// Object containing the additional payout details for an Omnichannel merchant
        /// </summary>
        public OmnichannelPayoutSpecificInput OmnichannelPayoutSpecificInput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }
    }
}
