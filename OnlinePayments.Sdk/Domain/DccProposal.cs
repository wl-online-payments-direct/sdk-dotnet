/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DccProposal
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney BaseAmount { get; set; } = null;

        /// <summary>
        /// Card scheme disclaimer to present to the cardholder<para />
        /// </summary>
        public string DisclaimerDisplay { get; set; } = null;

        /// <summary>
        /// Card scheme disclaimer to print within cardholder receipt<para />
        /// </summary>
        public string DisclaimerReceipt { get; set; } = null;

        public RateDetails Rate { get; set; } = null;

        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney TargetAmount { get; set; } = null;
    }
}
