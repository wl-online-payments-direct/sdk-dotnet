using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Payments;

public class RefundRequestBuilder
{
    private long _amount = 1000;
    private string _currencyCode = "EUR";
    private bool? _isFinal;

    #region Setters

    public RefundRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public RefundRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public RefundRequestBuilder WithIsFinal(bool isFinal)
    {
        _isFinal = isFinal;
        return this;
    }

    #endregion

    public RefundRequest Build() => new()
    {
        AmountOfMoney = new AmountOfMoney
        {
            Amount = _amount,
            CurrencyCode = _currencyCode
        },
        IsFinal = _isFinal
    };
}
