/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionResult
    {
        /// <summary>
        /// Functional response to the request:
        /// <list type="bullet">
        ///   <item><description>Allowed: Dynamic currency conversion may be offered to the cardholder</description></item>
        ///   <item><description>InvalidCard: The card is not valid for dynamic currency conversion</description></item>
        ///   <item><description>InvalidMerchant: The card acceptor has not been recognised</description></item>
        ///   <item><description>NoRate: Exchange rates are not available</description></item>
        ///   <item><description>NotAvailable: Dynamic currency conversion is not available for other reason</description></item>
        /// </list>
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Plain text explaining the result of the currency conversion request
        /// </summary>
        public string ResultReason { get; set; }
    }
}
