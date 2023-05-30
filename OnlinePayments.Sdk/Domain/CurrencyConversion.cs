/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversion
    {
        /// <summary>
        /// Dynamic Currency Conversion(DCC) Proposal accepted by user<para />
        /// </summary>
        public bool? AcceptedByUser { get; set; } = null;

        /// <summary>
        /// Details of currency conversion to be proposed to the cardholder<para />
        /// </summary>
        public DccProposal Proposal { get; set; } = null;
    }
}
