/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DccProposal
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney BaseAmount { get; set; }

        /// <summary>
        /// Card scheme disclaimer to present to the cardholder
        /// </summary>
        public string DisclaimerDisplay { get; set; }

        /// <summary>
        /// Card scheme disclaimer to print within cardholder receipt
        /// </summary>
        public string DisclaimerReceipt { get; set; }

        public RateDetails Rate { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney TargetAmount { get; set; }
    }
}
