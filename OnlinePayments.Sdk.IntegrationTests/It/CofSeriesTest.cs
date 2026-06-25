using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.CofSeries;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.CofSeries;

namespace OnlinePayments.Sdk.It;

public class CofSeriesTest : IntegrationTest
{
    private ICofSeriesClient _cofSeriesClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _cofSeriesClient = Client.WithNewMerchant(GetMerchantId()).CofSeries;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region ImportCofSeries - Valid card input

    [TestCase]
    [Ignore("Test is skipped because the Import COF Series feature is not enabled for the test merchant.")]
    public async Task ImportCofSeries_ValidInput_ReturnsImportCofSeriesResponse()
    {
        ImportCofSeriesRequest request = new ImportCofSeriesRequestBuilder().Build();

        ImportCofSeriesResponse response = await _cofSeriesClient.ImportCofSeries(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentId, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    [Ignore("Test is skipped because the Import COF Series feature is not enabled for the test merchant.")]
    public async Task ImportCofSeries_ValidInputWithCallContext_ReturnsImportCofSeriesResponse()
    {
        ImportCofSeriesRequest request = new ImportCofSeriesRequestBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-cof-series-" + Guid.NewGuid());

        ImportCofSeriesResponse response = await _cofSeriesClient.ImportCofSeries(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentId, Is.Not.Null.And.Not.Empty);
    }

    #endregion

    #region ImportCofSeries - Valid token input

    [TestCase]
    [Ignore("Test is skipped because the Import COF Series feature is not enabled for the test merchant.")]
    public async Task ImportCofSeries_ValidTokenId_ReturnsImportCofSeriesResponse()
    {
        string tokenId = await _sdkTestHelper.CreateTokenAndGetId();
        ImportCofSeriesRequest request = new ImportCofSeriesRequestBuilder()
            .WithTokenId(tokenId)
            .Build();

        ImportCofSeriesResponse response = await _cofSeriesClient.ImportCofSeries(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentId, Is.Not.Null.And.Not.Empty);
    }

    #endregion

    #region ImportCofSeries - Invalid input

    [TestCase]
    public Task ImportCofSeries_InvalidInput_ThrowsValidationException()
    {
        ImportCofSeriesRequest request = new ImportCofSeriesRequestBuilder()
            .WithSchemeReferenceData(null)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _cofSeriesClient.ImportCofSeries(request));

        return Task.CompletedTask;
    }

    #endregion

    #region ImportCofSeries - TransactionLinkIdentifier

    [TestCase]
    [Ignore("Test is skipped because the Import COF Series feature is not enabled for the test merchant.")]
    public async Task ImportCofSeries_WithInvalidTransactionLinkIdentifier_ReturnsTransactionLinkIdentifier()
    {
        string paymentId = await _sdkTestHelper.CreatePaymentAndGetId();
        ImportCofSeriesRequest request = new ImportCofSeriesRequestBuilder()
            .WithTransactionLinkIdentifier(paymentId)
            .Build();

        ImportCofSeriesResponse response = await _cofSeriesClient.ImportCofSeries(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentId, Is.Not.Null.And.Not.Empty);
    }

    #endregion
}
