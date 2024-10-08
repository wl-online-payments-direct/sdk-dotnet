/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AddressPersonal
    {
        /// <summary>
        /// Second line of street or additional address information<para />
        /// </summary>
        public string AdditionalInfo { get; set; } = null;

        /// <summary>
        /// City<para />
        /// </summary>
        public string City { get; set; } = null;

        /// <summary>
        /// Company Name<para />
        /// </summary>
        public string CompanyName { get; set; } = null;

        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// House number<para />
        /// </summary>
        public string HouseNumber { get; set; } = null;

        /// <summary>
        /// Object containing the name details of the customer<para />
        /// </summary>
        public PersonalName Name { get; set; } = null;

        /// <summary>
        /// ISO 3166-2 country subdivision code<para />
        /// </summary>
        public string State { get; set; } = null;

        /// <summary>
        /// Street name<para />
        /// </summary>
        public string Street { get; set; } = null;

        /// <summary>
        /// Zip code<para />
        /// </summary>
        public string Zip { get; set; } = null;
    }
}
