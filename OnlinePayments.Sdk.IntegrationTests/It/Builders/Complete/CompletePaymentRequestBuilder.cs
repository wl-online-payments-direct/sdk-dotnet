using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Complete;

public class CompletePaymentRequestBuilder
{
    private long _amount = 1000;
    private string _currencyCode = "EUR";
    private string _cardNumber;
    private string _cardholderName;
    private string _expiryDate;
    private Order _orderOverride;
    private bool _useOrderOverride;

    #region Setters

    public CompletePaymentRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CompletePaymentRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public CompletePaymentRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CompletePaymentRequestBuilder WithCardholderName(string cardholderName)
    {
        _cardholderName = cardholderName;
        return this;
    }

    public CompletePaymentRequestBuilder WithExpiryDate(string expiryDate)
    {
        _expiryDate = expiryDate;
        return this;
    }

    public CompletePaymentRequestBuilder WithOrder(Order order)
    {
        _orderOverride = order;
        _useOrderOverride = true;

        return this;
    }

    #endregion

    public CompletePaymentRequest Build()
    {
        CompletePaymentRequest request = new CompletePaymentRequest
        {
            Order = _useOrderOverride ? _orderOverride : new Order
            {
                AmountOfMoney = new AmountOfMoney
                {
                    Amount = _amount,
                    CurrencyCode = _currencyCode
                }
            }
        };

        if (!string.IsNullOrEmpty(_cardNumber) || !string.IsNullOrEmpty(_cardholderName) || !string.IsNullOrEmpty(_expiryDate))
        {
            request.CardPaymentMethodSpecificInput = new CompletePaymentCardPaymentMethodSpecificInput
            {
                Card = new CardWithoutCvv
                {
                    CardNumber = _cardNumber,
                    CardholderName = _cardholderName,
                    ExpiryDate = _expiryDate
                }
            };
        }

        return request;
    }
}
