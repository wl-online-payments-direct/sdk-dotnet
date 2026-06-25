using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.ProductGroups;

namespace OnlinePayments.Sdk.It.Builders.ProductGroups;

public class GetProductGroupsParamsBuilder
{
    private string _countryCode;
    private string _currencyCode;
    private long? _amount;
    private bool? _isRecurring;
    private List<string> _hideList = [];

    #region Setters

    public GetProductGroupsParamsBuilder WithCountryCode(string countryCode)
    {
        _countryCode = countryCode;
        return this;
    }

    public GetProductGroupsParamsBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public GetProductGroupsParamsBuilder WithAmount(long? amount)
    {
        _amount = amount;
        return this;
    }

    public GetProductGroupsParamsBuilder WithIsRecurring(bool? isRecurring)
    {
        _isRecurring = isRecurring;
        return this;
    }

    public GetProductGroupsParamsBuilder WithHide(string value)
    {
        _hideList.Add(value);
        return this;
    }

    public GetProductGroupsParamsBuilder WithHideList(List<string> hideList)
    {
        _hideList = hideList;
        return this;
    }

    #endregion

    public GetProductGroupsParams Build()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParams
        {
            CountryCode = _countryCode,
            CurrencyCode = _currencyCode,
            Amount = _amount,
            IsRecurring = _isRecurring
        };

        foreach (string hideListItem in _hideList)
        {
            getProductGroupsParams.AddHide(hideListItem);
        }

        return getProductGroupsParams;
    }
}
