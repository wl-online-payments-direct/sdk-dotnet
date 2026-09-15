/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CarRentalPickupReturnData
    {
        /// <summary>
        /// Address of the pickup/return location
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City of the pickup/return location
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country of the pickup/return location ISO 3166-1 numeric
        /// </summary>
        public int? Country { get; set; }

        /// <summary>
        /// UTC Time at which the vehicle was rented/picked up or returned.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// This field contains data that uniquely identifies the location where the car was picked up or returned (e.g., DBA name, hotel, airport, etc.).
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Postal code of the pickup/return location
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// State/region of the pickup/return location
        /// </summary>
        public string State { get; set; }
    }
}
