using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Payouts;

public class CreatePayoutRequestBuilder
{
    private long _amount = 1000;
    private string _currencyCode = "EUR";

    private string _cardNumber = "4012000033330026";
    private string _cardholderName = "Wile E. Coyote";
    private string _cvv = "123";
    private string _expiryDate = "0530";

    private int _paymentProductId = 1;
    private string _payoutReason = "Refund";

    #region Setters

    public CreatePayoutRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CreatePayoutRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public CreatePayoutRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CreatePayoutRequestBuilder WithCardholderName(string cardholderName)
    {
        _cardholderName = cardholderName;
        return this;
    }

    public CreatePayoutRequestBuilder WithCvv(string cvv)
    {
        _cvv = cvv;
        return this;
    }

    public CreatePayoutRequestBuilder WithExpiryDate(string expiryDate)
    {
        _expiryDate = expiryDate;
        return this;
    }

    public CreatePayoutRequestBuilder WithPaymentProductId(int paymentProductId)
    {
        _paymentProductId = paymentProductId;
        return this;
    }

    public CreatePayoutRequestBuilder WithPayoutReason(string payoutReason)
    {
        _payoutReason = payoutReason;
        return this;
    }

    #endregion

    public CreatePayoutRequest Build() => new()
    {
        CardPayoutMethodSpecificInput = new()
        {
            Card = new()
            {
                CardNumber = _cardNumber,
                Cvv = _cvv,
                CardholderName = _cardholderName,
                ExpiryDate = _expiryDate
            },
            PaymentProductId = _paymentProductId,
            PayoutReason = _payoutReason
        },
        AmountOfMoney = new()
        {
            Amount = _amount,
            CurrencyCode = _currencyCode
        }
    };
}
