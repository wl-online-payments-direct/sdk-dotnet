using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It.Builders.Products;

public class GetPaymentProductsParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;
    private string _locale;
    private long? _amount;
    private bool? _isRecurring;
    private List<string> _hideList = [];
    private string _operationType;

    #region Setters

    public GetPaymentProductsParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithAmount(long? amount)
    {
        _amount = amount;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithIsRecurring(bool? isRecurring)
    {
        _isRecurring = isRecurring;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithHide(string hide)
    {
        _hideList.Add(hide);
        return this;
    }

    public GetPaymentProductsParamsBuilder WithHideList(List<string> hideList)
    {
        _hideList = hideList;
        return this;
    }

    public GetPaymentProductsParamsBuilder WithOperationType(string operationType)
    {
        _operationType = operationType;
        return this;
    }

    #endregion

    public GetPaymentProductsParams Build()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParams
        {
            CountryCode = _countryCode,
            CurrencyCode = _currencyCode,
            Locale = _locale,
            Amount = _amount,
            IsRecurring = _isRecurring,
            OperationType = _operationType
        };

        foreach (string hideListItem in _hideList)
        {
            getPaymentProductsParams.AddHide(hideListItem);
        }

        return getPaymentProductsParams;
    }
}
