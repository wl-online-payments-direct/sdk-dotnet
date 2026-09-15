/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CarRentalData
    {
        /// <summary>
        /// This field contains the Auto Rental Agreement/Invoice Number (a.k.a., contract number) that corresponds to the rental agreement issued by the auto rental agency and signed by the cardholder. Amex =&lt; an1-20 characters MasterCard =&lt; an1-9 characters Visa =&lt; an25 characters
        /// </summary>
        public string AgreementNumber { get; set; }

        /// <summary>
        /// Cardholder has been notified of charge?
        /// </summary>
        public bool? CardholderNotified { get; set; }

        /// <summary>
        /// Fare amount (must be using currency of the transaction)
        /// </summary>
        public long? ChargesAmount { get; set; }

        /// <summary>
        /// Indicates type of additional charges added to an cardholder’s bill after return.
        /// </summary>
        public string ChargesCategory { get; set; }

        /// <summary>
        /// This field contains a value that corresponds to the distance traveled during the rental period. Amex =&lt; n1-5 MasterCard =&lt; n1-4 Visa =&lt; n1-5
        /// </summary>
        public int? DistanceMeasure { get; set; }

        /// <summary>
        /// This field contains a code that corresponds to the unit of measure applicable to the distance traveled.
        /// </summary>
        public string DistanceUnit { get; set; }

        /// <summary>
        /// Unique identifier of the driver
        /// </summary>
        public string DriverIdentificationNumber { get; set; }

        /// <summary>
        /// This field contains the driver's Tax Identification Number (Tax ID). Amex =&lt; an1-20 Visa =&lt; an1-20
        /// </summary>
        public string DriverTaxNumber { get; set; }

        /// <summary>
        /// Object containing specific data regarding the pickup or return of a rental car
        /// </summary>
        public CarRentalPickupReturnData Pickup { get; set; }

        /// <summary>
        /// Fare amount.
        /// </summary>
        public long? RentalRateAmount { get; set; }

        /// <summary>
        /// Indicates daily, weekly or monthly rental rate
        /// </summary>
        public string RentalRateType { get; set; }

        /// <summary>
        /// This field contains the name of the person or business entity charged for the reservation or vehicle rental.
        /// </summary>
        public string RenterName { get; set; }

        /// <summary>
        /// Object containing specific data regarding the pickup or return of a rental car
        /// </summary>
        public CarRentalPickupReturnData Return { get; set; }

        /// <summary>
        /// This field indicate the taxable status (taxable/tax exempt).
        /// </summary>
        public bool? TaxExemptIndicator { get; set; }

        /// <summary>
        /// Customer service toll free number.
        /// </summary>
        public string TollFreeNumber { get; set; }

        /// <summary>
        /// Object containing specific data regarding the vehicle
        /// </summary>
        public CarRentalVehicleData Vehicle { get; set; }
    }
}
