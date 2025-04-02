/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutResult
    {
        public string Id { get; set; }

        public PayoutOutput PayoutOutput { get; set; }

        /// <summary>
        /// Current high-level status of the payout in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        public PayoutStatusOutput StatusOutput { get; set; }
    }
}
