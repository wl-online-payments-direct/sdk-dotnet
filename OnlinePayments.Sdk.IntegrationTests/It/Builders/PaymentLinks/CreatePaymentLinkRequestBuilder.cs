using System;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.PaymentLinks;

public class CreatePaymentLinkRequestBuilder
{
    private long _amount = 100;
    private string _currencyCode = "EUR";

    private bool _displayQrCode = true;
    private bool _isReusableLink = true;

    private DateTimeOffset _expirationDate = DateTimeOffset.UtcNow.AddDays(7);
    private string _description = "Test payment link";
    private string _recipientName = "Wile E. Coyote";
    private string _merchantReference = $"Ref-{Guid.NewGuid().ToString()}";

    #region Setters

    public CreatePaymentLinkRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithDisplayQrCode(bool displayQrCode)
    {
        _displayQrCode = displayQrCode;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithIsReusableLink(bool isReusableLink)
    {
        _isReusableLink = isReusableLink;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithExpirationDate(DateTimeOffset expirationDate)
    {
        _expirationDate = expirationDate;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithRecipientName(string recipientName)
    {
        _recipientName = recipientName;
        return this;
    }

    public CreatePaymentLinkRequestBuilder WithMerchantReference(string merchantReference)
    {
        _merchantReference = merchantReference;
        return this;
    }

    #endregion

    public CreatePaymentLinkRequest Build() => new()
    {
        DisplayQRCode = _displayQrCode,
        IsReusableLink = _isReusableLink,
        PaymentLinkSpecificInput = new()
        {
            ExpirationDate = _expirationDate,
            Description = _description,
            RecipientName = _recipientName
        },
        Order = new()
        {
            AmountOfMoney = new()
            {
                Amount = _amount,
                CurrencyCode = _currencyCode
            },
            References = new()
            {
                MerchantReference = _merchantReference
            }
        }
    };
}
