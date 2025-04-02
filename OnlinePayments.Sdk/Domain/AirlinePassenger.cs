/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class AirlinePassenger
    {
        /// <summary>
        /// Airline loyalty program level for the passenger on the itinerary.
        /// </summary>
        public string AirlineLoyaltyStatus { get; set; }

        /// <summary>
        /// First name of the passenger
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Type of passenger on the itinerary.
        /// </summary>
        public string PassengerType { get; set; }

        /// <summary>
        /// Surname of the passenger
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Surname prefix or middle name of the passenger
        /// This field is used by the following payment products: 840
        /// </summary>
        public string SurnamePrefix { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Title of the passenger (this property is used for fraud screening on the payment platform)
        /// </summary>
        [Obsolete("This field is not used by any payment product Title of the passenger (this property is used for fraud screening on the payment platform)")]
        public string Title { get; set; }
    }
}
