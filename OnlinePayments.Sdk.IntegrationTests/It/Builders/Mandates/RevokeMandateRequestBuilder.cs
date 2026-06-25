using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Mandates;

public class RevokeMandateRequestBuilder
{
    private string _revocationReason = "userAction";

    #region Setters

    public RevokeMandateRequestBuilder WithRevocationReason(string revocationReason)
    {
        _revocationReason = revocationReason;
        return this;
    }

    #endregion

    public RevokeMandateRequest Build() => new()
    {
        RevocationReason = _revocationReason
    };
}
