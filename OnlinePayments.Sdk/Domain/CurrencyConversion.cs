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
    }
}
