/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ApiParameters
    {
        /// <summary>
        /// The following fields need to be provided to the amex field within the configuration.
        /// </summary>
        public Amex Amex { get; set; }

        /// <summary>
        /// The following fields need to be provided to the cb field within the configuration.
        /// </summary>
        public PaymentProduct5002defaultBrandParameters Cb { get; set; }

        /// <summary>
        /// The following fields need to be provided to the eftpos field within the configuration.
        /// </summary>
        public PaymentProduct5002defaultBrandParameters Eftpos { get; set; }

        /// <summary>
        /// The following fields need to be provided to the mastercard field within the configuration.
        /// </summary>
        public Mastercard Mastercard { get; set; }

        /// <summary>
        /// The following fields need to be provided to the visa field within the configuration.
        /// </summary>
        public Visa Visa { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApiParameters WithAmex(Amex value)
        {
            Amex = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApiParameters WithCb(PaymentProduct5002defaultBrandParameters value)
        {
            Cb = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApiParameters WithEftpos(PaymentProduct5002defaultBrandParameters value)
        {
            Eftpos = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApiParameters WithMastercard(Mastercard value)
        {
            Mastercard = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApiParameters WithVisa(Visa value)
        {
            Visa = value;
            return this;
        }
    }
}
