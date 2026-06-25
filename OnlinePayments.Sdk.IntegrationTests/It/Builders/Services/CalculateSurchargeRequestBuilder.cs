using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Services;

public class CalculateSurchargeRequestBuilder
{
    private string _cardNumber;
    private long _amount = 1000L;
    private string _currencyCode = "EUR";

    #region Setters

    public CalculateSurchargeRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CalculateSurchargeRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CalculateSurchargeRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    #endregion

    public CalculateSurchargeRequest Build() => new()
    {
        CardSource = new CardSource
        {
            Card  = new SurchargeCalculationCard
            {
                CardNumber =  _cardNumber
            }
        },
        AmountOfMoney = new AmountOfMoney
        {
            Amount = _amount,
            CurrencyCode = _currencyCode
        }
    };
}
