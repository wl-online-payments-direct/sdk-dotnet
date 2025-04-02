/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class FraudResults
    {
        /// <summary>
        /// Resulting advice of the fraud prevention checks. Possible values are:
        /// <list type="bullet">
        ///   <item><description>accepted - Based on the checks performed the transaction can be accepted</description></item>
        ///   <item><description>challenged - Based on the checks performed the transaction should be manually reviewed</description></item>
        ///   <item><description>denied - Based on the checks performed the transaction should be rejected</description></item>
        ///   <item><description>no-advice - No fraud check was requested/performed</description></item>
        ///   <item><description>error - The fraud check resulted an error. Note that the fraud check was thus not performed.</description></item>
        /// </list>
        /// </summary>
        public string FraudServiceResult { get; set; }
    }
}
