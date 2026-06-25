using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Common;

public class CreateTokenRequestBuilder
{
    private string _cardNumber = "4567350000427977";
    private string _cvv = "123";
    private string _expiryDate = "1230";
    private string _cardholderName = "John Doe";
    private int _paymentProductId = 1;
    private string _encryptedCustomerInput;
    private string _cobrandSelectionIndicator;

    #region Setters

    public CreateTokenRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public CreateTokenRequestBuilder WithCvv(string cvv)
    {
        _cvv = cvv;
        return this;
    }

    public CreateTokenRequestBuilder WithExpiryDate(string expiryDate)
    {
        _expiryDate = expiryDate;
        return this;
    }

    public CreateTokenRequestBuilder WithCardholderName(string cardholderName)
    {
        _cardholderName = cardholderName;
        return this;
    }

    public CreateTokenRequestBuilder WithPaymentProductId(int paymentProductId)
    {
        _paymentProductId = paymentProductId;
        return this;
    }

    public CreateTokenRequestBuilder WithEncryptedCustomerInput(string encryptedCustomerInput)
    {
        _encryptedCustomerInput = encryptedCustomerInput;
        return this;
    }

    public CreateTokenRequestBuilder WithCobrandSelectionIndicator(string cobrandSelectionIndicator)
    {
        _cobrandSelectionIndicator = cobrandSelectionIndicator;
        return this;
    }

    #endregion

    public CreateTokenRequest Build()
    {
        if (_encryptedCustomerInput != null)
        {
            return new()
            {
                PaymentProductId = _paymentProductId,
                EncryptedCustomerInput = _encryptedCustomerInput
            };
        }

        return new()
        {
            PaymentProductId = _paymentProductId,
            Card = new()
            {
                Data = new()
                {
                    Card = new()
                    {
                        CardholderName = _cardholderName,
                        CardNumber = _cardNumber,
                        Cvv = _cvv,
                        ExpiryDate = _expiryDate
                    },
                    CobrandSelectionIndicator = _cobrandSelectionIndicator
                }
            }
        };
    }
}
