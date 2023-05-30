/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionResult
    {
        /// <summary>
        /// Functional response to the request:<para />
        ///  * Allowed: Dynamic currency conversion may be offered to the cardholder<para />
        ///  * InvalidCard: The card is not valid for dynamic currency conversion<para />
        ///  * InvalidMerchant: The card acceptor has not been recognised<para />
        ///  * NoRate: Exchange rates are not available<para />
        ///  * NotAvailable: Dynamic currency conversion is not available for other reason<para />
        /// </summary>
        public string Result { get; set; } = null;

        /// <summary>
        /// Plain text explaining the result of the currency conversion request<para />
        /// </summary>
        public string ResultReason { get; set; } = null;
    }
}
