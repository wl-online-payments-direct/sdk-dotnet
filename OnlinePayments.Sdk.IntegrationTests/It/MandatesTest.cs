using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Mandates;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Mandates;

namespace OnlinePayments.Sdk.It;

public class MandatesTest : IntegrationTest
{
    private const string InvalidIban = "INVALID";
    private const string InvalidMandateReference = "INVALID123456";

    private IMandatesClient _mandatesClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _mandatesClient = Client.WithNewMerchant(GetMerchantId()).Mandates;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreateMandate_WithValidRequest_ReturnsMandateReference()
    {
        CreateMandateRequest request = new CreateMandateRequestBuilder()
            .WithUniqueMandateReference("exampleMandateReference" + DateTime.Now.ToString("HH:mm:ss.fff"))
            .Build();

        CreateMandateResponse response = await _mandatesClient.CreateMandate(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateMandate_WithValidRequestAndCallContext_ReturnsMandateReference()
    {
        CreateMandateRequest request = new CreateMandateRequestBuilder()
            .WithUniqueMandateReference("exampleMandateReference" + DateTime.Now.ToString("HH:mm:ss.fff"))
            .Build();

        CallContext context = new CallContext().WithIdempotenceKey("test-mandates-" + Guid.NewGuid());
        CreateMandateResponse response = await _mandatesClient.CreateMandate(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task CreateMandate_WithInvalidIban_ThrowsValidationException()
    {
        CreateMandateRequest request = new CreateMandateRequestBuilder()
            .WithCustomerIban(InvalidIban)
            .WithUniqueMandateReference("exampleMandateReference" + DateTime.Now.ToString("HH:mm:ss.fff"))
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _mandatesClient.CreateMandate(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetMandate_WithValidMandateReference_ReturnsMandateDetails()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();

        GetMandateResponse response = await _mandatesClient.GetMandate(mandateReference);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task GetMandate_WithInvalidMandateReference_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _mandatesClient.GetMandate(InvalidMandateReference));

        return Task.CompletedTask;
    }

    #endregion

    #region Block

    [TestCase]
    public async Task BlockMandate_WithValidMandateReference_ReturnsMandateReference()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();

        GetMandateResponse response = await _mandatesClient.BlockMandate(mandateReference);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task BlockMandate_WithAlreadyBlockedMandate_ThrowsValidationException()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.BlockMandate(mandateReference);

        Assert.ThrowsAsync<ValidationException>(async () => await _mandatesClient.BlockMandate(mandateReference));
    }

    [TestCase]
    public async Task BlockMandate_WithRevokedMandate_ThrowsValidationException()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.RevokeMandate(mandateReference, new RevokeMandateRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () => await _mandatesClient.BlockMandate(mandateReference));
    }

    [TestCase]
    public Task BlockMandate_WithInvalidMandateReference_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _mandatesClient.BlockMandate(InvalidMandateReference));

        return Task.CompletedTask;
    }

    #endregion

    #region Unblock

    [TestCase]
    public async Task UnblockMandate_WithBlockedMandate_ReturnsMandateReference()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.BlockMandate(mandateReference);

        GetMandateResponse response = await _mandatesClient.UnblockMandate(mandateReference);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task UnblockMandate_WithNotBlockedMandate_ThrowsValidationException()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();

        Assert.ThrowsAsync<ValidationException>(async () => await _mandatesClient.UnblockMandate(mandateReference));
    }

    [TestCase]
    public async Task UnblockMandate_WithRevokedMandate_ThrowsValidationException()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.RevokeMandate(mandateReference, new RevokeMandateRequestBuilder().Build());

        Assert.ThrowsAsync<ValidationException>(async () => await _mandatesClient.UnblockMandate(mandateReference));
    }

    [TestCase]
    public Task UnblockMandate_WithInvalidMandateReference_ThrowsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _mandatesClient.UnblockMandate(InvalidMandateReference));

        return Task.CompletedTask;
    }

    #endregion

    #region Revoke

    [TestCase]
    public async Task RevokeMandate_WithValidMandate_ReturnsMandateReference()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        RevokeMandateRequest request = new RevokeMandateRequestBuilder().Build();

        GetMandateResponse response = await _mandatesClient.RevokeMandate(mandateReference, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task RevokeMandate_WithBlockedMandate_ReturnsMandateReference()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.BlockMandate(mandateReference);
        RevokeMandateRequest request = new RevokeMandateRequestBuilder().Build();

        GetMandateResponse response = await _mandatesClient.RevokeMandate(mandateReference, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task RevokeMandate_WithUnblockedMandate_ReturnsMandateReference()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        await _mandatesClient.BlockMandate(mandateReference);
        await _mandatesClient.UnblockMandate(mandateReference);
        RevokeMandateRequest request = new RevokeMandateRequestBuilder().Build();

        GetMandateResponse response = await _mandatesClient.RevokeMandate(mandateReference, request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Mandate, Is.Not.Null);
        Assert.That(response.Mandate.UniqueMandateReference, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task RevokeMandate_WithAlreadyRevokedMandate_ThrowsValidationException()
    {
        string mandateReference = await _sdkTestHelper.CreateMandateAndGetReference();
        RevokeMandateRequest revokeRequest = new RevokeMandateRequestBuilder().Build();
        await _mandatesClient.RevokeMandate(mandateReference, revokeRequest);

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _mandatesClient.RevokeMandate(mandateReference, revokeRequest));
    }

    [TestCase]
    public Task RevokeMandate_WithInvalidMandateReference_ThrowsValidationException()
    {
        RevokeMandateRequest request = new RevokeMandateRequestBuilder().Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _mandatesClient.RevokeMandate(InvalidMandateReference, request));

        return Task.CompletedTask;
    }

    #endregion
}
