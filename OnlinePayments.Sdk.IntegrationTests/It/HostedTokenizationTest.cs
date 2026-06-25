using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.HostedTokenization;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.HostedTokenization;

namespace OnlinePayments.Sdk.It;

public class HostedTokenizationTest : IntegrationTest
{
    private const string InvalidTokenizationId = "invalid_id_12345";

    private IHostedTokenizationClient  _hostedTokenizationClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _hostedTokenizationClient = Client.WithNewMerchant(GetMerchantId()).HostedTokenization;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreateHostedTokenization_ValidInput_ReturnsHostedTokenizationIdAndUrl()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder().Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithCallContext_ReturnsHostedTokenizationIdAndUrl()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-hosted-tokenization-" + Guid.NewGuid());

        CreateHostedTokenizationResponse response =
            await _hostedTokenizationClient.CreateHostedTokenization(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public void CreateHostedTokenization_WithInvalidLocale_ThrowsValidationException()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithLocale("invalid_locale")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () =>
            await _hostedTokenizationClient.CreateHostedTokenization(request));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithSingleInvalidToken_ReturnsInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithToken("firstInvalidToken")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Has.Count.EqualTo(1));
        Assert.That(response.InvalidTokens, Contains.Item("firstInvalidToken"));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithTwoInvalidTokens_ReturnsTwoInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithTokens("firstInvalidToken", "secondInvalidToken")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Has.Count.EqualTo(2));
        Assert.That(response.InvalidTokens, Contains.Item("firstInvalidToken"));
        Assert.That(response.InvalidTokens, Contains.Item("secondInvalidToken"));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithChainedTokens_ReturnsInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithToken("firstChainedToken")
            .WithToken("secondChainedToken")
            .WithToken("thirdChainedToken")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Has.Count.EqualTo(3));
        Assert.That(response.InvalidTokens, Contains.Item("firstChainedToken"));
        Assert.That(response.InvalidTokens, Contains.Item("secondChainedToken"));
        Assert.That(response.InvalidTokens, Contains.Item("thirdChainedToken"));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithEmptyTokenList_ReturnsHostedTokenizationId()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithTokens()
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithSpecialCharacterTokens_ReturnsInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithTokens("token-with-dashes", "token_with_underscores", "token.with.dots")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Has.Count.EqualTo(3));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithTenInvalidTokens_ReturnsTenInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithTokens(
                "firstToken", "secondToken", "thirdToken", "fourthToken", "fifthToken",
                "sixthToken", "seventhToken", "eighthToken", "ninthToken", "tenthToken")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Has.Count.EqualTo(10));
    }

    [TestCase]
    public async Task CreateHostedTokenization_WithDuplicateTokens_ReturnsInvalidTokens()
    {
        CreateHostedTokenizationRequest request = new CreateHostedTokenizationRequestBuilder()
            .WithTokens("duplicateToken", "duplicateToken", "uniqueToken")
            .Build();

        CreateHostedTokenizationResponse response = await _hostedTokenizationClient.CreateHostedTokenization(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedTokenizationId, Is.Not.Null);
        Assert.That(response.HostedTokenizationUrl, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Null);
        Assert.That(response.InvalidTokens, Is.Not.Empty);
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetHostedTokenization_ValidHostedTokenizationId_ReturnsHostedTokenizationDetails()
    {
        string hostedTokenizationId = await _sdkTestHelper.CreateHostedTokenizationAndGetId();

        GetHostedTokenizationResponse detailsResponse =
            await _hostedTokenizationClient.GetHostedTokenization(hostedTokenizationId);

        Assert.That(detailsResponse, Is.Not.Null);
    }

    [TestCase]
    public Task GetHostedTokenization_InvalidHostedTokenizationId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _hostedTokenizationClient.GetHostedTokenization(InvalidTokenizationId));

        return Task.CompletedTask;
    }

    #endregion
}
