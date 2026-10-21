using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.PreAuthorization;

public class UpdateAuthorizationAdditionalDataRequestBuilder
{
    private string _chargesCategory = "gas";
    private bool _minimal;

    #region Setters

    public UpdateAuthorizationAdditionalDataRequestBuilder WithChargesCategory(string chargesCategory)
    {
        _chargesCategory = chargesCategory;
        return this;
    }

    public UpdateAuthorizationAdditionalDataRequestBuilder WithMinimalCarRentalData()
    {
        _minimal = true;
        return this;
    }

    #endregion

    public UpdateAuthorizationAdditionalDataRequest Build() => new()
    {
        CarRentalData = _minimal ? BuildMinimalCarRentalData() : BuildFullCarRentalData()
    };

    #region Private helpers

    private CarRentalData BuildMinimalCarRentalData() => new()
    {
        AgreementNumber = "A1234567",
        ChargesAmount = 0,
        ChargesCategory = _chargesCategory,
        PickupDetails = BuildPickupDetails(),
        ReturnDetails = BuildReturnDetails(),
        RentalRateAmount = 1000,
        RentalRateType = "daily",
        RenterName = "Wile E. Coyote"
    };

    private CarRentalData BuildFullCarRentalData()
    {
        CarRentalData carRentalData = BuildMinimalCarRentalData();

        carRentalData.CardholderNotified = true;
        carRentalData.DistanceMeasure = 250;
        carRentalData.DistanceUnit = "kilometers";
        carRentalData.DriverIdentificationNumber = "DRV123456";
        carRentalData.DriverTaxNumber = "BE0123456789";
        carRentalData.TaxExemptIndicator = false;
        carRentalData.TollFreeNumber = "0800123456";
        carRentalData.Vehicle = new CarRentalVehicleData
        {
            ClassId = "CDMR",
            IdentificationNumber = "VIN123456"
        };

        return carRentalData;
    }

    private static CarRentalPickupReturnData BuildPickupDetails() => new()
    {
        Address = "Da Vincilaan 3",
        City = "Brussels",
        Country = 56,
        Date = "2026-09-28T090000.000Z",
        Location = "Brussels Airport",
        Postcode = "1930",
        State = "Flemish Brabant"
    };

    private static CarRentalPickupReturnData BuildReturnDetails() => new()
    {
        Address = "Da Vincilaan 3",
        City = "Brussels",
        Country = 56,
        Date = "2026-09-30T090000.000Z",
        Location = "Brussels Airport",
        Postcode = "1930",
        State = "Flemish Brabant"
    };

    #endregion
}
