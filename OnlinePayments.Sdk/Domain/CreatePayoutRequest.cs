/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePayoutRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Object containing the payout details for a card<para />
        /// </summary>
        public CardPayoutMethodSpecificInput CardPayoutMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing the additional payout details for a Omnichannel merchants<para />
        /// </summary>
        public OmnichannelPayoutSpecificInput OmnichannelPayoutSpecificInput { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;
    }
}
