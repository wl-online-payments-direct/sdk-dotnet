using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.ProductGroups;

namespace OnlinePayments.Sdk.It.Builders.ProductGroups;

public class GetProductGroupParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;
    private long? _amount;
    private bool? _isRecurring;
    private List<string> _hideList = [];

    #region Setters

    public GetProductGroupParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetProductGroupParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public GetProductGroupParamsBuilder WithAmount(long? amount)
    {
        _amount = amount;
        return this;
    }

    public GetProductGroupParamsBuilder WithIsRecurring(bool? isRecurring)
    {
        _isRecurring = isRecurring;
        return this;

    }

    public GetProductGroupParamsBuilder WithHide(string value)
    {
        _hideList.Add(value);
        return this;
    }

    public GetProductGroupParamsBuilder WithHideList(List<string> hideList)
    {
        _hideList = hideList;
        return this;
    }

    #endregion

    public GetProductGroupParams Build()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParams
        {
            CountryCode = _countryCode,
            CurrencyCode = _currencyCode,
            Amount = _amount,
            IsRecurring = _isRecurring
        };

        foreach (string hideListItem in _hideList)
        {
            getProductGroupParams.AddHide(hideListItem);
        }

        return getProductGroupParams;
    }
}
