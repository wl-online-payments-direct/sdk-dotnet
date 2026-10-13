using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.It.Builders.Payments;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payments;

namespace OnlinePayments.Sdk.It;

public class PaymentsTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";
    private const string CurrencyCode = "EUR";

    private IPaymentsClient _paymentsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreatePayment_ValidInput_ReturnsCreatedPayment()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder().Build();

        CreatePaymentResponse response = await _paymentsClient.CreatePayment(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreatePayment_ValidInputWithCallContext_ReturnsIdempotentPayment()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-payments-" + Guid.NewGuid());

        CreatePaymentResponse response = await _paymentsClient.CreatePayment(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task CreatePayment_InvalidCardNumber_ThrowsValidationException()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("123")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CreatePayment(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePayment_UnsupportedCardNumber_ThrowsDeclinedPaymentException()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("4321456998744563")
            .Build();

        Assert.ThrowsAsync<DeclinedPaymentException>(async () =>
            await _paymentsClient.CreatePayment(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task CreatePayment_WithAutoCapture_ReturnsCreatedPayment()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithAutoCapture(true)
            .Build();

        CreatePaymentResponse response = await _paymentsClient.CreatePayment(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetPayment_ExistingPaymentId_ReturnsPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        PaymentResponse response = await _paymentsClient.GetPayment(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Id, Is.EqualTo(paymentId));
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetPaymentDetails_ExistingPaymentId_ReturnsDetails()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        PaymentDetailsResponse response = await _paymentsClient.GetPaymentDetails(paymentId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PaymentOutput, Is.Not.Null);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task GetPayment_NonExistingPaymentId_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.GetPayment(NonExistingPaymentId));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetPaymentDetails_NonExistingPaymentId_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.GetPaymentDetails(NonExistingPaymentId));

        return Task.CompletedTask;
    }

    #endregion

    #region Cancel

    [TestCase]
    public async Task CancelPayment_ValidRequest_ReturnsCancelledPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        CancelPaymentRequest cancelRequest = new CancelPaymentRequestBuilder().Build();

        CancelPaymentResponse response = await _paymentsClient.CancelPayment(paymentId, cancelRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CancelPayment_PartialAmount_ReturnsCancelledPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);
        CancelPaymentRequest cancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        CancelPaymentResponse response = await _paymentsClient.CancelPayment(paymentId, cancelRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CancelPayment_TwoPartialAmounts_ReturnsCancelledPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CancelPaymentRequest firstCancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        CancelPaymentResponse firstResponse = await _paymentsClient.CancelPayment(paymentId, firstCancelRequest);

        Assert.That(firstResponse, Is.Not.Null);
        Assert.That(firstResponse.Payment, Is.Not.Null);
        Assert.That(firstResponse.Payment.Id, Is.Not.Null.And.Not.Empty);

        CancelPaymentRequest secondCancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(500)
            .WithIsFinal(true)
            .Build();

        CancelPaymentResponse secondResponse = await _paymentsClient.CancelPayment(paymentId, secondCancelRequest);

        Assert.That(secondResponse, Is.Not.Null);
        Assert.That(secondResponse.Payment, Is.Not.Null);
        Assert.That(secondResponse.Payment.Id, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CancelPayment_SecondPartialAmountExceedsRemaining_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CancelPaymentRequest firstCancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        await _paymentsClient.CancelPayment(paymentId, firstCancelRequest);

        CancelPaymentRequest secondCancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(600)
            .WithIsFinal(false)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CancelPayment(paymentId, secondCancelRequest));
    }

    [TestCase]
    public Task CancelPayment_NonExistingPaymentId_ThrowsReferenceException()
    {
        CancelPaymentRequest request = new CancelPaymentRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.CancelPayment(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task CancelPayment_AfterCapture_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build()));
    }

    [TestCase]
    public async Task CancelPayment_PartialAmountAfterPartialCapture_ExceedsRemaining_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(600)
            .WithIsFinal(false)
            .Build();

        await _paymentsClient.CapturePayment(paymentId, captureRequest);

        CancelPaymentRequest cancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(400)
            .WithIsFinal(false)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CancelPayment(paymentId, cancelRequest));
    }

    [TestCase]
    public async Task CancelPayment_AfterRefund_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        RefundRequest refundRequest = new RefundRequestBuilder().Build();
        await _paymentsClient.RefundPayment(paymentId, refundRequest);

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build()));
    }

    [TestCase]
    public async Task CancelPayment_AfterPreviousCancel_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build()));
    }

    #endregion

    #region Capture

    [TestCase]
    public async Task CapturePayment_ValidRequest_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder().Build();

        CaptureResponse response = await _paymentsClient.CapturePayment(paymentId, captureRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CapturePayment_PartialAmount_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        CaptureResponse response = await _paymentsClient.CapturePayment(paymentId, captureRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CapturePayment_TwoPartialAmounts_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest firstCaptureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        CaptureResponse firstResponse = await _paymentsClient.CapturePayment(paymentId, firstCaptureRequest);

        Assert.That(firstResponse, Is.Not.Null);
        Assert.That(firstResponse.Id, Is.Not.Null.And.Not.Empty);

        CapturePaymentRequest secondCaptureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(500)
            .WithIsFinal(true)
            .Build();

        CaptureResponse secondResponse = await _paymentsClient.CapturePayment(paymentId, secondCaptureRequest);

        Assert.That(secondResponse, Is.Not.Null);
        Assert.That(secondResponse.Id, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CapturePayment_SecondPartialAmountExceedsRemaining_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest firstCaptureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        await _paymentsClient.CapturePayment(paymentId, firstCaptureRequest);

        CapturePaymentRequest secondCaptureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(600)
            .WithIsFinal(false)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CapturePayment(paymentId, secondCaptureRequest));
    }

    [TestCase]
    public async Task CapturePayment_AfterPartialCancel_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CancelPaymentRequest cancelRequest = new CancelPaymentRequestBuilder()
            .WithAmount(600)
            .WithIsFinal(false)
            .Build();

        await _paymentsClient.CancelPayment(paymentId, cancelRequest);

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(200)
            .WithIsFinal(true)
            .Build();

        CaptureResponse response = await _paymentsClient.CapturePayment(paymentId, captureRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task CapturePayment_NonExistingPaymentId_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.CapturePayment(NonExistingPaymentId, new CapturePaymentRequestBuilder().Build()));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task CapturePayment_AfterPreviousCapture_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build()));
    }

    [TestCase]
    public async Task CapturePayment_AfterCancel_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build()));
    }

    [TestCase]
    public async Task CapturePayment_AfterRefund_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        RefundRequest refundRequest = new RefundRequestBuilder().Build();
        await _paymentsClient.RefundPayment(paymentId, refundRequest);

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build()));
    }

    #endregion

    #region Refund

    [TestCase]
    public async Task RefundPayment_ValidRequest_ReturnsRefundedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        RefundRequest refundRequest = new RefundRequestBuilder().Build();

        RefundResponse response = await _paymentsClient.RefundPayment(paymentId, refundRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task RefundPayment_TwoPartialAmounts_ReturnsRefundedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(1500, CurrencyCode);

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        RefundRequest firstRefundRequest = new RefundRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(false)
            .Build();

        await _paymentsClient.RefundPayment(paymentId, firstRefundRequest);

        RefundRequest secondRefundRequest = new RefundRequestBuilder()
            .WithAmount(400)
            .WithIsFinal(false)
            .Build();

        RefundResponse response = await _paymentsClient.RefundPayment(paymentId, secondRefundRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.EqualTo("REJECTED"));
    }

    [TestCase]
    public async Task RefundPayment_TotalRefundedExceedsCaptured_ReturnsRejectedStatus()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(500)
            .WithIsFinal(true)
            .Build();

        await _paymentsClient.CapturePayment(paymentId, captureRequest);

        RefundRequest firstRefundRequest = new RefundRequestBuilder()
            .WithAmount(400)
            .Build();

        await _paymentsClient.RefundPayment(paymentId, firstRefundRequest);

        RefundRequest secondRefundRequest = new RefundRequestBuilder()
            .WithAmount(200)
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.RefundPayment(paymentId, secondRefundRequest));
        Assert.That(exception?.Errors[0].Message, Is.EqualTo("ACTION_NOT_ALLOWED_ON_TRANSACTION"));
    }

    [TestCase]
    public async Task RefundPayment_SingleRefundExceedsCaptured_ReturnsRejectedStatus()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(800, CurrencyCode);

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(300)
            .WithIsFinal(true)
            .Build();

        await _paymentsClient.CapturePayment(paymentId, captureRequest);

        RefundRequest refundRequest = new RefundRequestBuilder()
            .WithAmount(600)
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.RefundPayment(paymentId, refundRequest));
        Assert.That(exception?.Errors[0].Message, Is.EqualTo("ACTION_NOT_ALLOWED_ON_TRANSACTION"));
    }

    [TestCase]
    public Task RefundPayment_NonExistingPaymentId_ThrowsReferenceException()
    {
        RefundRequest request = new RefundRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.RefundPayment(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task RefundPayment_WithoutCapture_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        RefundRequest refundRequest = new RefundRequestBuilder().Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.RefundPayment(paymentId, refundRequest));
    }

    [TestCase]
    public async Task RefundPayment_AfterCancel_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build());

        RefundRequest refundRequest = new RefundRequestBuilder().Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.RefundPayment(paymentId, refundRequest));
    }

    [TestCase]
    public async Task RefundPayment_AfterPreviousFullRefund_ReturnsRejectedStatus()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        RefundRequest request = new RefundRequestBuilder().Build();

        RefundResponse firstResponse = await _paymentsClient.RefundPayment(paymentId, request);

        Assert.That(firstResponse, Is.Not.Null);
        Assert.That(firstResponse.Status, Is.EqualTo("REFUND_REQUESTED"));

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.RefundPayment(paymentId, request));
        Assert.That(exception?.Errors[0].Message, Is.EqualTo("ACTION_NOT_ALLOWED_ON_TRANSACTION"));
    }

    #endregion
}
