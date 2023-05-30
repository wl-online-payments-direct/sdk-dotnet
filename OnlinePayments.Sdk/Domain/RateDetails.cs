/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RateDetails
    {
        /// <summary>
        /// Expressed as a percentage, applied to convert the original amount into the resulting amount without charge<para />
        /// </summary>
        public decimal? ExchangeRate { get; set; } = null;

        /// <summary>
        /// Exchange rate, expressed as a percentage, applied to convert the resulting amount into the original amount<para />
        /// </summary>
        public decimal? InvertedExchangeRate { get; set; } = null;

        /// <summary>
        /// The markup is the percentage added to the exchange rate by a provider when they sell you currency.<para />
        /// </summary>
        public decimal? MarkUpRate { get; set; } = null;

        /// <summary>
        /// Date and time at which the exchange rate has been quoted<para />
        /// </summary>
        public string QuotationDateTime { get; set; } = null;

        /// <summary>
        /// Indicates the exchange rate source name. The rate source is supplied for receipt printing purposes and to meet regulatory requirements where applicable<para />
        /// </summary>
        public string Source { get; set; } = null;
    }
}
