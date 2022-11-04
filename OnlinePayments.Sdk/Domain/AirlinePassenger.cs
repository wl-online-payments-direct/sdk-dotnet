/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AirlinePassenger
    {
        /// <summary>
        /// Airline loyalty program level for the passenger on the itinerary.<para />
        /// </summary>
        public string AirlineLoyaltyStatus { get; set; } = null;

        /// <summary>
        /// First name of the passenger<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public string FirstName { get; set; } = null;

        /// <summary>
        /// Type of passenger on the itinerary. <para />
        /// </summary>
        public string PassengerType { get; set; } = null;

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
        /// Title of the passenger (this property is used for fraud screening on the payment platform)<para />
        /// </summary>
        public string Title { get; set; } = null;
    }
}
