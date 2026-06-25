using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Webhooks;

public class ValidateCredentialsRequestBuilder
{
    private string _key;
    private string _secret;

    #region Setters

    public ValidateCredentialsRequestBuilder WithKey(string key)
    {
        _key = key;
        return this;
    }

    public ValidateCredentialsRequestBuilder WithSecret(string secret)
    {
        _secret = secret;
        return this;
    }

    #endregion

    public ValidateCredentialsRequest Build() => new()
    {
        Key = _key,
        Secret = _secret
    };
}
