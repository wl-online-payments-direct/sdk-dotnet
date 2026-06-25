using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Payouts;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payouts;

namespace OnlinePayments.Sdk.It;

public class PayoutsTest : IntegrationTest
{
    private const string NonExistingPayoutId = "9999999999_0";

    private IPayoutsClient _payoutsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _payoutsClient = Client.WithNewMerchant(GetMerchantId()).Payouts;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreatePayout_ValidInput_ReturnsPayoutId()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder().Build();

        PayoutResponse response = await _payoutsClient.CreatePayout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);

        Assert.That(response.PayoutOutput, Is.Not.Null);
        Assert.That(response.PayoutOutput.AmountOfMoney, Is.Not.Null);
        Assert.That(response.PayoutOutput.AmountOfMoney.Amount, Is.EqualTo(request.AmountOfMoney.Amount));
        Assert.That(response.PayoutOutput.AmountOfMoney.CurrencyCode, Is.EqualTo(request.AmountOfMoney.CurrencyCode));
    }

    [TestCase]
    public async Task CreatePayout_WithCallContext_ReturnsPayoutId()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-payout-" + Guid.NewGuid());

        PayoutResponse response = await _payoutsClient.CreatePayout(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);

        Assert.That(response.PayoutOutput, Is.Not.Null);
        Assert.That(response.PayoutOutput.AmountOfMoney, Is.Not.Null);
        Assert.That(response.PayoutOutput.AmountOfMoney.Amount, Is.EqualTo(request.AmountOfMoney.Amount));
        Assert.That(response.PayoutOutput.AmountOfMoney.CurrencyCode, Is.EqualTo(request.AmountOfMoney.CurrencyCode));
    }

    [TestCase]
    public Task CreatePayout_InvalidAmountInput_ReturnsValidationException()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder()
            .WithAmount(-1000)
            .WithCurrencyCode("EUR")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _payoutsClient.CreatePayout(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

        APIError error = exception.Errors[0];
        Assert.That(error.Id, Is.EqualTo("INVALID_VALUE"));
        Assert.That(error.HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePayout_InvalidCurrencyCodeInput_ReturnsValidationException()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder()
            .WithAmount(1000)
            .WithCurrencyCode("INVALID")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _payoutsClient.CreatePayout(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

        APIError error = exception.Errors[0];
        Assert.That(error.Id, Is.EqualTo("INVALID_VALUE"));
        Assert.That(error.HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePayout_InvalidCardNumberInput_ReturnsValidationException()
    {
        CreatePayoutRequest request = new CreatePayoutRequestBuilder()
            .WithCardNumber("123")
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _payoutsClient.CreatePayout(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.ErrorId, Is.Not.Null.And.Not.Empty);

        APIError error = exception.Errors[0];
        Assert.That(error.Id, Is.EqualTo("INVALID_VALUE"));
        Assert.That(error.HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetPayout_ValidPayoutId_ReturnsPayoutDetails()
    {
        string payoutId = await _sdkTestHelper.CreatePayoutAndGetId();

        PayoutResponse detailsResponse = await _payoutsClient.GetPayout(payoutId);

        Assert.That(detailsResponse, Is.Not.Null);
        Assert.That(detailsResponse.Id, Is.Not.Null.And.Not.Empty.And.EqualTo(payoutId));
        Assert.That(detailsResponse.Status, Is.Not.Null.And.Not.Empty.And.EqualTo("ACCOUNT_CREDITED"));

        Assert.That(detailsResponse.PayoutOutput, Is.Not.Null);
        Assert.That(detailsResponse.StatusOutput, Is.Not.Null);
        Assert.That(detailsResponse.StatusOutput.StatusCategory, Is.EqualTo("REFUNDED"));
        Assert.That(detailsResponse.StatusOutput.StatusCode, Is.EqualTo(8));
    }

    [TestCase]
    public Task GetPayout_InvalidPayoutId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _payoutsClient.GetPayout(NonExistingPayoutId));

        return Task.CompletedTask;
    }

    #endregion
}
