using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Services;

public class GetIinDetailsRequestBuilder
{
    private string _bin = "401200";

    #region Setters

    public GetIinDetailsRequestBuilder WithBin(string bin)
    {
        _bin = bin;
        return this;
    }

    #endregion

    public GetIINDetailsRequest Build() => new() { Bin = _bin };
}
