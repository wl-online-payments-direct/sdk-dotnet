/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionResponse
    {
        /// <summary>
        /// The identifier of the Dynamic Currency Conversion(DCC) session that has been created.<para />
        /// </summary>
        public string DccSessionId { get; set; } = null;

        /// <summary>
        /// Details of currency conversion to be proposed to the cardholder<para />
        /// </summary>
        public DccProposal Proposal { get; set; } = null;

        /// <summary>
        /// Result of a requested currency conversion<para />
        /// </summary>
        public CurrencyConversionResult Result { get; set; } = null;
    }
}
