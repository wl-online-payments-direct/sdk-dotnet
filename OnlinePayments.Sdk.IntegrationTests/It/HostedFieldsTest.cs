using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.HostedFields;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.HostedFields;

namespace OnlinePayments.Sdk.It;

public class HostedFieldsTest : IntegrationTest
{
    private const string InvalidLocale = "invalid-locale";

    private IHostedFieldsClient _hostedFieldsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _hostedFieldsClient = Client.WithNewMerchant(GetMerchantId()).HostedFields;
        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreateHostedFieldsSession_ValidInput_ReturnsHostedFieldsSessionId()
    {
        CreateHostedFieldsSessionRequest request = new CreateHostedFieldsSessionRequestBuilder().Build();

        CreateHostedFieldsSessionResponse response = await _hostedFieldsClient.CreateHostedFieldsSession(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SessionData, Is.Not.Null);
        Assert.That(response.SessionData.HostedFieldsSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.SdkUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(response.SdkSri, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedFieldsSession_WithCallContext_ReturnsHostedFieldsSessionId()
    {
        CreateHostedFieldsSessionRequest request = new CreateHostedFieldsSessionRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-hosted-fields-" + Guid.NewGuid());

        CreateHostedFieldsSessionResponse response =
            await _hostedFieldsClient.CreateHostedFieldsSession(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SessionData, Is.Not.Null);
        Assert.That(response.SessionData.HostedFieldsSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.SdkUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(response.SdkSri, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedFieldsSession_WithTokens_ReturnsSessionDataWithTokens()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();
        CreateHostedFieldsSessionRequest request = new CreateHostedFieldsSessionRequestBuilder()
            .WithTokens(new List<string> { tokenId })
            .Build();

        CreateHostedFieldsSessionResponse response = await _hostedFieldsClient.CreateHostedFieldsSession(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SessionData, Is.Not.Null);
        Assert.That(response.SessionData.HostedFieldsSessionId, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task CreateHostedFieldsSession_MissingLocaleInput_ReturnsValidationException()
    {
        CreateHostedFieldsSessionRequest request = new CreateHostedFieldsSessionRequestBuilder()
            .WithLocale(null)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _hostedFieldsClient.CreateHostedFieldsSession(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreateHostedFieldsSession_EmptyLocaleInput_ReturnsValidationException()
    {
        CreateHostedFieldsSessionRequest request =
            new CreateHostedFieldsSessionRequestBuilder().WithLocale(string.Empty).Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _hostedFieldsClient.CreateHostedFieldsSession(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreateHostedFieldsSession_InvalidLocaleFormat_ReturnsUnprocessableEntityException()
    {
        CreateHostedFieldsSessionRequest request = new CreateHostedFieldsSessionRequestBuilder()
            .WithLocale(InvalidLocale)
            .Build();

        ApiException exception = Assert.ThrowsAsync<ApiException>(async () =>
            await _hostedFieldsClient.CreateHostedFieldsSession(request));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity));

        return Task.CompletedTask;
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetHostedFieldsSession_WithValidSessionId_ReturnsSession()
    {
        CreateHostedFieldsSessionRequest createRequest = new CreateHostedFieldsSessionRequestBuilder().Build();
        CreateHostedFieldsSessionResponse createResponse = await _hostedFieldsClient.CreateHostedFieldsSession(createRequest);
        string sessionId = createResponse.SessionData.HostedFieldsSessionId;

        GetHostedFieldsSessionResponse response = await _hostedFieldsClient.GetHostedFieldsSession(sessionId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SessionId, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task GetHostedFieldsSession_WithInvalidSessionId_ThrowsProblemDetailsException()
    {
        Assert.ThrowsAsync<ProblemDetailsException>(async () =>
            await _hostedFieldsClient.GetHostedFieldsSession("invalid-session-id"));

        return Task.CompletedTask;
    }

    #endregion
}
