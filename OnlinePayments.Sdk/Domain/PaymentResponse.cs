/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentResponse
    {
        /// <summary>
        /// Hosted Checkout specific information. Populated if the payment was created on the platform through a Hosted Checkout.<para />
        /// </summary>
        public HostedCheckoutSpecificOutput HostedCheckoutSpecificOutput { get; set; } = null;

        /// <summary>
        /// Our unique payment transaction identifier<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Object containing payment details<para />
        /// </summary>
        public PaymentOutput PaymentOutput { get; set; } = null;

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.<para />
        /// </summary>
        public string Status { get; set; } = null;

        /// <summary>
        /// This object has the numeric representation of the current payment status, timestamp of last status change and performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.<para />
        /// </summary>
        public PaymentStatusOutput StatusOutput { get; set; } = null;
    }
}
