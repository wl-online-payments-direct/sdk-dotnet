/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CarRentalVehicleData
    {
        /// <summary>
        /// This field contains a code that corresponds to the classification of the rental vehicle.
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// This field contains a unique identifier assigned by the taxi company to the vehicle.
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CarRentalVehicleData WithClassId(string value)
        {
            ClassId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CarRentalVehicleData WithIdentificationNumber(string value)
        {
            IdentificationNumber = value;
            return this;
        }
    }
}
