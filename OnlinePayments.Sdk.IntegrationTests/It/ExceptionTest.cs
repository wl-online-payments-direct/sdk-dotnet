using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.It.Builders.Payments;
using OnlinePayments.Sdk.It.Builders.Payouts;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.Payouts;

namespace OnlinePayments.Sdk.It;

public class ExceptionTest : IntegrationTest
{
    private const string NonExistingPaymentId = "9999999999_0";
    private const string InvalidMerchantId = "000000";
    private const string CurrencyCode = "EUR";
    private const int OvershootPaymentAmount = 999999999;
    private const long DeclinedRefundAmount = 1500L;

    private IPaymentsClient _paymentsClient;
    private IPayoutsClient _payoutsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;
        _payoutsClient = Client.WithNewMerchant(GetMerchantId()).Payouts;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Exception errors

    [TestCase]
    public Task CreatePayment_InvalidCardNumber_ThrowsValidationExceptionWithErrorIdAndAPIError()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("123")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);

        APIError error = exception.Errors[0];
        Assert.That(error.Id, Is.Not.Null);
        Assert.That(error.HttpStatusCode, Is.Not.Null);

        return Task.CompletedTask;
    }

    #endregion

    #region ValidationException

    [TestCase]
    public Task CreatePayout_InvalidCurrency_ThrowsValidationException()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder()
            .WithAmount(1000L)
            .WithCurrencyCode("INVALID")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _payoutsClient.CreatePayout(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.EqualTo(400));
        Assert.That(exception.ErrorId, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);

        APIError error = exception.Errors[0];
        Assert.That(error.Id, Is.EqualTo("INVALID_VALUE"));
        Assert.That(error.HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePayment_MultipleInvalidFields_ThrowsValidationExceptionWithMultipleErrors()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("123")
            .WithCvv("")
            .WithExpiryDate("invalid")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.EqualTo(400));
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);

        foreach (APIError error in exception.Errors)
        {
            Assert.That(error.Id, Is.Not.Null);
            Assert.That(error.HttpStatusCode, Is.EqualTo(400));
        }

        return Task.CompletedTask;
    }

    #endregion

    #region AuthorizationException

    [TestCase]
    public Task CreatePayment_InvalidMerchantId_ThrowsAuthorizationException()
    {
        IClient invalidClient = null;
        CreatePaymentRequest request = new CreatePaymentRequestBuilder().Build();

        try
        {
            CommunicatorConfiguration configuration = GetCommunicatorConfiguration();
            invalidClient = Factory.CreateClient(configuration);

            AuthorizationException exception = Assert.ThrowsAsync<AuthorizationException>(async () =>
                await invalidClient.WithNewMerchant(InvalidMerchantId).Payments.CreatePayment(request));

            Assert.That(exception, Is.Not.Null);
            Assert.That((int)exception.StatusCode, Is.EqualTo(403));
            Assert.That(exception.ResponseBody, Is.Not.Null);
            Assert.That(exception.ErrorId, Is.Not.Null);
            Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);

            APIError error = exception.Errors[0];
            Assert.That(error.Id, Is.Not.Null);
            Assert.That(error.HttpStatusCode, Is.EqualTo(403));

            return Task.CompletedTask;
        }
        finally
        {
            invalidClient?.Dispose();
        }
    }

    #endregion

    #region DeclinedPaymentException

    [TestCase]
    public Task CreatePayment_DeclinedCard_ThrowsDeclinedPaymentException()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("4321456998744563")
            .Build();

        DeclinedPaymentException exception = Assert.ThrowsAsync<DeclinedPaymentException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.GreaterThanOrEqualTo(400));
        Assert.That(exception.ResponseBody, Is.Not.Null);

        CreatePaymentResponse paymentResponse = exception.CreatePaymentResponse;
        Assert.That(paymentResponse, Is.Not.Null);
        Assert.That(paymentResponse.Payment, Is.Not.Null);
        Assert.That(paymentResponse.Payment.Id, Is.Not.Null);
        Assert.That(paymentResponse.Payment.Status, Is.EqualTo("REJECTED"));

        return Task.CompletedTask;
    }

    #endregion

    #region DeclinedPayoutException

    [TestCase]
    public Task CreatePayout_DeclinedCard_ThrowsDeclinedPayoutException()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder()
            .WithCardNumber("4321456998744563")
            .Build();

        DeclinedPayoutException exception = Assert.ThrowsAsync<DeclinedPayoutException>(async () =>
            await _payoutsClient.CreatePayout(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.GreaterThanOrEqualTo(400));
        Assert.That(exception.ResponseBody, Is.Not.Null);

        PayoutResult payoutResult = exception.PayoutResult;
        Assert.That(payoutResult, Is.Not.Null);
        Assert.That(payoutResult.Id, Is.Not.Null);
        Assert.That(payoutResult.Status, Is.EqualTo("REJECTED_CREDIT"));

        return Task.CompletedTask;
    }

    #endregion

    #region ApiException

    [TestCase]
    public Task CreatePayment_InvalidCardNumber_ThrowsApiException()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("123")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.GreaterThanOrEqualTo(400));
        Assert.That(exception.ResponseBody, Is.Not.Null);
        Assert.That(exception.ErrorId, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null);

        return Task.CompletedTask;
    }

    #endregion

    #region DeclinedTransactionException

    [TestCase]
    public Task CreatePayment_DeclinedCard_ThrowsDeclinedTransactionException()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("4321456998744563")
            .Build();

        DeclinedPaymentException exception = Assert.ThrowsAsync<DeclinedPaymentException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception, Is.InstanceOf<DeclinedPaymentException>());
        Assert.That(exception.ResponseBody, Is.Not.Null);

        return Task.CompletedTask;
    }

    #endregion

    #region IdempotenceException

    [TestCase]
    public async Task CreatePayment_ConcurrentRequestsWithSameIdempotenceKey_ThrowsReferenceException()
    {
        string idempotenceKey = Guid.NewGuid().ToString();

        CreatePaymentRequest request = new CreatePaymentRequestBuilder().Build();

        CallContext firstContext = new CallContext().WithIdempotenceKey(idempotenceKey);
        CallContext secondContext = new CallContext().WithIdempotenceKey(idempotenceKey);

        var firstTask = Task.Run(() =>
            _paymentsClient.CreatePayment(request, firstContext));

        var secondTask = Task.Run(() =>
            _paymentsClient.CreatePayment(request, secondContext));

        await Task.WhenAll(
            firstTask.ContinueWith(_ => { }),
            secondTask.ContinueWith(_ => { }));

        var exceptions = new[]
        {
            firstTask.Exception?.InnerException,
            secondTask.Exception?.InnerException
        };

        var failed = exceptions.FirstOrDefault(e => e != null);
        var succeeded = exceptions.Count(e => e == null);

        Assert.That(succeeded, Is.EqualTo(1));
        Assert.That(failed, Is.Not.Null);

        Assert.That(failed, Is.InstanceOf<ReferenceException>());

        var error = ((ReferenceException)failed).Errors[0];

        Assert.That(error.HttpStatusCode, Is.EqualTo(409));
        Assert.That(error.Id, Is.EqualTo("DUPLICATE_REQUEST_IN_PROGRESS"));
    }


    #endregion

    #region DeclinedRefundException

    [TestCase]
    [Ignore("Test is skipped because the action could not be triggered in the current merchant setup.")]
    public async Task RefundPayment_Declined_ThrowsDeclinedRefundException()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId(DeclinedRefundAmount, CurrencyCode);
        await _paymentsClient.CapturePayment(paymentId, new CapturePaymentRequestBuilder().Build());

        DeclinedRefundException exception = Assert.ThrowsAsync<DeclinedRefundException>(async () =>
        {
            await _paymentsClient.RefundPayment(paymentId, new RefundRequestBuilder()
                .WithAmount(DeclinedRefundAmount)
                .WithCurrencyCode(CurrencyCode)
                .Build());
        });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.StatusCode, Is.GreaterThanOrEqualTo(400));
        Assert.That(exception.ResponseBody, Is.Not.Null);

        RefundResponse refundResponse = exception.RefundResponse;
        Assert.That(refundResponse, Is.Not.Null);
        Assert.That(refundResponse.Id, Is.Not.Null);
        Assert.That(refundResponse.Status, Is.Not.Null);
    }

    #endregion

    #region ErrorId in all exception types

    [TestCase]
    public Task CreatePayment_InvalidCardNumber_ValidationExceptionHasErrorId()
    {
        CreatePaymentRequest request = new CreatePaymentRequestBuilder()
            .WithCardNumber("123")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentsClient.CreatePayment(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetPayment_NonExistingId_ReferenceExceptionHasErrorId()
    {
        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentsClient.GetPayment(NonExistingPaymentId));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePayment_InvalidMerchantId_AuthorizationExceptionHasErrorId()
    {
        IClient invalidClient = null;
        CreatePaymentRequest request = new CreatePaymentRequestBuilder().Build();

        try
        {
            CommunicatorConfiguration configuration = GetCommunicatorConfiguration();
            invalidClient = Factory.CreateClient(configuration);

            AuthorizationException exception = Assert.ThrowsAsync<AuthorizationException>(async () =>
                await invalidClient.WithNewMerchant(InvalidMerchantId).Payments.CreatePayment(request));

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

            return Task.CompletedTask;
        }
        finally
        {
            invalidClient?.Dispose();
        }
    }

    #endregion
}
