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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutResult WithId(string value)
        {
            Id = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutResult WithPayoutOutput(PayoutOutput value)
        {
            PayoutOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutResult WithStatus(string value)
        {
            Status = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PayoutResult WithStatusOutput(PayoutStatusOutput value)
        {
            StatusOutput = value;
            return this;
        }
    }
}
