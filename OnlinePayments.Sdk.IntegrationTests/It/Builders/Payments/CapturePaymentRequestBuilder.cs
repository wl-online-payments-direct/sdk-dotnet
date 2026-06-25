using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Payments;

public class CapturePaymentRequestBuilder
{
    private long? _amount;
    private bool? _isFinal;

    #region Setters

    public CapturePaymentRequestBuilder WithAmount(long amount)
    {
        _amount = amount;
        return this;
    }

    public CapturePaymentRequestBuilder WithIsFinal(bool isFinal)
    {
        _isFinal = isFinal;
        return this;
    }

    #endregion

    public CapturePaymentRequest Build() => new()
    {
        Amount = _amount,
        IsFinal = _isFinal
    };
}
