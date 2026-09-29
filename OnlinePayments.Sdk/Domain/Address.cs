/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Address
    {
        /// <summary>
        /// Second line of street or additional address information
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// ISO 3166-2 country subdivision code
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithAdditionalInfo(string value)
        {
            AdditionalInfo = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithCity(string value)
        {
            City = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithHouseNumber(string value)
        {
            HouseNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithState(string value)
        {
            State = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithStreet(string value)
        {
            Street = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Address WithZip(string value)
        {
            Zip = value;
            return this;
        }
    }
}
