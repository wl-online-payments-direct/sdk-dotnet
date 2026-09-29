/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateAddressResponse
    {
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Streetname
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddressResponse WithCity(string value)
        {
            City = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddressResponse WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddressResponse WithHouseNumber(string value)
        {
            HouseNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddressResponse WithStreet(string value)
        {
            Street = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddressResponse WithZip(string value)
        {
            Zip = value;
            return this;
        }
    }
}
