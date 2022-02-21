/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundResponse
    {
        public string Id { get; set; } = null;

        /// <summary>
        /// Object containing refund details<para />
        /// </summary>
        public RefundOutput RefundOutput { get; set; } = null;

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.<para />
        /// </summary>
        public string Status { get; set; } = null;

        public OrderStatusOutput StatusOutput { get; set; } = null;
    }
}
