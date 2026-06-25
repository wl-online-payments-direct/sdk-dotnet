using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Payments;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.Refunds;

namespace OnlinePayments.Sdk.It;

public class RefundsTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";

    private IPaymentsClient _paymentsClient;
    private IRefundsClient _refundsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;
        _refundsClient = Client.WithNewMerchant(GetMerchantId()).Refunds;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Get

    [TestCase]
    public async Task GetRefunds_WithExistingPaymentId_ReturnsRefunds()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());
        await _paymentsClient.RefundPayment(paymentId, new RefundRequestBuilder().Build());

        RefundsResponse response = await _refundsClient.GetRefunds(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Refunds, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0], Is.Not.Null);
        Assert.That(response.Refunds[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0].Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetRefunds_WithExistingPaymentIdAndCallContext_ReturnsRefunds()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());
        await _paymentsClient.RefundPayment(paymentId, new RefundRequestBuilder().Build());

        CallContext context = new CallContext().WithIdempotenceKey("test-refunds-" + Guid.NewGuid());
        RefundsResponse response = await _refundsClient.GetRefunds(paymentId, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Refunds, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0], Is.Not.Null);
        Assert.That(response.Refunds[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0].Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetRefunds_WithExistingPaymentId_ReturnsRefundDetails()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());
        await _paymentsClient.RefundPayment(paymentId, new RefundRequestBuilder().Build());

        RefundsResponse response = await _refundsClient.GetRefunds(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Refunds, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0].Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0].Status, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Refunds[0].RefundOutput, Is.Not.Null);
        Assert.That(response.Refunds[0].StatusOutput, Is.Not.Null);
    }

    [TestCase]
    public async Task GetRefunds_WithExistingPaymentId_ReturnsAllRefundsWithDetails()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());
        await _paymentsClient.RefundPayment(paymentId, new RefundRequestBuilder().Build());

        RefundsResponse response = await _refundsClient.GetRefunds(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Refunds, Is.Not.Null.And.Not.Empty);

        foreach (RefundResponse refund in response.Refunds)
        {
            Assert.That(refund.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(refund.Status, Is.Not.Null.And.Not.Empty);
        }
    }

    [TestCase]
    public Task GetRefunds_WithNonExistingPaymentId_ThrowsReferenceException()
    {
        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _refundsClient.GetRefunds(NonExistingPaymentId));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        return Task.CompletedTask;
    }

    #endregion
}
