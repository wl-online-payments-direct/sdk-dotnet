/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MarketPlace
    {
        /// <summary>
        /// ISO 3166-1 alpha-2 country code of the retailer.
        /// </summary>
        public string RetailerCountry { get; set; }

        /// <summary>
        /// This field is required if the transaction is performed by a merchant using the marketplace. This field must contain the name of the end merchant.
        /// </summary>
        public string RetailerName { get; set; }
    }
}
