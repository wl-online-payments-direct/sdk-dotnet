using OnlinePayments.Sdk.Merchant.MerchantBatch;

namespace OnlinePayments.Sdk.It.Builders.MerchantBatch;

public class GetPaymentsReportParamsBuilder
{
    private string _cursor;
    private int? _limit;

    #region Setters

    public GetPaymentsReportParamsBuilder WithCursor(string cursor)
    {
        _cursor = cursor;
        return this;
    }

    public GetPaymentsReportParamsBuilder WithLimit(int? limit)
    {
        _limit = limit;
        return this;
    }

    #endregion

    public GetPaymentsReportParams Build() => new()
    {
        Cursor = _cursor,
        Limit = _limit
    };
}
