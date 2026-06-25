using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Webhooks;
using OnlinePayments.Sdk.Merchant.Webhooks;

namespace OnlinePayments.Sdk.It;

public class WebhooksTest : IntegrationTest
{
    private const string ValidWebhookKey = "test-key";
    private const string ValidWebhookSecret = "test-secret";
    private const string InvalidWebhookUrl = "invalid-url";
    private const string ValidWebhookUrl = "https://example.com/webhook";

    private IWebhooksClient _webhooksClient;

    [SetUp]
    public void Setup()
    {
        _webhooksClient = Client.WithNewMerchant(GetMerchantId()).Webhooks;
    }

    #region ValidateWebhookCredentials

    [TestCase]
    public async Task ValidateWebhookCredentials_ValidCredentials_ReturnsResult()
    {
        ValidateCredentialsRequest request = new ValidateCredentialsRequestBuilder()
            .WithKey(ValidWebhookKey)
            .WithSecret(ValidWebhookSecret)
            .Build();

        ValidateCredentialsResponse response = await _webhooksClient.ValidateWebhookCredentials(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
    }

    [TestCase]
    public async Task ValidateWebhookCredentials_ValidCredentials_WithCallContext_ReturnsResult()
    {
        ValidateCredentialsRequest request = new ValidateCredentialsRequestBuilder()
            .WithKey(ValidWebhookKey)
            .WithSecret(ValidWebhookSecret)
            .Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-webhooks-" + Guid.NewGuid());

        ValidateCredentialsResponse response = await _webhooksClient.ValidateWebhookCredentials(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
    }

    [TestCase]
    public async Task ValidateWebhookCredentials_IncorrectSecret_ReturnsInvalidResult()
    {
        ValidateCredentialsRequest request = new ValidateCredentialsRequestBuilder()
            .WithKey(ValidWebhookKey)
            .WithSecret("incorrect-secret")
            .Build();

        ValidateCredentialsResponse response = await _webhooksClient.ValidateWebhookCredentials(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Result, Is.Not.Null);
        Assert.That(response.Result, Is.EqualTo("Invalid"));
    }

    #endregion

    #region SendTestWebhook

    [TestCase]
    public Task SendTestWebhook_WithValidUrl_WithoutConfig_ThrowsValidationException()
    {
        SendTestRequest request = new SendTestRequestBuilder()
            .WithUrl(ValidWebhookUrl)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _webhooksClient.SendTestWebhook(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task SendTestWebhook_WithoutUrl_ThrowsValidationException()
    {
        SendTestRequest request = new SendTestRequestBuilder()
            .WithUrl(null)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _webhooksClient.SendTestWebhook(request));

        return Task.CompletedTask;
    }

    [TestCase]
    public Task SendTestWebhook_WithInvalidUrl_ThrowsValidationException()
    {
        SendTestRequest request = new SendTestRequestBuilder()
            .WithUrl(InvalidWebhookUrl)
            .Build();

        Assert.ThrowsAsync<ValidationException>(async () => await _webhooksClient.SendTestWebhook(request));

        return Task.CompletedTask;
    }

    #endregion
}
