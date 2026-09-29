/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundPaymentProduct840CustomerAccount
    {
        public string CustomerAccountStatus { get; set; }

        public string CustomerAddressStatus { get; set; }

        /// <summary>
        /// The unique identifier of a PayPal account and will never change in the life cycle of a PayPal account
        /// </summary>
        public string PayerId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundPaymentProduct840CustomerAccount WithCustomerAccountStatus(string value)
        {
            CustomerAccountStatus = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundPaymentProduct840CustomerAccount WithCustomerAddressStatus(string value)
        {
            CustomerAddressStatus = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundPaymentProduct840CustomerAccount WithPayerId(string value)
        {
            PayerId = value;
            return this;
        }
    }
}
