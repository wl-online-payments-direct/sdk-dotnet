using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Payments;

public class CancelPaymentRequestBuilder
{
    private long? _amount;
    private string _currencyCode = "EUR";
    private bool? _isFinal;

    #region Setters

    public CancelPaymentRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CancelPaymentRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public CancelPaymentRequestBuilder WithIsFinal(bool isFinal)
    {
        _isFinal = isFinal;
        return this;
    }

    #endregion

    public CancelPaymentRequest Build() => new()
    {
        AmountOfMoney = _amount.HasValue
            ? new AmountOfMoney { Amount = _amount.Value, CurrencyCode = _currencyCode }
            : null,
        IsFinal = _isFinal
    };
}
