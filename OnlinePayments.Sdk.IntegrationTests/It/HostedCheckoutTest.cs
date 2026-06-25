using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.HostedCheckout;
using OnlinePayments.Sdk.Merchant.HostedCheckout;

namespace OnlinePayments.Sdk.It;

public class HostedCheckoutTest : IntegrationTest
{
    private const string InvalidHostedCheckoutId = "9999999999_0";

    private IHostedCheckoutClient _hostedCheckoutClient;

    [SetUp]
    public void Setup()
    {
        _hostedCheckoutClient = Client.WithNewMerchant(GetMerchantId()).HostedCheckout;
    }

    #region Create

    [TestCase]
    public async Task CreateHostedCheckout_ValidInput_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithFirstName("John")
            .WithSurname("Doe")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.MerchantReference, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PartialRedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithCustomerDetails_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithAmount(5000L)
            .WithCountryCode("DE")
            .WithLocale("en_GB")
            .WithFirstName("Jane")
            .WithSurname("Smith")
            .WithEmailAddress("jane@example.com")
            .WithPhoneNumber("+441234567890")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithCardAndFilters_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithFirstName("Bob")
            .WithSurname("Johnson")
            .WithAmount(2500L)
            .WithCurrency("EUR")
            .WithCountryCode("DE")
            .WithLocale("de_DE")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithSessionTimeout_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithSessionTimeout(300)
            .WithFirstName("Alex")
            .WithSurname("Williams")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithDifferentLocales_ReturnsHostedCheckoutId()
    {
        string[] locales = ["en_US", "de_DE", "fr_FR", "es_ES", "it_IT", "nl_NL"];

        foreach (string locale in locales)
        {
            CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
                .WithLocale(locale)
                .WithFirstName("Test")
                .WithSurname("User")
                .Build();

            CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
            Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
        }
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithCustomAmount_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithAmount(9999L)
            .WithCurrency("USD")
            .WithFirstName("Rich")
            .WithSurname("Customer")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithBillingAddress_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithFirstName("John")
            .WithSurname("Resident")
            .WithCountryCode("US")
            .WithCity("San Francisco")
            .WithStreet("Main Street")
            .WithHouseNumber("123")
            .WithState("CA")
            .WithZip("94102")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithClickToPay_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithCardClickToPay(true)
            .WithFirstName("ClickToPay")
            .WithSurname("Customer")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithGroupCards_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithCardGroupCards(true)
            .WithFirstName("GroupCards")
            .WithSurname("Customer")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null.And.Not.Empty);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithCallContext_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithFirstName("CallContext")
            .WithSurname("Test")
            .Build();

        CallContext context = new CallContext().WithIdempotenceKey("test-hosted-checkout-" + Guid.NewGuid());
        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithResultPageHidden_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithShowResultPage(false)
            .WithFirstName("Silent")
            .WithSurname("Payment")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithResultPageShown_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithShowResultPage(true)
            .WithFirstName("Visible")
            .WithSurname("Result")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithIsRecurringTrue_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithIsRecurring(true)
            .WithFirstName("Recurring")
            .WithSurname("Customer")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithIsRecurringFalse_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithIsRecurring(false)
            .WithFirstName("OneOff")
            .WithSurname("Payment")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithNewUnscheduledCardOnFile_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithIsNewUnscheduledCardOnFileSeries(true)
            .WithFirstName("Card")
            .WithSurname("OnFile")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithoutTokenization_ReturnsHostedCheckoutId()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithIsNewUnscheduledCardOnFileSeries(false)
            .WithFirstName("No")
            .WithSurname("Token")
            .Build();

        CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HostedCheckoutId, Is.Not.Null);
        Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task CreateHostedCheckout_MultipleRequests_ReturnsHostedCheckoutId()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
                .WithFirstName("Batch")
                .WithSurname("Customer" + i)
                .Build();

            CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.HostedCheckoutId, Is.Not.Null);
            Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
        }
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithDifferentAmounts_ReturnsHostedCheckoutId()
    {
        long[] amounts = [1000L, 2500L, 5000L, 10000L];

        foreach (long amount in amounts)
        {
            CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
                .WithAmount(amount)
                .WithCurrency("EUR")
                .WithFirstName("Amount")
                .WithSurname("Test")
                .Build();

            CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.HostedCheckoutId, Is.Not.Null);
            Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
        }
    }

    [TestCase]
    public async Task CreateHostedCheckout_WithDifferentCurrencies_ReturnsHostedCheckoutId()
    {
        string[] currencies = ["EUR", "GBP", "USD", "CHF", "SEK"];

        foreach (string currency in currencies)
        {
            CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
                .WithAmount(2000L)
                .WithCurrency(currency)
                .WithFirstName("Currency")
                .WithSurname("Test")
                .Build();

            CreateHostedCheckoutResponse response = await _hostedCheckoutClient.CreateHostedCheckout(request);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.HostedCheckoutId, Is.Not.Null);
            Assert.That(response.RedirectUrl, Is.Not.Null.And.Not.Empty);
        }
    }

    #endregion

    #region Get

    [TestCase]
    public async Task GetHostedCheckout_ValidHostedCheckoutId_ReturnsDetails()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithFirstName("Status")
            .WithSurname("Check")
            .Build();

        CreateHostedCheckoutResponse createResponse = await _hostedCheckoutClient.CreateHostedCheckout(request);

        GetHostedCheckoutResponse detailsResponse =
            await _hostedCheckoutClient.GetHostedCheckout(createResponse.HostedCheckoutId);

        Assert.That(detailsResponse, Is.Not.Null);
        Assert.That(detailsResponse.Status, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public async Task GetHostedCheckout_ValidHostedCheckoutId_ReturnsCreatedPaymentOutput()
    {
        CreateHostedCheckoutRequest request = new CreateHostedCheckoutRequestBuilder()
            .WithAmount(7500L)
            .WithCurrency("EUR")
            .WithCountryCode("DE")
            .WithLocale("en_GB")
            .WithFirstName("Retrieve")
            .WithSurname("Payment")
            .Build();

        CreateHostedCheckoutResponse createResponse = await _hostedCheckoutClient.CreateHostedCheckout(request);

        GetHostedCheckoutResponse detailsResponse =
            await _hostedCheckoutClient.GetHostedCheckout(createResponse.HostedCheckoutId);

        Assert.That(detailsResponse, Is.Not.Null);
        Assert.That(detailsResponse.CreatedPaymentOutput, Is.Not.Null);
    }

    [TestCase]
    public Task GetHostedCheckout_InvalidHostedCheckoutId_ReturnsReferenceException()
    {
        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _hostedCheckoutClient.GetHostedCheckout(InvalidHostedCheckoutId));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        return Task.CompletedTask;
    }

    #endregion
}
