/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AddressPersonal
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
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Object containing the name details of the customer
        /// </summary>
        public PersonalName Name { get; set; }

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
        public AddressPersonal WithAdditionalInfo(string value)
        {
            AdditionalInfo = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithCity(string value)
        {
            City = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithCompanyName(string value)
        {
            CompanyName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithHouseNumber(string value)
        {
            HouseNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithName(PersonalName value)
        {
            Name = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithState(string value)
        {
            State = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithStreet(string value)
        {
            Street = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AddressPersonal WithZip(string value)
        {
            Zip = value;
            return this;
        }
    }
}
