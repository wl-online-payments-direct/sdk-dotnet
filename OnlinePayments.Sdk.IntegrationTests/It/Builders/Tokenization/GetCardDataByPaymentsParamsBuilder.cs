using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.Tokenization;

namespace OnlinePayments.Sdk.It.Builders.Tokenization;

public class GetCardDataByPaymentsParamsBuilder
{
    private IList<string> _payments = [];

    #region Setters

    public GetCardDataByPaymentsParamsBuilder WithPayments(IList<string> payments)
    {
        _payments = payments;
        return this;
    }

    #endregion

    public GetCardDataByPaymentsParams Build() => new()
    {
        Payments = _payments
    };
}
