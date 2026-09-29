/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3203SpecificOutput
    {
        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal BillingAddress { get; set; }

        /// <summary>
        /// Object containing address information
        /// </summary>
        public AddressPersonal ShippingAddress { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3203SpecificOutput WithBillingAddress(AddressPersonal value)
        {
            BillingAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3203SpecificOutput WithShippingAddress(AddressPersonal value)
        {
            ShippingAddress = value;
            return this;
        }
    }
}
