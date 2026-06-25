using System;
using System.Collections.Generic;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.MerchantBatch;

public class SubmitBatchRequestBodyBuilder
{
    private string _merchantBatchReference = $"Ref-{Guid.NewGuid().ToString()}";
    private string _operationType;
    private List<CreatePaymentRequest> _createPaymentRequests;
    private int _itemCount;

    #region Setters

    public SubmitBatchRequestBodyBuilder WithMerchantBatchReference(string merchantBatchReference)
    {
        _merchantBatchReference = merchantBatchReference;

        return this;
    }

    public SubmitBatchRequestBodyBuilder WithOperationType(string operationType)
    {
        _operationType = operationType;
        return this;
    }

    public SubmitBatchRequestBodyBuilder WithItemCount(int itemCount)
    {
        _itemCount = itemCount;
        return this;
    }

    public SubmitBatchRequestBodyBuilder WithCreatePaymentRequests(List<CreatePaymentRequest> createPaymentRequests)
    {
        _createPaymentRequests = createPaymentRequests;
        return this;
    }

    #endregion

    public SubmitBatchRequestBody Build() => new()
    {
        Header = new BatchMetadata
        {
            MerchantBatchReference = _merchantBatchReference,
            ItemCount = _itemCount,
            OperationType = _operationType
        },
        CreatePayments = _createPaymentRequests
    };
}
