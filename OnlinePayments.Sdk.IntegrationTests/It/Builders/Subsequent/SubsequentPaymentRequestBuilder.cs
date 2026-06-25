using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Subsequent;

public class SubsequentPaymentRequestBuilder
{
    private long _amount = 100;
    private string _currencyCode = "EUR";
    private string _subsequentType = "Recurring";
    private string _authorizationMode = "FINAL_AUTHORIZATION";

    #region Setters

    public SubsequentPaymentRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public SubsequentPaymentRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public SubsequentPaymentRequestBuilder WithSubsequentType(string subsequentType)
    {
        _subsequentType = subsequentType;
        return this;
    }

    public SubsequentPaymentRequestBuilder WithAuthorizationMode(string authorizationMode)
    {
        _authorizationMode = authorizationMode;
        return this;
    }

    #endregion

    public SubsequentPaymentRequest Build() => new()
    {
        SubsequentcardPaymentMethodSpecificInput = new()
        {
            AuthorizationMode = _authorizationMode,
            SubsequentType = _subsequentType
        },
        Order = new()
        {
            AmountOfMoney = new()
            {
                Amount = _amount,
                CurrencyCode = _currencyCode
            }
        }
    };
}
