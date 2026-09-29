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
        /// Passenger's residence country defined in ISO 3166-1 alpha-2.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The date of birth of the passenger.
        /// Format YYYYMMDD
        /// </summary>
        public string DateOfBirth { get; set; }

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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithAirlineLoyaltyStatus(string value)
        {
            AirlineLoyaltyStatus = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithDateOfBirth(string value)
        {
            DateOfBirth = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithFirstName(string value)
        {
            FirstName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithPassengerType(string value)
        {
            PassengerType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithSurname(string value)
        {
            Surname = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlinePassenger WithSurnamePrefix(string value)
        {
            SurnamePrefix = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("This field is not used by any payment product Title of the passenger (this property is used for fraud screening on the payment platform)")]
        public AirlinePassenger WithTitle(string value)
        {
            Title = value;
            return this;
        }
    }
}
