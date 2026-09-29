/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversion
    {
        /// <summary>
        /// Dynamic Currency Conversion(DCC) Proposal accepted by user
        /// </summary>
        public bool? AcceptedByUser { get; set; }

        /// <summary>
        /// Details of currency conversion to be proposed to the cardholder
        /// </summary>
        public DccProposal Proposal { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversion WithAcceptedByUser(bool? value)
        {
            AcceptedByUser = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversion WithProposal(DccProposal value)
        {
            Proposal = value;
            return this;
        }
    }
}
