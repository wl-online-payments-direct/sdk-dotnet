/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateAddress
    {
        /// <summary>
        /// City<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// Required for Create hostedCheckout calls where the IBAN is also provided.<para />
        /// </summary>
        public string City { get; set; } = null;

        /// <summary>
        /// ISO 3166-1 alpha-2 country code.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// Required for Create hostedCheckout calls where the IBAN is also provided.<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// House number<para />
        /// </summary>
        public string HouseNumber { get; set; } = null;

        /// <summary>
        /// Streetname.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// Required for Create hostedCheckout calls where the IBAN is also provided.<para />
        /// </summary>
        public string Street { get; set; } = null;

        /// <summary>
        /// Zip code.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// Required for Create hostedCheckout calls where the IBAN is also provided.<para />
        /// </summary>
        public string Zip { get; set; } = null;
    }
}
