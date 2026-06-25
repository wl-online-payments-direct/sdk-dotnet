using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It.Builders.Products;

public class GetPaymentProductParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;
    private string _locale;
    private long? _amount;
    private bool? _isRecurring;
    private List<string> _hideList = [];
    private string _operationType;

    #region Setters

    public GetPaymentProductParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetPaymentProductParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public GetPaymentProductParamsBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public GetPaymentProductParamsBuilder WithAmount(long? amount)
    {
        _amount = amount;
        return this;
    }

    public GetPaymentProductParamsBuilder WithIsRecurring(bool? isRecurring)
    {
        _isRecurring = isRecurring;
        return this;
    }

    public GetPaymentProductParamsBuilder WithHide(string hide)
    {
        _hideList.Add(hide);
        return this;
    }

    public GetPaymentProductParamsBuilder WithHideList(List<string> hideList)
    {
        _hideList = hideList;
        return this;
    }

    public GetPaymentProductParamsBuilder WithOperationType(string operationType)
    {
        _operationType = operationType;
        return this;
    }

    #endregion

    public GetPaymentProductParams Build()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParams
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
            getPaymentProductParams.AddHide(hideListItem);
        }

        return getPaymentProductParams;
    }
}
