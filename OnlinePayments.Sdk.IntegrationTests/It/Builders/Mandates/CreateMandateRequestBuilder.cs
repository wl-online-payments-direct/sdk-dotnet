using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Mandates;

public class CreateMandateRequestBuilder
{
    private string _alias = "Test Mandate";
    private string _customerIban = "BE45000253450589";
    private string _companyName = "BEL Labs";
    private string _emailAddress = "wile.e.coyote@acmelabs.com";
    private string _city = "Berlin";
    private string _countryCode = "DE";
    private string _houseNumber = "123";
    private string _street = "Main Street";
    private string _zip = "10115";
    private string _firstName = "John";
    private string _surname = "Doe";
    private string _title = "Mrs";
    private string _customerReference = "CUST123";
    private string _recurrenceType = "UNIQUE";
    private string _signatureType = "UNSIGNED";
    private string _returnUrl = "https://example-mandate-signing-url.com";
    private string _uniqueMandateReference = "MANDATE123";

    #region Setters

    public CreateMandateRequestBuilder WithAlias(string alias)
    {
        _alias = alias;
        return this;
    }

    public CreateMandateRequestBuilder WithCustomerIban(string customerIban)
    {
        _customerIban = customerIban;
        return this;
    }

    public CreateMandateRequestBuilder WithCompanyName(string companyName)
    {
        _companyName = companyName;
        return this;
    }

    public CreateMandateRequestBuilder WithEmailAddress(string emailAddress)
    {
        _emailAddress = emailAddress;
        return this;
    }

    public CreateMandateRequestBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public CreateMandateRequestBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public CreateMandateRequestBuilder WithHouseNumber(string houseNumber)
    {
        _houseNumber = houseNumber;
        return this;
    }

    public CreateMandateRequestBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public CreateMandateRequestBuilder WithZip(string zip)
    {
        _zip = zip;
        return this;
    }

    public CreateMandateRequestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CreateMandateRequestBuilder WithSurname(string surname)
    {
        _surname = surname;
        return this;
    }

    public CreateMandateRequestBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public CreateMandateRequestBuilder WithCustomerReference(string customerReference)
    {
        _customerReference = customerReference;
        return this;
    }

    public CreateMandateRequestBuilder WithRecurrenceType(string recurrenceType)
    {
        _recurrenceType = recurrenceType;
        return this;
    }

    public CreateMandateRequestBuilder WithSignatureType(string signatureType)
    {
        _signatureType = signatureType;
        return this;
    }

    public CreateMandateRequestBuilder WithReturnUrl(string returnUrl)
    {
        _returnUrl = returnUrl;
        return this;
    }

    public CreateMandateRequestBuilder WithUniqueMandateReference(string uniqueMandateReference)
    {
        _uniqueMandateReference = uniqueMandateReference;
        return this;
    }

    #endregion

    public CreateMandateRequest Build() => new()
    {
        Alias = _alias,
        CustomerReference = _customerReference,
        RecurrenceType = _recurrenceType,
        ReturnUrl = _returnUrl,
        SignatureType = _signatureType,
        UniqueMandateReference = _uniqueMandateReference,
        Customer = new MandateCustomer
        {
            CompanyName = _companyName,
            BankAccountIban = new BankAccountIban { Iban = _customerIban },
            MandateAddress = new MandateAddress
            {
                Street = _street,
                HouseNumber = _houseNumber,
                City = _city,
                Zip = _zip,
                CountryCode = _countryCode
            },
            PersonalInformation = new MandatePersonalInformation
            {
                Name = new MandatePersonalName
                {
                    FirstName = _firstName,
                    Surname = _surname,
                },
                Title = _title,
            },
            ContactDetails = new MandateContactDetails
            {
                EmailAddress = _emailAddress,
            }
        }
    };
}
