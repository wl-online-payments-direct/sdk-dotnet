using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Common;
using OnlinePayments.Sdk.It.Builders.Tokenization;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.Tokenization;

namespace OnlinePayments.Sdk.It;

public class TokenizationTest : IntegrationTest
{
    private IPaymentsClient _paymentsClient;
    private ITokenizationClient _tokenizationClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentsClient = Client.WithNewMerchant(GetMerchantId()).Payments;
        _tokenizationClient = Client.WithNewMerchant(GetMerchantId()).Tokenization;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create Certificate

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public async Task CreateCertificate_ValidInput_SuccessfullyGeneratedCertificate()
    {
        CsrRequest request = new CsrRequestBuilder().Build();

        CreateCertificateResponse response = await _tokenizationClient.CreateCertificate(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SignedCertificate, Is.Not.Null.And.Not.Empty);
        Assert.That(response.CertificateId, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public async Task CreateCertificate_WithCallContext_SuccessfullyGeneratedCertificate()
    {
        CsrRequest request = new CsrRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-tokenization-" + Guid.NewGuid());

        CreateCertificateResponse response = await _tokenizationClient.CreateCertificate(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.SignedCertificate, Is.Not.Null.And.Not.Empty);
        Assert.That(response.CertificateId, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public Task CreateCertificate_InvalidCsrInput_ReturnsValidationException()
    {
        CsrRequest request = new CsrRequestBuilder().WithCsr(null).Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokenizationClient.CreateCertificate(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Get By Tokens

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public async Task GetCardDataByTokens_ValidTokensInput_ReturnsCardDataList()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();

        GetCardDataByTokensParams getCardDataByTokensParams = new GetCardDataByTokensParamsBuilder()
            .WithTokens(new List<string>
            {
                tokenId
            })
            .Build();

        DetokenizationResponse response = await _tokenizationClient.GetCardDataByTokens(getCardDataByTokensParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Tokens, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public Task GetCardDataByTokens_NonExistentTokensInput_ReturnsReferenceException()
    {
        GetCardDataByTokensParams request = new GetCardDataByTokensParamsBuilder().WithTokens(new List<string>
        {
            "non-existent-token-xyz"
        }).Build();

        Assert.ThrowsAsync<ReferenceException>(async () => await _tokenizationClient.GetCardDataByTokens(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetCardDataByTokens_InvalidTokensInput_ReturnsValidationException()
    {
        GetCardDataByTokensParams request = new GetCardDataByTokensParamsBuilder().WithTokens(null).Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokenizationClient.GetCardDataByTokens(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Get By Payments

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public async Task GetCardDataByPayments_ValidPaymentsInput_ReturnsCardDataList()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();

        CreatePaymentRequest paymentRequest = new CreatePaymentRequestBuilder().WithToken(tokenId).Build();

        CreatePaymentResponse paymentResponse = await _paymentsClient.CreatePayment(paymentRequest);

        GetCardDataByPaymentsParams request = new GetCardDataByPaymentsParamsBuilder().WithPayments(new List<string>
        {
            paymentResponse.Payment.Id
        }).Build();

        DetokenizationResponse response = await _tokenizationClient.GetCardDataByPayments(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Tokens, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    [Ignore("Test is skipped because the Tokenization endpoint features are not enabled for the test merchant.")]
    public Task GetCardDataByPayments_NonExistentPaymentsInput_ReturnsReferenceException()
    {
        GetCardDataByPaymentsParams getCardDataByPaymentsParams = new GetCardDataByPaymentsParamsBuilder().WithPayments(
            new List<string>
        {
            "non-existent-payment"
        }).Build();

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _tokenizationClient.GetCardDataByPayments(getCardDataByPaymentsParams));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetCardDataByPayments_InvalidPaymentsInput_ReturnsValidationException()
    {
        GetCardDataByPaymentsParams request = new GetCardDataByPaymentsParamsBuilder().WithPayments(null).Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _tokenizationClient.GetCardDataByPayments(request));

        return Task.CompletedTask;
    }

    #endregion
}
