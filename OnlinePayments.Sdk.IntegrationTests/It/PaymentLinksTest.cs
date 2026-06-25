using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.PaymentLinks;
using OnlinePayments.Sdk.It.Helpers;
using OnlinePayments.Sdk.Merchant.PaymentLinks;

namespace OnlinePayments.Sdk.It;

public class PaymentLinksTest : IntegrationTest
{
    private const string UnknownPaymentLinkId = "00000000-0000-0000-0000-000000000000";
    private const string InvalidPaymentLinkId = "invalid-id";

    private IPaymentLinksClient _paymentLinksClient;
    private SdkTestHelper _sdkTestHelper;

    [SetUp]
    public void Setup()
    {
        _paymentLinksClient = Client.WithNewMerchant(GetMerchantId()).PaymentLinks;

        _sdkTestHelper = GetSdkTestHelper();
    }

    #region Create

    [TestCase]
    public async Task CreatePaymentLink_ValidInput_ReturnsPaymentLinkId()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder().Build();

        PaymentLinkResponse response = await _paymentLinksClient.CreatePaymentLink(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectionUrl, Is.Not.Null.And.Not.Empty);

    }

    [TestCase]
    public async Task CreatePaymentLink_WithCallContext_ReturnsPaymentLinkId()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder().Build();
        CallContext context =
            new CallContext().WithIdempotenceKey("test-payment-link-" + Guid.NewGuid());

        PaymentLinkResponse response = await _paymentLinksClient.CreatePaymentLink(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Status, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectionUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreatePaymentLink_DisplayQRCode_ReturnsQrCodeBase64()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder()
            .WithDisplayQrCode(true)
            .Build();

        PaymentLinkResponse response = await _paymentLinksClient.CreatePaymentLink(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.QrCodeBase64, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreatePaymentLink_ReusableLinkEnabled_ReturnsIsReusableLink()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder()
            .WithIsReusableLink(true)
            .Build();

        PaymentLinkResponse response = await _paymentLinksClient.CreatePaymentLink(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.IsReusableLink, Is.True);
    }

    [TestCase]
    public Task CreatePaymentLink_InvalidAmount_ReturnsValidationException()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder()
            .WithAmount(-100)
            .WithCurrencyCode("EUR")
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _paymentLinksClient.CreatePaymentLink(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CreatePaymentLink_ExpirationDateInPast_ReturnsValidationException()
    {
        CreatePaymentLinkRequest request = new CreatePaymentLinkRequestBuilder()
            .WithExpirationDate(DateTimeOffset.UtcNow.AddDays(-1))
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _paymentLinksClient.CreatePaymentLink(request));

        return Task.CompletedTask;
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetPaymentLink_ValidPaymentLinkId_ReturnsDetails()
    {
        string paymentLinkId = await _sdkTestHelper.CreatePaymentLinkAndGetId();

        PaymentLinkResponse response = await _paymentLinksClient.GetPaymentLinkById(paymentLinkId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty.And.EqualTo(paymentLinkId));
        Assert.That(response.Status, Is.Not.Null);
    }

    [TestCase]
    public Task GetPaymentLink_NonExistentPaymentLinkId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentLinksClient.GetPaymentLinkById(UnknownPaymentLinkId));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task GetPaymentLink_InvalidPaymentLinkIdFormat_ReturnsValidationException()
    {
        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentLinksClient.GetPaymentLinkById(InvalidPaymentLinkId));

        return Task.CompletedTask;
    }

    #endregion

    #region Cancel

    [TestCase]
    public async Task CancelPaymentLink_ValidPaymentLinkId_ReturnsSuccessResponse()
    {
        string paymentLinkId = await _sdkTestHelper.CreatePaymentLinkAndGetId();

        await _paymentLinksClient.CancelPaymentLinkById(paymentLinkId);

        PaymentLinkResponse response = await _paymentLinksClient.GetPaymentLinkById(paymentLinkId);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentLinkId, Is.Not.Null.And.Not.Empty.And.EqualTo(paymentLinkId));
        Assert.That(response.PaymentLinkEvents[1].Type, Is.Not.Null.And.Not.Empty.And.EqualTo("CANCELLED"));
    }

    [TestCase]
    public Task CancelPaymentLink_NonExistentPaymentLinkId_ReturnsReferenceException()
    {
        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentLinksClient.CancelPaymentLinkById(UnknownPaymentLinkId));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task CancelPaymentLink_InvalidPaymentLinkIdFormat_ReturnsValidationException()
    {
        Assert.ThrowsAsync<ValidationException>(async () =>
            await _paymentLinksClient.CancelPaymentLinkById(InvalidPaymentLinkId));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task CancelPaymentLink_AlreadyCanceled_ReturnsReferenceException()
    {
        string paymentLinkId = await _sdkTestHelper.CreatePaymentLinkAndGetId();

        await _paymentLinksClient.CancelPaymentLinkById(paymentLinkId);

        Assert.ThrowsAsync<ReferenceException>(async () =>
            await _paymentLinksClient.CancelPaymentLinkById(paymentLinkId));
    }

    #endregion
}
