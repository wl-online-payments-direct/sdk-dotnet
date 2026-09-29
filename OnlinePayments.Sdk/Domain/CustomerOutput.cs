/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerOutput
    {
        /// <summary>
        /// Object containing information on the device and browser of the customer
        /// </summary>
        public CustomerDeviceOutput Device { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerOutput WithDevice(CustomerDeviceOutput value)
        {
            Device = value;
            return this;
        }
    }
}
