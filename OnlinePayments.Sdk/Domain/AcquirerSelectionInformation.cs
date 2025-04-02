/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AcquirerSelectionInformation
    {
        /// <summary>
        /// Specifies whether a fallback occurred from the primary choice of the acquirer selection service.
        /// </summary>
        public int? FallbackLevel { get; set; }

        /// <summary>
        /// Result of the acquirer selection operation
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Name of the rule used to select the acquirer
        /// </summary>
        public string RuleName { get; set; }
    }
}
