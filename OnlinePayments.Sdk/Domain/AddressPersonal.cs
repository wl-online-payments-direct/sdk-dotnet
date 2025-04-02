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
    }
}
