using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Webhooks;

public class SendTestRequestBuilder
{
    private string _url;

    #region Setters

    public SendTestRequestBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    #endregion

    public SendTestRequest Build() => new()
    {
        Url = _url
    };
}
