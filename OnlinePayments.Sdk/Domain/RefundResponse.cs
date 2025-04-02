/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundResponse
    {
        /// <summary>
        /// Our unique payment transaction identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Object containing refund details
        /// </summary>
        public RefundOutput RefundOutput { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        public OrderStatusOutput StatusOutput { get; set; }
    }
}
