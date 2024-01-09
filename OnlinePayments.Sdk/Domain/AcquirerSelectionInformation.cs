/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AcquirerSelectionInformation
    {
        /// <summary>
        /// Specifies whether a fallback occurred from the primary choice of the acquirer selection service.<para />
        /// </summary>
        public int? FallbackLevel { get; set; } = null;

        /// <summary>
        /// Result of the acquirer selection operation<para />
        /// </summary>
        public string Result { get; set; } = null;

        /// <summary>
        /// Name of the rule used to select the acquirer<para />
        /// </summary>
        public string RuleName { get; set; } = null;
    }
}
