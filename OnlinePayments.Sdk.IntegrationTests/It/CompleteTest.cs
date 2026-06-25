using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Complete;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Complete;

namespace OnlinePayments.Sdk.It;

public class CompleteTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";

    private ICompleteClient _completeClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _completeClient = Client.WithNewMerchant(GetMerchantId()).Complete;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region CompletePayment - Valid PayPal payment id

    [TestCase]
    public async Task CompletePayment_ValidPayPalPaymentId_ThrowsPlatformExceptionSinceRedirectPaymentFlow()
    {
        string paymentId = await _sdkTestHelper.CreatePayPalPaymentAndGetId();
        CompletePaymentRequest request = new CompletePaymentRequestBuilder().Build();

        PlatformException exception = Assert.ThrowsAsync<PlatformException>(async () =>
            await _completeClient.CompletePayment(paymentId, request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null);
        Assert.That(exception.Errors[0].HttpStatusCode, Is.Not.Null.And.EqualTo(500));
        Assert.That(exception.Errors[0].Category, Is.Not.Null.And.EqualTo("DIRECT_PLATFORM_ERROR"));
    }

    [TestCase]
    public async Task CompletePayment_ValidPayPalPaymentIdWithCallContext_ThrowsPlatformExceptionSinceRedirectPaymentFlow()
    {
        string paymentId = await _sdkTestHelper.CreatePayPalPaymentAndGetId();
        CompletePaymentRequest request = new CompletePaymentRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-complete-" + Guid.NewGuid());

        PlatformException exception = Assert.ThrowsAsync<PlatformException>(async () =>
            await _completeClient.CompletePayment(paymentId, request, context));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null);
        Assert.That(exception.Errors[0].HttpStatusCode, Is.Not.Null.And.EqualTo(500));
        Assert.That(exception.Errors[0].Category, Is.Not.Null.And.EqualTo("DIRECT_PLATFORM_ERROR"));
    }

    #endregion

    #region CompletePayment - Non-existing payment id

    [TestCase]
    public Task CompletePayment_NonExistingPaymentId_ThrowsReferenceException()
    {
        CompletePaymentRequest request = new CompletePaymentRequestBuilder().Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _completeClient.CompletePayment(NonExistingPaymentId, request));

        return Task.CompletedTask;
    }

    #endregion

    #region CompletePayment - Invalid input

    [TestCase]
    public async Task CompletePayment_InvalidInput_ThrowsValidationException()
    {
        string paymentId = await _sdkTestHelper.CreatePayPalPaymentAndGetId();

        CompletePaymentRequest request = new CompletePaymentRequestBuilder()
            .WithOrder(null)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _completeClient.CompletePayment(paymentId, request));
    }

    #endregion
}
