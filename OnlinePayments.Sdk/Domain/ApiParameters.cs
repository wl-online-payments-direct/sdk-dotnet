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
    }
}
