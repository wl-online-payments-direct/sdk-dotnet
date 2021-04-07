/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class AirlinePassenger
    {
        /// <summary>
        /// First name of the passenger<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public string FirstName { get; set; } = null;

        /// <summary>
        /// Surname of the passenger<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public string Surname { get; set; } = null;

        /// <summary>
        /// Surname prefix or middle name of the passenger<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string SurnamePrefix { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Title of the passenger (this property is used for fraud screening on the Ogone Payment Platform)<para />
        /// </summary>
        public string Title { get; set; } = null;
    }
}
