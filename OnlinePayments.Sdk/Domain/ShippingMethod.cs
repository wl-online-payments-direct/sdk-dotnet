/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ShippingMethod
    {
        /// <summary>
        /// Details about the shipping method
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Name of the shipping method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of hours to delivery
        /// </summary>
        public int? Speed { get; set; }

        /// <summary>
        /// Shipping method type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingMethod WithDetails(string value)
        {
            Details = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingMethod WithName(string value)
        {
            Name = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingMethod WithSpeed(int? value)
        {
            Speed = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShippingMethod WithType(string value)
        {
            Type = value;
            return this;
        }
    }
}
