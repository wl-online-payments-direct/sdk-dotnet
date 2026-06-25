using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Services;

public class CurrencyConversionRequestBuilder
{
    private string _cardNumber;
    private long _amount = 1000L;
    private string _currencyCode = "EUR";

    #region Setters

    public CurrencyConversionRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CurrencyConversionRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CurrencyConversionRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    #endregion

    public CurrencyConversionRequest Build() => new()
    {
        CardSource = new DccCardSource
        {
            Card = new CardInfo
            {
                CardNumber =  _cardNumber
            }
        },
        Transaction = new Transaction
        {
            Amount = new AmountOfMoney
            {
                Amount =  _amount,
                CurrencyCode = _currencyCode
            }
        }
    };
}
