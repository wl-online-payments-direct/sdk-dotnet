/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class TokenCardData
    {
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
    }
}
