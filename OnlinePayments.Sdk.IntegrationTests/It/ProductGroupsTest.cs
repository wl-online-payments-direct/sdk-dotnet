using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.ProductGroups;
using OnlinePayments.Sdk.Merchant.ProductGroups;

namespace OnlinePayments.Sdk.It;

public class ProductGroupsTest : IntegrationTest
{
    private const string CountryCode = "NL";
    private const string CurrencyCode = "EUR";
    private const string ExistingProductGroupId = "cards";
    private const string NonExistingProductGroupId = "invalid-group-id";

    private IProductGroupsClient _productGroupsClient;

    [SetUp]
    public void Setup()
    {
        _productGroupsClient = Client.WithNewMerchant(GetMerchantId()).ProductGroups;
    }

    #region GetProductGroups

    [TestCase]
    public async Task GetProductGroups_WithValidQueryParams_ReturnsProductGroupList()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PaymentProductGroups[0], Is.Not.Null);
    }

    [TestCase]
    public async Task GetProductGroups_WithValidQueryParamsAndCallContext_ReturnsProductGroupList()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        CallContext context = new CallContext().WithIdempotenceKey("test-product-groups-" + Guid.NewGuid());
        GetPaymentProductGroupsResponse response =
            await _productGroupsClient.GetProductGroups(getProductGroupsParams, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null.And.Not.Empty);
        Assert.That(response.PaymentProductGroups[0], Is.Not.Null);
    }

    [TestCase]
    public async Task GetProductGroups_WithAmount_ReturnsProductGroupList()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(1000L)
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null);
    }

    [TestCase]
    public async Task GetProductGroups_WithIsRecurring_ReturnsProductGroupList()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithIsRecurring(true)
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null);
    }

    [TestCase]
    public async Task GetProductGroups_WithAddHide_ReturnsProductGroupList()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("fields")
            .WithHide("accountsOnFile")
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null);
        Assert.That(getProductGroupsParams.Hide, Is.Not.Null);
        Assert.That(getProductGroupsParams.Hide, Has.Count.EqualTo(2));
        Assert.That(getProductGroupsParams.Hide, Contains.Item("fields"));
        Assert.That(getProductGroupsParams.Hide, Contains.Item("accountsOnFile"));
    }

    [TestCase]
    public async Task GetProductGroups_WithHideList_ReturnsProductGroupList()
    {
        List<string> hideList = ["fields", "translations"];

        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHideList(hideList)
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null);
        Assert.That(getProductGroupsParams.Hide, Is.EqualTo(hideList));
    }

    [TestCase]
    public async Task GetProductGroups_WithNullHideElement_SkipsNullInSerialization()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("fields")
            .WithHide(null)
            .Build();

        GetPaymentProductGroupsResponse response = await _productGroupsClient.GetProductGroups(getProductGroupsParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.PaymentProductGroups, Is.Not.Null);
        Assert.That(getProductGroupsParams.Hide, Has.Count.EqualTo(2));
        Assert.That(getProductGroupsParams.Hide, Contains.Item((string)null));
    }

    [TestCase]
    public void GetProductGroupsParams_WithAllOptionalParams_HaveCorrectValues()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(1000L)
            .WithIsRecurring(true)
            .Build();

        Assert.That(getProductGroupsParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getProductGroupsParams.CurrencyCode, Is.EqualTo(CurrencyCode));
        Assert.That(getProductGroupsParams.Amount, Is.EqualTo(1000L));
        Assert.That(getProductGroupsParams.IsRecurring, Is.True);
    }

    [TestCase]
    public Task GetProductGroups_WithMissingCountryCode_ThrowsValidationException()
    {
        GetProductGroupsParams getProductGroupsParams = new GetProductGroupsParamsBuilder()
            .WithCountryCode(null)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        ValidationException exception = Assert.ThrowsAsync<ValidationException>(async () =>
            await _productGroupsClient.GetProductGroups(getProductGroupsParams));

        Assert.That(exception, Is.Not.Null);
        Assert.That((int)exception.StatusCode, Is.EqualTo(400));

        return Task.CompletedTask;
    }

    #endregion

    #region GetProductGroup

    [TestCase]
    public async Task GetProductGroup_WithExistingProductGroupId_ReturnsProductGroup()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
        Assert.That(response.DisplayHints, Is.Not.Null);
    }

    [TestCase]
    public async Task GetProductGroup_WithAmount_ReturnsProductGroup()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(2500L)
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
    }

    [TestCase]
    public async Task GetProductGroup_WithIsRecurring_ReturnsProductGroup()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithIsRecurring(true)
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
    }

    [TestCase]
    public async Task GetProductGroup_WithAddHide_ReturnsProductGroup()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("accountsOnFile")
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
        Assert.That(getProductGroupParams.Hide, Is.Not.Null);
        Assert.That(getProductGroupParams.Hide, Has.Count.EqualTo(1));
        Assert.That(getProductGroupParams.Hide, Contains.Item("accountsOnFile"));
    }

    [TestCase]
    public async Task GetProductGroup_WithHideList_ReturnsProductGroup()
    {
        List<string> hideList = ["fields"];

        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHideList(hideList)
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
        Assert.That(getProductGroupParams.Hide, Is.EqualTo(hideList));
    }

    [TestCase]
    public async Task GetProductGroup_WithNullHideElement_SkipsNullInSerialization()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithHide("accountsOnFile")
            .WithHide(null)
            .Build();

        PaymentProductGroup response =
            await _productGroupsClient.GetProductGroup(ExistingProductGroupId, getProductGroupParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.EqualTo(ExistingProductGroupId).IgnoreCase);
        Assert.That(getProductGroupParams.Hide, Has.Count.EqualTo(2));
        Assert.That(getProductGroupParams.Hide, Contains.Item((string)null));
    }

    [TestCase]
    public void GetProductGroupParams_WithAllOptionalParams_HaveCorrectValues()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .WithAmount(2500L)
            .WithIsRecurring(false)
            .Build();

        Assert.That(getProductGroupParams.CountryCode, Is.EqualTo(CountryCode));
        Assert.That(getProductGroupParams.CurrencyCode, Is.EqualTo(CurrencyCode));
        Assert.That(getProductGroupParams.Amount, Is.EqualTo(2500L));
        Assert.That(getProductGroupParams.IsRecurring, Is.False);
    }

    [TestCase]
    public Task GetProductGroup_WithNonExistingProductGroupId_ThrowsNotFoundException()
    {
        GetProductGroupParams getProductGroupParams = new GetProductGroupParamsBuilder()
            .WithCountryCode(CountryCode)
            .WithCurrencyCode(CurrencyCode)
            .Build();

        NotFoundException exception = Assert.ThrowsAsync<NotFoundException>(async () =>
            await _productGroupsClient.GetProductGroup(NonExistingProductGroupId, getProductGroupParams));

        Assert.That(exception, Is.Not.Null);

        return Task.CompletedTask;
    }

    #endregion
}
