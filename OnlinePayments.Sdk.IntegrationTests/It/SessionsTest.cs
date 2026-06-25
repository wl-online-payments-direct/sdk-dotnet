using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Sessions;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Sessions;

namespace OnlinePayments.Sdk.It;

public class SessionsTest : IntegrationTest
{
    private ISessionsClient _sessionsClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _sessionsClient = Client.WithNewMerchant(GetMerchantId()).Sessions;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreateSession_ValidInput_ReturnsClientSessionId()
    {
        SessionRequest request = new SessionRequestBuilder().Build();

        SessionResponse response = await _sessionsClient.CreateSession(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.ClientSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.AssetUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(response.ClientApiUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateSession_WithCallContext_ReturnsClientSessionId()
    {
        SessionRequest request = new SessionRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-session-" + Guid.NewGuid());

        SessionResponse response = await _sessionsClient.CreateSession(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.ClientSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.AssetUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(response.ClientApiUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateSession_ValidToken_ReturnsClientSessionId()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();
        SessionRequest request = new SessionRequestBuilder()
            .WithToken(tokenId)
            .Build();

        SessionResponse response = await _sessionsClient.CreateSession(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.ClientSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.InvalidTokens, Is.Null.Or.Not.Contain(tokenId));
    }

    [TestCase]
    public Task CreateSession_WithTooManyTokens_ThrowsValidationException()
    {
        SessionRequest request = new SessionRequestBuilder()
            .WithTokens(
                "firstToken", "secondToken", "thirdToken", "fourthToken", "fifthToken",
                "sixthToken", "seventhToken", "eighthToken", "ninthToken", "tenthToken", "eleventhToken")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _sessionsClient.CreateSession(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task CreateSession_InvalidTokenValues_ReturnsInvalidTokensList()
    {
        SessionRequest request = new SessionRequestBuilder()
            .WithTokens("65468465464646", "654646464", "easgudasdas")
            .Build();

        SessionResponse response = await _sessionsClient.CreateSession(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.ClientSessionId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.InvalidTokens, Is.Not.Null.And.Not.Empty);
    }

    #endregion
}
