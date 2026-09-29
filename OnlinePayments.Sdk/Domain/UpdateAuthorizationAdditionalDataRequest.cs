/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class UpdateAuthorizationAdditionalDataRequest
    {
        /// <summary>
        /// Object that holds car rental specific data
        /// </summary>
        public CarRentalData CarRentalData { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public UpdateAuthorizationAdditionalDataRequest WithCarRentalData(CarRentalData value)
        {
            CarRentalData = value;
            return this;
        }
    }
}
