using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Payments;
using OnlinePayments.Sdk.It.Builders.PreAuthorization;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.PreAuthorization;

namespace OnlinePayments.Sdk.It;

public class PreAuthorizationTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";
    private const string CurrencyCode = "EUR";
    private const long PaymentAmount = 1000;
    private const long IncrementedAmount = 1500;

    private IPaymentsClient _paymentsClient;
    private IPreAuthorizationClient _preAuthorizationClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;
        _preAuthorizationClient = Client.WithNewMerchant(GetMerchantId()).PreAuthorization;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region IncrementAuthorization

    [TestCase]
    public async Task IncrementAuthorization_WithPreAuthorizedPayment_ReturnsIncrementedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder()
            .WithAmount(IncrementedAmount)
            .Build();

        IncrementAuthorizationResponse response =
            await _preAuthorizationClient.IncrementAuthorization(paymentId, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.EqualTo("PENDING_CAPTURE"));

        PaymentResponse payment = await _paymentsClient.GetPayment(paymentId);

        Assert.That(payment, Is.Not.Null);
        Assert.That(payment.Status, Is.EqualTo("PENDING_CAPTURE"));
        Assert.That(payment.PaymentOutput, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney.Amount, Is.EqualTo(IncrementedAmount));
    }

    [TestCase]
    public async Task IncrementAuthorization_WithPreAuthorizedPaymentAndCallContext_ReturnsIncrementedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder()
            .WithAmount(IncrementedAmount)
            .Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-increment-authorization-" + Guid.NewGuid());

        IncrementAuthorizationResponse response =
            await _preAuthorizationClient.IncrementAuthorization(paymentId, request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.EqualTo("PENDING_CAPTURE"));

        PaymentResponse payment = await _paymentsClient.GetPayment(paymentId);

        Assert.That(payment, Is.Not.Null);
        Assert.That(payment.Status, Is.EqualTo("PENDING_CAPTURE"));
        Assert.That(payment.PaymentOutput, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney.Amount, Is.EqualTo(IncrementedAmount));
    }

    [TestCase]
    public async Task IncrementAuthorization_TwoIncrements_ReturnsCumulativeAmount()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);

        IncrementAuthorizationResponse firstResponse = await _preAuthorizationClient.IncrementAuthorization(
            paymentId,
            new IncrementAuthorizationRequestBuilder().WithAmount(1300).Build());

        Assert.That(firstResponse, Is.Not.Null);
        Assert.That(firstResponse.Payment, Is.Not.Null);

        IncrementAuthorizationResponse secondResponse = await _preAuthorizationClient.IncrementAuthorization(
            paymentId,
            new IncrementAuthorizationRequestBuilder().WithAmount(IncrementedAmount).Build());

        Assert.That(secondResponse, Is.Not.Null);
        Assert.That(secondResponse.Payment, Is.Not.Null);

        PaymentResponse payment = await _paymentsClient.GetPayment(paymentId);

        Assert.That(payment, Is.Not.Null);
        Assert.That(payment.Status, Is.EqualTo("PENDING_CAPTURE"));
        Assert.That(payment.PaymentOutput, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney, Is.Not.Null);
        Assert.That(payment.PaymentOutput.AmountOfMoney.Amount, Is.EqualTo(IncrementedAmount));
    }

    [TestCase]
    public async Task IncrementAuthorization_ThenCaptureIncrementedAmount_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _preAuthorizationClient.IncrementAuthorization(
            paymentId,
            new IncrementAuthorizationRequestBuilder().WithAmount(IncrementedAmount).Build());

        CapturePaymentRequest captureRequest = new CapturePaymentRequestBuilder()
            .WithAmount(IncrementedAmount)
            .WithIsFinal(true)
            .Build();

        CaptureResponse response = await _paymentsClient.CapturePayment(paymentId, captureRequest);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.EqualTo("CAPTURE_REQUESTED"));
    }

    [TestCase]
    public Task IncrementAuthorization_WithNonExistingPaymentId_ThrowsReferenceException()
    {
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task IncrementAuthorization_WithoutAmountOfMoney_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(paymentId, new IncrementAuthorizationRequest()));
    }

    [TestCase]
    public async Task IncrementAuthorization_WithZeroAmount_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder()
            .WithAmount(0)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(paymentId, request));
    }

    [TestCase]
    public async Task IncrementAuthorization_WithDifferentCurrency_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder()
            .WithCurrencyCode("USD")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(paymentId, request));
    }

    [TestCase]
    public async Task IncrementAuthorization_WithFinalAuthorizationPayment_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreateMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);
        IncrementAuthorizationRequest request = new IncrementAuthorizationRequestBuilder().Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(paymentId, request));
    }

    [TestCase]
    public async Task IncrementAuthorization_AfterCapture_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(
                paymentId,
                new IncrementAuthorizationRequestBuilder().Build()));
    }

    [TestCase]
    public async Task IncrementAuthorization_AfterCancel_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedMastercardPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.IncrementAuthorization(
                paymentId,
                new IncrementAuthorizationRequestBuilder().Build()));
    }

    #endregion

    #region AddAuthorizationDetails

    [TestCase]
    public async Task AddAuthorizationDetails_WithFullCarRentalData_ReturnsPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);
        UpdateAuthorizationAdditionalDataRequest request = new UpdateAuthorizationAdditionalDataRequestBuilder().Build();

        AddAuthorizationDetailsResponse response =
            await _preAuthorizationClient.AddAuthorizationDetails(paymentId, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.EqualTo("PENDING_CAPTURE"));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_WithMinimalCarRentalData_ReturnsPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);
        UpdateAuthorizationAdditionalDataRequest request = new UpdateAuthorizationAdditionalDataRequestBuilder()
            .WithMinimalCarRentalData()
            .Build();

        AddAuthorizationDetailsResponse response =
            await _preAuthorizationClient.AddAuthorizationDetails(paymentId, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.EqualTo("PENDING_CAPTURE"));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_WithCallContext_ReturnsPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);
        UpdateAuthorizationAdditionalDataRequest request = new UpdateAuthorizationAdditionalDataRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-authorization-details-" + Guid.NewGuid());

        AddAuthorizationDetailsResponse response =
            await _preAuthorizationClient.AddAuthorizationDetails(paymentId, request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Payment.Status, Is.EqualTo("PENDING_CAPTURE"));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_ThenCapture_ReturnsCapturedPayment()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _preAuthorizationClient.AddAuthorizationDetails(
            paymentId,
            new UpdateAuthorizationAdditionalDataRequestBuilder().Build());

        CaptureResponse response =
            await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.EqualTo("CAPTURE_REQUESTED"));
    }

    [TestCase]
    public Task AddAuthorizationDetails_WithNonExistingPaymentId_ThrowsReferenceException()
    {
        UpdateAuthorizationAdditionalDataRequest request = new UpdateAuthorizationAdditionalDataRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _preAuthorizationClient.AddAuthorizationDetails(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task AddAuthorizationDetails_WithoutCarRentalData_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.AddAuthorizationDetails(
                paymentId,
                new UpdateAuthorizationAdditionalDataRequest()));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_WithInvalidCarRentalData_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);
        UpdateAuthorizationAdditionalDataRequest request = new UpdateAuthorizationAdditionalDataRequestBuilder()
            .WithChargesCategory("invalid")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.AddAuthorizationDetails(paymentId, request));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_AfterCapture_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.AddAuthorizationDetails(
                paymentId,
                new UpdateAuthorizationAdditionalDataRequestBuilder().Build()));
    }

    [TestCase]
    public async Task AddAuthorizationDetails_AfterCancel_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePreAuthorizedPaymentAndGetId(PaymentAmount, CurrencyCode);

        await _paymentsClient.CancelPayment(paymentId, new CancelPaymentRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _preAuthorizationClient.AddAuthorizationDetails(
                paymentId,
                new UpdateAuthorizationAdditionalDataRequestBuilder().Build()));
    }

    #endregion
}
