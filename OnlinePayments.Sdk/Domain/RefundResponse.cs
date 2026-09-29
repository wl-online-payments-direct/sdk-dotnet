/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundResponse
    {
        /// <summary>
        /// This is our unique payment transaction identifier.
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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundResponse WithId(string value)
        {
            Id = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundResponse WithRefundOutput(RefundOutput value)
        {
            RefundOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundResponse WithStatus(string value)
        {
            Status = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundResponse WithStatusOutput(OrderStatusOutput value)
        {
            StatusOutput = value;
            return this;
        }
    }
}
