using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.CofSeries;

public class ImportCofSeriesRequestBuilder
{
    private string _cardNumber = "4567350000427977";
    private string _cardholderName = "John Doe";
    private string _expiryDate = "1230";
    private string _currencyCode = "EUR";
    private int _paymentProductId = 1;
    private string _schemeReferenceData = "test_scheme_reference";
    private string _tokenId;
    private string _transactionLinkIdentifier;

    #region Setters

    public ImportCofSeriesRequestBuilder WithCardNumber(string cardNumber)
    {
        _cardNumber = cardNumber;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithCardholderName(string cardholderName)
    {
        _cardholderName = cardholderName;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithExpiryDate(string expiryDate)
    {
        _expiryDate = expiryDate;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithCurrencyCode(string currencyCode)
    {
        _currencyCode = currencyCode;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithPaymentProductId(int paymentProductId)
    {
        _paymentProductId = paymentProductId;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithSchemeReferenceData(string schemeReferenceData)
    {
        _schemeReferenceData = schemeReferenceData;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithTokenId(string tokenId)
    {
        _tokenId = tokenId;
        return this;
    }

    public ImportCofSeriesRequestBuilder WithTransactionLinkIdentifier(string transactionLinkIdentifier)
    {
        _transactionLinkIdentifier = transactionLinkIdentifier;
        return this;
    }

    #endregion

    public ImportCofSeriesRequest Build()
    {
        ImportCofSeriesRequest request = new ImportCofSeriesRequest
        {
            CurrencyCode = _currencyCode,
            PaymentProductId = _paymentProductId,
            SchemeReferenceData = _schemeReferenceData,
            TransactionLinkIdentifier = _transactionLinkIdentifier
        };

        if (!string.IsNullOrEmpty(_tokenId))
        {
            request.TokenId = _tokenId;
        }
        else
        {
            request.Card = new CardDataWithoutCvv
            {
                CardNumber = _cardNumber,
                CardholderName = _cardholderName,
                ExpiryDate = _expiryDate
            };
        }

        return request;
    }
}
