using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Tokens;

namespace OnlinePayments.Sdk.It;

public class TokensTest : IntegrationTest
{
    private const string InvalidTokenId = "invalid_id_12345";
    private const string ExpectedCardholderName = "John Doe";
    private const string ExpectedExpiryDate = "1230";

    private ITokensClient _tokensClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _tokensClient = Client.WithNewMerchant(GetMerchantId()).Tokens;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreateToken_ValidInput_ReturnsSuccessfullyCreatedToken()
    {
        CreateTokenRequest request = new CreateTokenRequestBuilder().Build();

        CreatedTokenResponse response = await _tokensClient.CreateToken(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Token, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Card, Is.Not.Null);
        Assert.That(response.Card.CardNumber, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Card.CardholderName, Is.EqualTo(ExpectedCardholderName));
        Assert.That(response.Card.ExpiryDate, Is.EqualTo(ExpectedExpiryDate));
    }

    [TestCase]
    public async Task CreateToken_ValidInputWithCallContext_ReturnsSuccessfullyCreatedToken()
    {
        CreateTokenRequest request = new CreateTokenRequestBuilder().Build();
        CallContext callContext = new CallContext().WithIdempotenceKey("test-tokens-" + Guid.NewGuid());

        CreatedTokenResponse response = await _tokensClient.CreateToken(request, callContext);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Token, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Card, Is.Not.Null);
        Assert.That(response.Card.CardNumber, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Card.CardholderName, Is.EqualTo(ExpectedCardholderName));
        Assert.That(response.Card.ExpiryDate, Is.EqualTo(ExpectedExpiryDate));
    }

    [TestCase]
    public Task CreateToken_InvalidCardNumberInput_ReturnsValidationException()
    {
        CreateTokenRequest request = new CreateTokenRequestBuilder().WithCardNumber("1234567890123456").Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokensClient.CreateToken(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreateToken_InvalidExpiryDateInput_ReturnsValidationException()
    {
        CreateTokenRequest request = new CreateTokenRequestBuilder().WithExpiryDate("0000").Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokensClient.CreateToken(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreateToken_InvalidCvvInput_ReturnsValidationException()
    {
        CreateTokenRequest request = new CreateTokenRequestBuilder().WithCvv("12345678").Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokensClient.CreateToken(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetToken_ValidTokenId_ReturnsTokenDetails()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();

        TokenResponse detailsResponse = await _tokensClient.GetToken(tokenId);

        Assert.That(detailsResponse, Is.Not.Null);
        Assert.That(detailsResponse.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(detailsResponse.Id, Is.Not.Null.And.Not.Empty.And.EqualTo(tokenId));
        Assert.That(detailsResponse.PaymentProductId,  Is.Not.Null);

        Assert.That(detailsResponse.Card, Is.Not.Null);
        Assert.That(detailsResponse.Card.Data, Is.Not.Null);
        Assert.That(detailsResponse.Card.Data.CardWithoutCvv, Is.Not.Null);
        Assert.That(detailsResponse.Card.Data.CardWithoutCvv.CardNumber, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task GetToken_InvalidTokenId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _tokensClient.GetToken(InvalidTokenId));

        return Task.CompletedTask;
    }

    #endregion

    #region Delete

    [TestCase]
    public async Task DeleteToken_ValidTokenId_SuccessfullyDeletesToken()
    {
        var tokenId = await _sdkTestHelper.CreateTokenAndGetId();

        await _tokensClient.DeleteToken(tokenId);

        Assert.ThrowsAsync<ReferenceException>(async () => await _tokensClient.GetToken(tokenId));
    }

    [TestCase]
    public Task DeleteToken_InvalidTokenId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () => await _tokensClient.DeleteToken(InvalidTokenId));

        return Task.CompletedTask;
    }

    #endregion
}
