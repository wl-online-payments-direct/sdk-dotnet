/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionResponse
    {
        /// <summary>
        /// The identifier of the Dynamic Currency Conversion(DCC) session that has been created. 'dccSessionId' will be populated exclusively when the result is &quot;Allowed&quot; for other outcomes such as &quot;InvalidCard&quot;, &quot;InvalidMerchant&quot;, &quot;NoRate&quot; or &quot;NotAvailable&quot; this field value will be an empty string.
        /// </summary>
        public string DccSessionId { get; set; }

        /// <summary>
        /// Details of currency conversion to be proposed to the cardholder
        /// </summary>
        public DccProposal Proposal { get; set; }

        /// <summary>
        /// Result of a requested currency conversion
        /// </summary>
        public CurrencyConversionResult Result { get; set; }
    }
}
