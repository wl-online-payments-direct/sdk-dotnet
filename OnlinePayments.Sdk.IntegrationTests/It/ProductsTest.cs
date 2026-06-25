using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.Products;
using OnlinePayments.Sdk.Merchant.Products;

namespace OnlinePayments.Sdk.It;

public class ProductsTest : IntegrationTest
{
    private const string CountryCode = "NL";
    private const string CurrencyCode = "EUR";
    private const int ExistingProductId = 1;
    private const int NetworksProductId = 302;
    private const int DirectoryProductId = 809;
    private const int NonExistingProductId = -1;

    private IProductsClient _productsClient;

    [SetUp]
    public void Setup()
    {
        _productsClient = Client.WithNewMerchant(GetMerchantId()).Products;
    }

    #region GetPaymentProducts

    [TestCase]
    public async Task GetPaymentProducts_WithValidQueryParams_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PaymentProducts[0], Is.Not.Null);
        Assert.That(response.PaymentProducts[0].Id, Is.GreaterThan(0));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithValidQueryParamsAndCallContext_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        CallContext context = new CallContext().WithIdempotenceKey("test-products-" + Guid.NewGuid());
        GetPaymentProductsResponse response =
            await _productsClient.GetPaymentProducts(getPaymentProductsParams, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PaymentProducts[0], Is.Not.Null);
        Assert.That(response.PaymentProducts[0].Id, Is.GreaterThan(0));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithLocale_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithLocale("en_US")
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null);
        Assert.That(response.PaymentProducts[0], Is.Not.Null);
        Assert.That(response.PaymentProducts[0].Id, Is.GreaterThan(0));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithAmount_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(1000L)
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null);
        Assert.That(response.PaymentProducts[0], Is.Not.Null);
        Assert.That(response.PaymentProducts[0].Id, Is.GreaterThan(0));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithIsRecurring_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithIsRecurring(true)
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null);
        Assert.That(response.PaymentProducts[0], Is.Not.Null);
        Assert.That(response.PaymentProducts[0].Id, Is.GreaterThan(0));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithAddHide_ReturnsPaymentProductList()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("fields")
            .WithHide("accountsOnFile")
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null);
        Assert.That(getPaymentProductsParams.Hide, Is.Not.Null);
        Assert.That(getPaymentProductsParams.Hide, Has.Count.EqualTo(2));
        Assert.That(getPaymentProductsParams.Hide, Contains.Item("fields"));
        Assert.That(getPaymentProductsParams.Hide, Contains.Item("accountsOnFile"));
    }

    [TestCase]
    public async Task GetPaymentProducts_WithHideList_ReturnsPaymentProductList()
    {
        List<string> hideList = ["fields", "translations"];

        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHideList(hideList)
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null);
        Assert.That(getPaymentProductsParams.Hide, Is.EqualTo(hideList));
    }

    [TestCase]
    public void GetPaymentProductsParams_WithAllOptionalParams_HaveCorrectValues()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithLocale("en_US")
            .WithAmount(1000L)
            .WithIsRecurring(true)
            .Build();

        Assert.That(getPaymentProductsParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getPaymentProductsParams.CurrencyCode, Is.EqualTo(CurrencyCode));
        Assert.That(getPaymentProductsParams.Locale, Is.EqualTo("en_US"));
        Assert.That(getPaymentProductsParams.Amount, Is.EqualTo(1000L));
        Assert.That(getPaymentProductsParams.IsRecurring, Is.True);
    }

    [TestCase]
    public Task GetPaymentProducts_WithMissingCountryCode_ThrowsValidationException()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(null)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _productsClient.GetPaymentProducts(getPaymentProductsParams));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task GetPaymentProducts_WithOperationType_ReturnsPaymentProducts()
    {
        GetPaymentProductsParams getPaymentProductsParams = new GetPaymentProductsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithOperationType("Authorization")
            .Build();

        GetPaymentProductsResponse response = await _productsClient.GetPaymentProducts(getPaymentProductsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProducts, Is.Not.Null.And.Not.Empty);
        Assert.That(getPaymentProductsParams.OperationType, Is.EqualTo("Authorization"));
    }

    #endregion

    #region GetPaymentProduct

    [TestCase]
    public async Task GetPaymentProduct_WithExistingProductId_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
    }

    [TestCase]
    public async Task GetPaymentProduct_WithLocale_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithLocale("nl_NL")
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
    }

    [TestCase]
    public async Task GetPaymentProduct_WithAmount_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(2500L)
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
    }

    [TestCase]
    public async Task GetPaymentProduct_WithIsRecurring_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithIsRecurring(false)
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
    }

    [TestCase]
    public async Task GetPaymentProduct_WithAddHide_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("accountsOnFile")
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
        Assert.That(getPaymentProductParams.Hide, Is.Not.Null);
        Assert.That(getPaymentProductParams.Hide, Has.Count.EqualTo(1));
        Assert.That(getPaymentProductParams.Hide, Contains.Item("accountsOnFile"));
    }

    [TestCase]
    public async Task GetPaymentProduct_WithHideList_ReturnsPaymentProduct()
    {
        List<string> hideList = ["fields"];

        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHideList(hideList)
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
        Assert.That(getPaymentProductParams.Hide, Is.EqualTo(hideList));
    }

    [TestCase]
    public void GetPaymentProductParams_WithAllOptionalParams_HaveCorrectValues()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithLocale("nl_NL")
            .WithAmount(2500L)
            .WithIsRecurring(false)
            .Build();

        Assert.That(getPaymentProductParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getPaymentProductParams.CurrencyCode, Is.EqualTo(CurrencyCode));
        Assert.That(getPaymentProductParams.Locale, Is.EqualTo("nl_NL"));
        Assert.That(getPaymentProductParams.Amount, Is.EqualTo(2500L));
        Assert.That(getPaymentProductParams.IsRecurring, Is.False);
    }

    [TestCase]
    public Task GetPaymentProduct_WithNonExistingProductId_ThrowsReferenceException()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _productsClient.GetPaymentProduct(NonExistingProductId, getPaymentProductParams));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.EqualTo(404));

        return Task.CompletedTask;
    }

    [TestCase]
    public async Task GetPaymentProduct_WithOperationType_ReturnsPaymentProduct()
    {
        GetPaymentProductParams getPaymentProductParams = new GetPaymentProductParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithOperationType("Authorization")
            .Build();

        PaymentProduct response = await _productsClient.GetPaymentProduct(ExistingProductId, getPaymentProductParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductId));
        Assert.That(getPaymentProductParams.OperationType, Is.EqualTo("Authorization"));
    }

    #endregion

    #region GetPaymentProductNetworks

    [TestCase]
    public async Task GetPaymentProductNetworks_WithExistingProductId_ReturnsNetworks()
    {
        GetPaymentProductNetworksParams getPaymentProductNetworksParams = new GetPaymentProductNetworksParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        PaymentProductNetworksResponse response =
            await _productsClient.GetPaymentProductNetworks(NetworksProductId, getPaymentProductNetworksParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Networks, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Networks[0], Is.Not.Null);
    }

    [TestCase]
    public async Task GetPaymentProductNetworks_WithAmount_ReturnsNetworks()
    {
        GetPaymentProductNetworksParams getPaymentProductNetworksParams = new GetPaymentProductNetworksParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(3000L)
            .Build();

        PaymentProductNetworksResponse response =
            await _productsClient.GetPaymentProductNetworks(NetworksProductId, getPaymentProductNetworksParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Networks, Is.Not.Null);
    }

    [TestCase]
    public async Task GetPaymentProductNetworks_WithIsRecurring_ReturnsNetworks()
    {
        GetPaymentProductNetworksParams getPaymentProductNetworksParams = new GetPaymentProductNetworksParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithIsRecurring(true)
            .Build();

        PaymentProductNetworksResponse response =
            await _productsClient.GetPaymentProductNetworks(NetworksProductId, getPaymentProductNetworksParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Networks, Is.Not.Null);
    }

    [TestCase]
    public void GetPaymentProductNetworksParams_WithAllOptionalParams_HaveCorrectValues()
    {
        GetPaymentProductNetworksParams getPaymentProductNetworksParams = new GetPaymentProductNetworksParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(3000L)
            .WithIsRecurring(true)
            .Build();

        Assert.That(getPaymentProductNetworksParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getPaymentProductNetworksParams.CurrencyCode, Is.EqualTo(CurrencyCode));
        Assert.That(getPaymentProductNetworksParams.Amount, Is.EqualTo(3000L));
        Assert.That(getPaymentProductNetworksParams.IsRecurring, Is.True);
    }

    [TestCase]
    public Task GetPaymentProductNetworks_WithNonExistingProductId_ThrowsReferenceException()
    {
        GetPaymentProductNetworksParams getPaymentProductNetworksParams = new GetPaymentProductNetworksParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _productsClient.GetPaymentProductNetworks(NonExistingProductId, getPaymentProductNetworksParams));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.Errors[0].HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    #endregion

    #region GetProductDirectory

    [TestCase]
    [Ignore("Test is skipped because no payment method supports directory fot the test merchant.")]
    public async Task GetProductDirectory_WithExistingProductId_ReturnsDirectory()
    {
        GetProductDirectoryParams getProductDirectoryParams = new GetProductDirectoryParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ProductDirectory response =
            await _productsClient.GetProductDirectory(DirectoryProductId, getProductDirectoryParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Entries, Is.Not.Null.And.Not.Empty);
        Assert.That(response.Entries[0], Is.Not.Null);
    }

    [TestCase]
    public Task GetProductDirectory_WithNonExistingProductId_ThrowsReferenceException()
    {
        GetProductDirectoryParams getProductDirectoryParams = new GetProductDirectoryParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ReferenceException exception = Assert.ThrowsAsync<ReferenceException>(async () =>
            await _productsClient.GetProductDirectory(NonExistingProductId, getProductDirectoryParams));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Errors, Is.Not.Null.And.Not.Empty);
        Assert.That(exception.Errors[0].HttpStatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    [TestCase]
    public void GetProductDirectoryParams_WithValidParams_HaveCorrectValues()
    {
        GetProductDirectoryParams getProductDirectoryParams = new GetProductDirectoryParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        Assert.That(getProductDirectoryParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getProductDirectoryParams.CurrencyCode, Is.EqualTo(CurrencyCode));
    }

    #endregion

    #region CreatePaymentProductSession

    [TestCase]
    public Task CreatePaymentProductSession_NonExistingProductId_ThrowsCommunicationException()
    {
        PaymentProductSessionRequest request = new PaymentProductSessionRequestBuilder().Build();

        CommunicationException exception = Assert.ThrowsAsync<CommunicationException>(async () =>
            await _productsClient.CreatePaymentProductSession(NonExistingProductId, request));

        Assert.That(exception, Is.Not.Null);

        return Task.CompletedTask;
    }

    #endregion
}
