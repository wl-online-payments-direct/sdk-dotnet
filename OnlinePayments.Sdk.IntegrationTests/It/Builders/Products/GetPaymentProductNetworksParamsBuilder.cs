using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It.Builders.Products;

public class GetPaymentProductNetworksParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;
    private long? _amount;
    private bool? _isRecurring;

    #region Setters

    public GetPaymentProductNetworksParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetPaymentProductNetworksParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public GetPaymentProductNetworksParamsBuilder WithAmount(long? amount)
    {
        _amount = amount;
        return this;
    }

    public GetPaymentProductNetworksParamsBuilder WithIsRecurring(bool? isRecurring)
    {
        _isRecurring = isRecurring;
        return this;
    }

    #endregion

    public GetPaymentProductNetworksParams Build() => new()
    {
        CountryCode = _countryCode,
        CurrencyCode = _currencyCode,
        Amount = _amount,
        IsRecurring = _isRecurring
    };
}
