/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutResult
    {
        public string Id { get; set; } = null;

        public PayoutOutput PayoutOutput { get; set; } = null;

        /// <summary>
        /// Current high-level status of the payout in a human-readable form.<para />
        /// </summary>
        public string Status { get; set; } = null;

        public PayoutStatusOutput StatusOutput { get; set; } = null;
    }
}
