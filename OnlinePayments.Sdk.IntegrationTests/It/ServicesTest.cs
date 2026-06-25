using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Services;
using OnlinePayments.Sdk.Merchant.Services;

namespace OnlinePayments.Sdk.It;

public class ServicesTest : IntegrationTest
{
    private const string InvalidBin = "123";

    private IServicesClient _servicesClient;

    [SetUp]
    public void Setup()
    {
        _servicesClient = Client.WithNewMerchant(GetMerchantId()).Services;
    }

    #region TestConnection

    [TestCase]
    public async Task TestConnection_ValidRequest_ReturnsTestConnection()
    {
        TestConnection response = await _servicesClient.TestConnection();

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
    }

    [TestCase]
    public async Task TestConnection_ValidRequestWithCallContext_ReturnsTestConnection()
    {
        CallContext callContext = new CallContext().WithIdempotenceKey("test-services-" + Guid.NewGuid());
        TestConnection response = await _servicesClient.TestConnection(callContext);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
    }

    #endregion

    #region GetIINDetails

    [TestCase]
    public async Task GetIINDetails_ValidCardNumber_ReturnsIINDetails()
    {
        GetIINDetailsRequest request = new GetIinDetailsRequestBuilder().Build();

        GetIINDetailsResponse response = await _servicesClient.GetIINDetails(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.CardType, Is.Not.Null);
        Assert.That(response.PaymentProductId, Is.Not.Null);
        Assert.That(response.CardScheme, Is.Not.Null);
    }

    [TestCase]
    public Task GetIINDetails_InvalidCardNumber_ReturnsValidationException()
    {
        GetIINDetailsRequest request = new GetIinDetailsRequestBuilder().WithBin(InvalidBin).Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _servicesClient.GetIINDetails(request));

        return Task.CompletedTask;
    }

    #endregion

    #region GetDccRateInquiry

    [TestCase]
    [Ignore("Test is skipped because the Currency Conversion feature is not enabled for the test merchant.")]
    public async Task GetDccRateInquiry_ValidRequest_ReturnsCurrencyConversionResponse()
    {
        CurrencyConversionRequest request = new CurrencyConversionRequestBuilder()
            .WithCardNumber("4012000033330026")
            .Build();

        CurrencyConversionResponse response = await _servicesClient.GetDccRateInquiry(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
    }

    [TestCase]
    public Task GetDccRateInquiry_MissingCardSourceAndTransaction_ReturnsValidationException()
    {
        CurrencyConversionRequest request = new CurrencyConversionRequestBuilder()
            .WithAmount(1000)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _servicesClient.GetDccRateInquiry(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetDccRateInquiry_InvalidAmount_ReturnsValidationException()
    {
        CurrencyConversionRequest request = new CurrencyConversionRequestBuilder()
            .WithAmount(-1000L)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _servicesClient.GetDccRateInquiry(request));

        return Task.CompletedTask;
    }

    #endregion

    #region SurchargeCalculation

    [TestCase]
    [Ignore("Test is skipped because the Surcharge Calculation feature is not enabled for the test merchant.")]
    public async Task SurchargeCalculation_ValidRequest_ReturnsSurchargeCalculationResponse()
    {
        CalculateSurchargeRequest request = new CalculateSurchargeRequestBuilder()
            .WithCardNumber("5425233430109903")
            .Build();

        CalculateSurchargeResponse response = await _servicesClient.SurchargeCalculation(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Surcharges, Is.Not.Null);
    }

    [TestCase]
    public Task SurchargeCalculation_MissingCardSource_ReturnsValidationException()
    {
        CalculateSurchargeRequest request = new CalculateSurchargeRequestBuilder().Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _servicesClient.SurchargeCalculation(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task SurchargeCalculation_InvalidAmount_ReturnsValidationException()
    {
        CalculateSurchargeRequest request = new CalculateSurchargeRequestBuilder().WithAmount(-1000L).Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _servicesClient.SurchargeCalculation(request));

        return Task.CompletedTask;
    }

    #endregion
}
