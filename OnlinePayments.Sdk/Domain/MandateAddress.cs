/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateAddress
    {
        /// <summary>
        /// City
        /// Required for Create mandate and Create payment calls.
        /// Required for Create hostedCheckout calls where the IBAN is also provided.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code.
        /// Required for Create mandate and Create payment calls.
        /// Required for Create hostedCheckout calls where the IBAN is also provided.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// House number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Streetname.
        /// Required for Create mandate and Create payment calls.
        /// Required for Create hostedCheckout calls where the IBAN is also provided.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Zip code.
        /// Required for Create mandate and Create payment calls.
        /// Required for Create hostedCheckout calls where the IBAN is also provided.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddress WithCity(string value)
        {
            City = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddress WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddress WithHouseNumber(string value)
        {
            HouseNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddress WithStreet(string value)
        {
            Street = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateAddress WithZip(string value)
        {
            Zip = value;
            return this;
        }
    }
}
