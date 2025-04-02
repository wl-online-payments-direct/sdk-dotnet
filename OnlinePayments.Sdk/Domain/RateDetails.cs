/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RateDetails
    {
        /// <summary>
        /// Expressed as a percentage, applied to convert the original amount into the resulting amount without charge
        /// </summary>
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Exchange rate, expressed as a percentage, applied to convert the resulting amount into the original amount
        /// </summary>
        public decimal? InvertedExchangeRate { get; set; }

        /// <summary>
        /// The markup is the percentage added to the exchange rate by a provider when they sell you currency.
        /// </summary>
        public decimal? MarkUpRate { get; set; }

        /// <summary>
        /// Date and time at which the exchange rate has been quoted
        /// </summary>
        public string QuotationDateTime { get; set; }

        /// <summary>
        /// Indicates the exchange rate source name. The rate source is supplied for receipt printing purposes and to meet regulatory requirements where applicable
        /// </summary>
        public string Source { get; set; }
    }
}
