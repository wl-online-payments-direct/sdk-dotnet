/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ReattemptInstructions
    {
        /// <summary>
        /// Additional conditions to be met for reattempt. If the data is not provided by the acquirer, these fields are omitted from the response.
        /// </summary>
        public ReattemptInstructionsConditions Conditions { get; set; }

        /// <summary>
        /// Hours to wait before next reattempt.
        /// </summary>
        public int? FrozenPeriod { get; set; }

        /// <summary>
        /// High-level use case.
        /// <c>frozenPeriod</c> and <c>conditions</c>, when provided, only apply if indicator is one of:
        /// <list type="bullet">
        ///   <item><description><c>retryLater</c>: retry with no change;</description></item>
        ///   <item><description><c>updateBeforeRetry</c>: retry requires data updates;
        /// Otherwise:</description></item>
        ///   <item><description><c>neverRetry</c>: the current payment authorization cannot be retried;</description></item>
        ///   <item><description><c>dontStorePanCredentials</c>: no retry and no subsequent payment attempt or payment series using this PAN from credentials on file;</description></item>
        /// </list>
        /// </summary>
        public string Indicator { get; set; }
    }
}
