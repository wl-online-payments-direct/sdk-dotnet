using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Products;

public class PaymentProductSessionRequestBuilder
{
    private string _displayName = "Test Merchant";
    private string _domainName = "example.com";

    #region Setters

    public PaymentProductSessionRequestBuilder WithDisplayName(string displayName)
    {
        _displayName = displayName;
        return this;
    }

    public PaymentProductSessionRequestBuilder WithDomainName(string domainName)
    {
        _domainName = domainName;
        return this;
    }

    #endregion

    public PaymentProductSessionRequest Build() => new()
    {
        PaymentProductSession302SpecificInput = new PaymentProductSession302SpecificInput
        {
            DisplayName = _displayName,
            DomainName = _domainName
        }
    };
}
