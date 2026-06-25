using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Subsequent;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Subsequent;

namespace OnlinePayments.Sdk.It;

public class SubsequentTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999";

    private ISubsequentClient _subsequentClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _subsequentClient = Client.WithNewMerchant(GetMerchantId()).Subsequent;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task SubsequentPayment_ValidInput_ReturnsPaymentId()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        SubsequentPaymentRequest request = new SubsequentPaymentRequestBuilder().Build();

        SubsequentPaymentResponse response = await _subsequentClient.SubsequentPayment(paymentId, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task SubsequentPayment_WithCallContext_ReturnsPaymentId()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        SubsequentPaymentRequest request = new SubsequentPaymentRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-subsequent-" + Guid.NewGuid());

        SubsequentPaymentResponse response = await _subsequentClient.SubsequentPayment(paymentId, request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task SubsequentPayment_InvalidAmount_ReturnsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        SubsequentPaymentRequest request = new SubsequentPaymentRequestBuilder()
            .WithAmount(-1000)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _subsequentClient.SubsequentPayment(paymentId, request));
    }

    [TestCase]
    public Task SubsequentPayment_NonExistentPaymentId_ReturnsReferenceException()
    {
        SubsequentPaymentRequest request = new SubsequentPaymentRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _subsequentClient.SubsequentPayment(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    #endregion
}
