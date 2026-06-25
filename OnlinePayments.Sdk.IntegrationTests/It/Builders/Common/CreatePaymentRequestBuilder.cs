using System;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Common;

public class CreatePaymentRequestBuilder
{
    private enum PaymentMethodType { Card, PayPalRedirect }

    private string _cardNumber = "4012000033330026";
    private string _cvv = "123";
    private string _cardholderName = "Wile E. Coyote";
    private string _expiryDate = "0530";

    private long _amount = 1000;
    private string _currencyCode = "EUR";

    private string _merchantReference = $"Ref-{Guid.NewGuid().ToString()}";
    private string _merchantCustomerId = "CUST-000001";

    private string _token;
    private bool _autoCapture;

    private PaymentMethodType _paymentMethodType = PaymentMethodType.Card;

    #region Setters

    public CreatePaymentRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CreatePaymentRequestBuilder WithCvv(string cvv)
    {
        _cvv = cvv;
        return this;
    }

    public CreatePaymentRequestBuilder WithCardholderName(string cardholderName)
    {
        _cardholderName = cardholderName;
        return this;
    }

    public CreatePaymentRequestBuilder WithExpiryDate(string expiryDate)
    {
        _expiryDate = expiryDate;
        return this;
    }

    public CreatePaymentRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CreatePaymentRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public CreatePaymentRequestBuilder WithMerchantReference(string merchantReference)
    {
        _merchantReference = merchantReference;
        return this;
    }

    public CreatePaymentRequestBuilder WithPayPalRedirectPaymentMethod()
    {
        _paymentMethodType = PaymentMethodType.PayPalRedirect;
        return this;
    }

    public CreatePaymentRequestBuilder WithMerchantCustomerId(string merchantCustomerId)
    {
        _merchantCustomerId = merchantCustomerId;
        return this;
    }

    public CreatePaymentRequestBuilder WithToken(string token)
    {
        _token = token;
        return this;
    }

    public CreatePaymentRequestBuilder WithCardPaymentMethod()
    {
        _paymentMethodType = PaymentMethodType.Card;
        return this;
    }

    public CreatePaymentRequestBuilder WithAutoCapture(bool autoCapture)
    {
        _autoCapture = autoCapture;
        return this;
    }

    #endregion

    public CreatePaymentRequest Build()
    {
        return _paymentMethodType == PaymentMethodType.Card ? BuildPaymentWithCard() : BuildPaymentWithPayPal();
    }

    #region Build with card

    private CreatePaymentRequest BuildPaymentWithCard() => new()
    {
        CardPaymentMethodSpecificInput = BuildCardPaymentMethodSpecificInput(),
        Order = new()
        {
            AmountOfMoney = new()
            {
                Amount = _amount,
                CurrencyCode = _currencyCode
            },
            Customer = BuildCustomer(),
            References = new()
            {
                MerchantReference = _merchantReference
            }
        }
    };

    #endregion

    #region Build with PayPal

    private CreatePaymentRequest BuildPaymentWithPayPal() => new()
    {
        RedirectPaymentMethodSpecificInput = new()
        {
            PaymentProductId = 840,
            RedirectionData = new() { ReturnUrl = "https://example.com/return" }
        },
        Order = new()
        {
            AmountOfMoney = new()
            {
                Amount = _amount,
                CurrencyCode = _currencyCode
            },
            References = new OrderReferences()
            {
                MerchantReference = _merchantReference,
                Descriptor = "Applefruitcompany",
                MerchantParameters = "SessionID=126548354&ShopperID=73541312"
            }
        }
    };

    #endregion

    #region Private helpers

    private CardPaymentMethodSpecificInput BuildCardPaymentMethodSpecificInput()
    {
        return string.IsNullOrEmpty(_token)
            ? new CardPaymentMethodSpecificInput
            {
                Card = new()
                {
                    Cvv = _cvv,
                    CardholderName = _cardholderName,
                    CardNumber = _cardNumber,
                    ExpiryDate = _expiryDate
                },
                AuthorizationMode = "FINAL_AUTHORIZATION",
                TransactionChannel = "ECOMMERCE",
                ReturnUrl = "https://example.com/return",
                PaymentProductId = 1,
                AutoCapture = _autoCapture ? new AutoCapture { DelayInMinutes = 10 } : null
            }
            : new CardPaymentMethodSpecificInput
            {
                Token = _token,
                AuthorizationMode = "FINAL_AUTHORIZATION",
                TransactionChannel = "ECOMMERCE",
                ReturnUrl = "https://example.com/return",
                PaymentProductId = 1,
                AutoCapture = _autoCapture ? new AutoCapture { DelayInMinutes = 10 } : null
            };
    }

    private Customer BuildCustomer() => new()
    {
        CompanyInformation = new() { Name = "CUST-000001" },
        MerchantCustomerId = _merchantCustomerId,
        Account = new()
        {
            Authentication = new()
            {
                Method = "guest",
                UtcTimestamp = "202309261631"
            },
            ChangeDate = "20200101",
            ChangedDuringCheckout = true,
            CreateDate = "20100101",
            HadSuspiciousActivity = false,
            PasswordChangeDate = "20200101",
            PasswordChangedDuringCheckout = false,
            PaymentAccountOnFile = new()
            {
                CreateDate = "20100101",
                NumberOfCardOnFileCreationAttemptsLast24Hours = 1
            },
            PaymentActivity = new()
            {
                NumberOfPaymentAttemptsLast24Hours = 1,
                NumberOfPaymentAttemptsLastYear = 0,
                NumberOfPurchasesLast6Months = 0
            }
        },
        AccountType = "existing",
        BillingAddress = new()
        {
            CountryCode = "BE",
            City = "Brussels",
            HouseNumber = "3",
            State = "Flemish Brabant",
            Street = "Da Vincilaan",
            Zip = "1930",
            AdditionalInfo = "floor 9"
        },
        ContactDetails = new()
        {
            EmailAddress = "wile.e.coyote@acmelabs.com",
            PhoneNumber = "+321234567890"
        },
        Device = new()
        {
            AcceptHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8",
            BrowserData = new()
            {
                ColorDepth = 99,
                JavaEnabled = true,
                JavaScriptEnabled = true,
                ScreenHeight = "768",
                ScreenWidth = "1024"
            },
            IpAddress = "123.123.123.123",
            Locale = "en_GB",
            UserAgent =
                "Mozilla/5.0(WindowsNT10.0;Win64;x64)AppleWebKit/537.36(KHTML,likeGecko)Chrome/75.0.3770.142Safari/537.36",
            TimezoneOffsetUtcMinutes = "-180"
        },
        PersonalInformation = new()
        {
            Name = new()
            {
                Title = "M.",
                FirstName = "Wile",
                Surname = "Coyote"
            },
            Gender = "male",
            DateOfBirth = "19500101"
        }
    };

    #endregion
}
