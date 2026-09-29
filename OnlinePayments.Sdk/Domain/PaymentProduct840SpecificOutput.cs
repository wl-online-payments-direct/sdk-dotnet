/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct840SpecificOutput
    {
        /// <summary>
        /// Deprecated - Use billingPersonalAddress instead
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal BillingPersonalAddress { get; set; }

        /// <summary>
        /// Object containing the details of the PayPal account
        /// </summary>
        public PaymentProduct840CustomerAccount CustomerAccount { get; set; }

        /// <summary>
        /// Deprecated - Use shippingAddress instead
        /// </summary>
        public Address CustomerAddress { get; set; }

        /// <summary>
        /// Id of a transaction given by PayPal
        /// </summary>
        public string PayPalTransactionId { get; set; }

        /// <summary>
        /// Kind of seller protection in force for the PayPal transaction
        /// </summary>
        public ProtectionEligibility ProtectionEligibility { get; set; }

        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal ShippingAddress { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithBillingAddress(Address value)
        {
            BillingAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithBillingPersonalAddress(AddressPersonal value)
        {
            BillingPersonalAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithCustomerAccount(PaymentProduct840CustomerAccount value)
        {
            CustomerAccount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithCustomerAddress(Address value)
        {
            CustomerAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithPayPalTransactionId(string value)
        {
            PayPalTransactionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithProtectionEligibility(ProtectionEligibility value)
        {
            ProtectionEligibility = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct840SpecificOutput WithShippingAddress(AddressPersonal value)
        {
            ShippingAddress = value;
            return this;
        }
    }
}
