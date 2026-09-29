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

        /// <summary>
        /// Rate details given by the Dynamic Currency Conversion(DCC) provider
        /// </summary>
        public RateDetails Rate { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney TargetAmount { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccProposal WithBaseAmount(AmountOfMoney value)
        {
            BaseAmount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccProposal WithDisclaimerDisplay(string value)
        {
            DisclaimerDisplay = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccProposal WithDisclaimerReceipt(string value)
        {
            DisclaimerReceipt = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccProposal WithRate(RateDetails value)
        {
            Rate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccProposal WithTargetAmount(AmountOfMoney value)
        {
            TargetAmount = value;
            return this;
        }
    }
}
