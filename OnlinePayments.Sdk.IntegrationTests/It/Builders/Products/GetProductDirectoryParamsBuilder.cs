using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It.Builders.Products;

public class GetProductDirectoryParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;

    #region Setters

    public GetProductDirectoryParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetProductDirectoryParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    #endregion

    public GetProductDirectoryParams Build() => new()
    {
        CountryCode = _countryCode,
        CurrencyCode = _currencyCode
    };
}
