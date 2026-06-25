using System;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.HostedCheckout;

public class CreateHostedCheckoutRequestBuilder
{
    private long _amount = 1000L;
    private string _currency = "EUR";

    private string _merchantReference = GenerateMerchantReference();
    private string _merchantCustomerId = "CUST-000001";
    private string _locale = "en_US";
    private string _returnUrl = "https://example.com/return";
    private bool? _showResultPage = true;
    private int? _sessionTimeout = 600;
    private int? _allowedNumberOfPaymentAttempts = 10;
    private bool? _isRecurring = false;
    private bool? _isNewUnscheduledCardOnFileSeries = false;
    private string _variant;
    private string _tokens;

    private string _countryCode = "US";
    private string _firstName = "Test";
    private string _surname = "User";
    private string _title;
    private string _emailAddress;
    private string _phoneNumber;
    private string _city;
    private string _street;
    private string _houseNumber;
    private string _additionalInfo;
    private string _state;
    private string _zip;

    private PaymentProductFiltersHostedCheckout _paymentProductFilters;
    private SplitPaymentProductFiltersHostedCheckout _splitPaymentProductFilters;
    private Feedbacks _feedbacks;
    private FraudFields _fraudFields;

    private bool? _cardClickToPay = false;
    private bool? _cardGroupCards = false;

    #region Setters

    public CreateHostedCheckoutRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithMerchantReference(string merchantReference)
    {
        _merchantReference = merchantReference;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithMerchantCustomerId(string merchantCustomerId)
    {
        _merchantCustomerId = merchantCustomerId;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithReturnUrl(string returnUrl)
    {
        _returnUrl = returnUrl;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithShowResultPage(bool showResultPage)
    {
        _showResultPage = showResultPage;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithSessionTimeout(int sessionTimeout)
    {
        _sessionTimeout = sessionTimeout;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithAllowedNumberOfPaymentAttempts(int allowedNumberOfPaymentAttempts)
    {
        _allowedNumberOfPaymentAttempts = allowedNumberOfPaymentAttempts;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithIsRecurring(bool isRecurring)
    {
        _isRecurring = isRecurring;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithIsNewUnscheduledCardOnFileSeries(bool isNewUnscheduledCardOnFileSeries)
    {
        _isNewUnscheduledCardOnFileSeries = isNewUnscheduledCardOnFileSeries;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithVariant(string variant)
    {
        _variant = variant;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithTokens(string tokens)
    {
        _tokens = tokens;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithSurname(string surname)
    {
        _surname = surname;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithEmailAddress(string emailAddress)
    {
        _emailAddress = emailAddress;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithPhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithStreet(string street)
    {
        _street = street;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithHouseNumber(string houseNumber)
    {
        _houseNumber = houseNumber;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithAdditionalInfo(string additionalInfo)
    {
        _additionalInfo = additionalInfo;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithState(string state)
    {
        _state = state;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithZip(string zip)
    {
        _zip = zip;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithPaymentProductFilters(
        PaymentProductFiltersHostedCheckout filters)
    {
        _paymentProductFilters = filters;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithSplitPaymentProductFilters(
        SplitPaymentProductFiltersHostedCheckout filters)
    {
        _splitPaymentProductFilters = filters;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithFeedbacks(Feedbacks feedbacks)
    {
        _feedbacks = feedbacks;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithFraudFields(FraudFields fraudFields)
    {
        _fraudFields = fraudFields;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithCardClickToPay(bool cardClickToPay)
    {
        _cardClickToPay = cardClickToPay;
        return this;
    }

    public CreateHostedCheckoutRequestBuilder WithCardGroupCards(bool cardGroupCards)
    {
        _cardGroupCards = cardGroupCards;
        return this;
    }

    #endregion

    public CreateHostedCheckoutRequest Build()
    {
        CreateHostedCheckoutRequest request = new()
        {
            HostedCheckoutSpecificInput = BuildHostedCheckoutSpecificInput(),
            Order = BuildOrder()
        };

        if (_feedbacks != null)
        {
            request.Feedbacks = _feedbacks;
        }

        if (_fraudFields != null)
        {
            request.FraudFields = _fraudFields;
        }

        return request;
    }

    private HostedCheckoutSpecificInput BuildHostedCheckoutSpecificInput()
    {
        HostedCheckoutSpecificInput input = new()
        {
            Locale = _locale,
            ReturnUrl = _returnUrl,
            ShowResultPage = _showResultPage,
            SessionTimeout = _sessionTimeout,
            AllowedNumberOfPaymentAttempts = _allowedNumberOfPaymentAttempts,
            IsRecurring = _isRecurring,
            IsNewUnscheduledCardOnFileSeries = _isNewUnscheduledCardOnFileSeries,
            CardPaymentMethodSpecificInput = new()
            {
                ClickToPay = _cardClickToPay,
                GroupCards = _cardGroupCards
            }
        };

        if (_variant != null)
        {
            input.Variant = _variant;
        }

        if (_tokens != null)
        {
            input.Tokens = _tokens;
        }

        if (_paymentProductFilters != null)
        {
            input.PaymentProductFilters = _paymentProductFilters;
        }

        if (_splitPaymentProductFilters != null)
        {
            input.SplitPaymentProductFilters = _splitPaymentProductFilters;
        }

        return input;
    }

    private Order BuildOrder() =>
        new()
        {
            AmountOfMoney = BuildAmountOfMoney(),
            Customer = BuildCustomer(),
            References = BuildOrderReferences()
        };

    private AmountOfMoney BuildAmountOfMoney() =>
        new()
        {
            Amount = _amount,
            CurrencyCode = _currency
        };

    private OrderReferences BuildOrderReferences() =>
        new()
        {
            MerchantReference = _merchantReference
        };

    private Customer BuildCustomer()
    {
        Customer customer = new()
        {
            MerchantCustomerId = _merchantCustomerId,
            BillingAddress = BuildBillingAddress()
        };

        if (_firstName != null || _surname != null)
        {
            customer.PersonalInformation = BuildPersonalInformation();
        }

        if (_emailAddress != null || _phoneNumber != null)
        {
            customer.ContactDetails = BuildContactDetails();
        }

        return customer;
    }

    private Address BuildBillingAddress()
    {
        Address address = new()
        {
            CountryCode = _countryCode
        };

        if (_city != null)
        {
            address.City = _city;
        }

        if (_street != null)
        {
            address.Street = _street;
        }

        if (_houseNumber != null)
        {
            address.HouseNumber = _houseNumber;
        }

        if (_additionalInfo != null)
        {
            address.AdditionalInfo = _additionalInfo;
        }

        if (_state != null)
        {
            address.State = _state;
        }

        if (_zip != null)
        {
            address.Zip = _zip;
        }

        return address;
    }

    private PersonalInformation BuildPersonalInformation() =>
        new()
        {
            Name = BuildPersonalName()
        };

    private PersonalName BuildPersonalName()
    {
        PersonalName name = new()
        {
            FirstName = _firstName,
            Surname = _surname
        };

        if (_title != null)
        {
            name.Title = _title;
        }

        return name;
    }

    private ContactDetails BuildContactDetails() =>
        new()
        {
            EmailAddress = _emailAddress,
            PhoneNumber = _phoneNumber
        };

    private static string GenerateMerchantReference() =>
        $"Ord-{Guid.NewGuid()}";
}
