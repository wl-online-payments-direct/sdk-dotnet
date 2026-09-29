/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct840
    {
        /// <summary>
        /// Contains an identifier supplied by PayPal which must be provided to the PayPal JavaScript SDK.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840 WithOrderId(string value)
        {
            OrderId = value;
            return this;
        }
    }
}
