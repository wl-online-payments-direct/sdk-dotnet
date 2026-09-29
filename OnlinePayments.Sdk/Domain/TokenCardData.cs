/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenCardData
    {
        /// <summary>
        /// Card BIN details
        /// </summary>
        public CardBinDetails CardBinDetails { get; set; }

        public CardWithoutCvv CardWithoutCvv { get; set; }

        /// <summary>
        /// For cobranded cards, this field indicates the brand selection method:
        /// <list type="bullet">
        ///   <item><description>default - The holder implicitly accepted the default brand.</description></item>
        ///   <item><description>alternative - The holder explicitly selected an alternative brand.</description></item>
        ///   <item><description>notApplicable - The card is not cobranded.</description></item>
        /// </list>
        /// </summary>
        public string CobrandSelectionIndicator { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCardData WithCardBinDetails(CardBinDetails value)
        {
            CardBinDetails = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCardData WithCardWithoutCvv(CardWithoutCvv value)
        {
            CardWithoutCvv = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public TokenCardData WithCobrandSelectionIndicator(string value)
        {
            CobrandSelectionIndicator = value;
            return this;
        }
    }
}
