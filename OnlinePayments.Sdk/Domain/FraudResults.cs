/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class FraudResults
    {
        /// <summary>
        /// Resulting advice of the fraud prevention checks. Possible values are:<para />
        /// * accepted - Based on the checks performed the transaction can be accepted<para />
        /// * challenged - Based on the checks performed the transaction should be manually reviewed<para />
        /// * denied - Based on the checks performed the transaction should be rejected<para />
        /// * no-advice - No fraud check was requested/performed<para />
        /// * error - The fraud check resulted an error. Note that the fraud check was thus not performed.<para />
        /// </summary>
        public string FraudServiceResult { get; set; } = null;
    }
}
