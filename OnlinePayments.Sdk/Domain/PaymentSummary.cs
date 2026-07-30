/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentSummary
    {
        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Summary of payment output details
        /// </summary>
        public PaymentOutputSummary PaymentOutput { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Summary of payment status output with essential information
        /// </summary>
        public PaymentStatusOutputSummary StatusOutput { get; set; }
    }
}
