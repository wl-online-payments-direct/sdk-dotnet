using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Payments;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Captures;
using OnlinePayments.Sdk.Merchant.Payments;

namespace OnlinePayments.Sdk.It;

public class CapturesTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";

    private IPaymentsClient _paymentsClient;
    private ICapturesClient _capturesClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;
        _capturesClient = Client.WithNewMerchant(GetMerchantId()).Captures;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Get

    [TestCase]
    public async Task GetCaptures_WithExistingPaymentId_ReturnsCaptures()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        CapturesResponse response = await _capturesClient.GetCaptures(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Captures, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0], Is.Not.Null);
        Assert.That(response.Captures[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0].Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetCaptures_WithExistingPaymentIdAndCallContext_ReturnsCaptures()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        CallContext context = new CallContext().WithIdempotenceKey("test-captures-" + Guid.NewGuid());

        CapturesResponse response = await _capturesClient.GetCaptures(paymentId, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Captures, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0], Is.Not.Null);
        Assert.That(response.Captures[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0].Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetCaptures_WithExistingPaymentId_ReturnsCaptureDetails()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        CapturesResponse response = await _capturesClient.GetCaptures(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Captures, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0].Status, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Captures[0].CaptureOutput, Is.Not.Null);
        Assert.That(response.Captures[0].StatusOutput, Is.Not.Null);
    }

    [TestCase]
    public async Task GetCaptures_WithExistingPaymentId_ReturnsMultipleCaptures()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        CapturesResponse response = await _capturesClient.GetCaptures(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Captures, Is.Not.Null.And.Not.Empty);

        foreach (var capture in response.Captures)
        {
            Assert.That(capture.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(capture.Status, Is.Not.Null.And.Not.Empty);
        }
    }

    [TestCase]
    public Task GetCaptures_WithNonExistingPaymentId_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _capturesClient.GetCaptures(NonExistingPaymentId));

        return Task.CompletedTask;
    }

    #endregion
}
