using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.PreAuthorization;

public class IncrementAuthorizationRequestBuilder
{
    private long _amount = 1500;
    private string _currencyCode = "EUR";

    #region Setters

    public IncrementAuthorizationRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public IncrementAuthorizationRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    #endregion

    public IncrementAuthorizationRequest Build() => new()
    {
        AmountOfMoney = new AmountOfMoney
        {
            Amount = _amount,
            CurrencyCode = _currencyCode
        }
    };
}
