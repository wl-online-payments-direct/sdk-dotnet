using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.It.Builders.MerchantBatch;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.MerchantBatch;

namespace OnlinePayments.Sdk.It;

public class MerchantBatchTest : IntegrationTest
{
    private const string NonExistingMerchantBatchReference = "non-existing-batch-reference";
    private const string InvalidMerchantBatchReference = "";

    private IMerchantBatchClient _merchantBatchClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _merchantBatchClient = Client.WithNewMerchant(GetMerchantId()).MerchantBatch;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Submit

    [TestCase]
    public async Task SubmitBatch_WithValidInput_ReturnsBatchReferenceAndTotalCount()
    {
        CreatePaymentRequest createPaymentRequest = new CreatePaymentRequestBuilder().Build();

        SubmitBatchRequestBody request = new SubmitBatchRequestBodyBuilder()
            .WithCreatePaymentRequests([createPaymentRequest])
            .WithOperationType("CreatePayment")
            .WithItemCount(1)
            .Build();

        string merchantBatchReference = request.Header.MerchantBatchReference;

        SubmitBatchResponse response = await _merchantBatchClient.SubmitBatch(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.MerchantBatchReference, Is.EqualTo(merchantBatchReference));
        Assert.That(response.TotalCount, Is.EqualTo(1));
    }

    [TestCase]
    public async Task SubmitBatch_WithValidInputAndCallContext_ReturnsBatchReferenceAndTotalCount()
    {
        CreatePaymentRequest createPaymentRequest = new CreatePaymentRequestBuilder().Build();

        SubmitBatchRequestBody request = new SubmitBatchRequestBodyBuilder()
            .WithCreatePaymentRequests([createPaymentRequest])
            .WithOperationType("CreatePayment")
            .WithItemCount(1)
            .Build();

        string merchantBatchReference = request.Header.MerchantBatchReference;
        CallContext context = new CallContext().WithIdempotenceKey("test-merchant-batch-" + Guid.NewGuid());

        SubmitBatchResponse response = await _merchantBatchClient.SubmitBatch(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.MerchantBatchReference, Is.EqualTo(merchantBatchReference));
        Assert.That(response.TotalCount, Is.EqualTo(1));
    }

    [TestCase]
    public Task SubmitBatch_WithInvalidMerchantBatchReference_ThrowsValidationException()
    {
        CreatePaymentRequest createPaymentRequest = new CreatePaymentRequestBuilder().Build();

        SubmitBatchRequestBody request = new SubmitBatchRequestBodyBuilder()
            .WithMerchantBatchReference(InvalidMerchantBatchReference)
            .WithCreatePaymentRequests([createPaymentRequest])
            .WithOperationType("CreatePayment")
            .WithItemCount(1)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _merchantBatchClient.SubmitBatch(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Process

    [TestCase]
    public async Task ProcessBatch_WithExistingMerchantBatchReference_BatchIsProcessed()
    {
        CreatePaymentRequest createPaymentRequest = new CreatePaymentRequestBuilder().Build();

        string reference = await _sdkTestHelper.SubmitBatchAndGetReference(
            [createPaymentRequest],
            "CreatePayment",
            1);

        await _merchantBatchClient.ProcessBatch(reference);

        GetBatchStatusResponse statusResponse = await _merchantBatchClient.GetBatchStatus(reference);
        Assert.That(statusResponse, Is.Not.Null);
        Assert.That(statusResponse.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task ProcessBatch_WithNonExistingMerchantBatchReference_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _merchantBatchClient.ProcessBatch(NonExistingMerchantBatchReference));

        return Task.CompletedTask;
    }

    #endregion

    #region GetStatus

    [TestCase]
    public async Task GetBatchStatus_WithExistingMerchantBatchReference_ReturnsBatchStatus()
    {
        CreatePaymentRequest createPaymentRequest = new CreatePaymentRequestBuilder().Build();

        string reference = await _sdkTestHelper.SubmitBatchAndGetReference(
            [createPaymentRequest],
            "CreatePayment",
            1);

        GetBatchStatusResponse response = await _merchantBatchClient.GetBatchStatus(reference);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.MerchantBatchReference, Is.EqualTo(reference));
        Assert.That(response.ItemCount, Is.EqualTo(1));
        Assert.That(response.OperationType, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task GetBatchStatus_WithNonExistingMerchantBatchReference_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _merchantBatchClient.GetBatchStatus(NonExistingMerchantBatchReference));

        return Task.CompletedTask;
    }

    #endregion
}
