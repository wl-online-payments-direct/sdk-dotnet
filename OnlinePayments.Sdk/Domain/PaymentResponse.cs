/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentResponse
    {
        /// <summary>
        /// Hosted Checkout specific information. Populated if the payment was created on the platform through a Hosted Checkout.
        /// </summary>
        public HostedCheckoutSpecificOutput HostedCheckoutSpecificOutput { get; set; }

        /// <summary>
        /// Our unique payment transaction identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Object containing payment details
        /// </summary>
        public PaymentOutput PaymentOutput { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This object has the numeric representation of the current payment status, timestamp of last status change and performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.
        /// </summary>
        public PaymentStatusOutput StatusOutput { get; set; }
    }
}
