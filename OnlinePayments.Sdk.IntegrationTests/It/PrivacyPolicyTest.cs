using System;
using NUnit.Framework;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.It.Builders.PrivacyPolicy;
using OnlinePayments.Sdk.Merchant.PrivacyPolicy;

namespace OnlinePayments.Sdk.It;

public class PrivacyPolicyTest : IntegrationTest
{
    private IPrivacyPolicyClient _privacyPolicyClient;

    [SetUp]
    public void Setup()
    {
        _privacyPolicyClient = Client.WithNewMerchant(GetMerchantId()).PrivacyPolicy;
    }

    #region GetPrivacyPolicy - Valid input

    [TestCase]
    public async Task GetPrivacyPolicy_ValidInput_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder().Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
    }

    [TestCase]
    public async Task GetPrivacyPolicy_ValidInputWithCallContext_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder().Build();
        CallContext context = new CallContext().WithIdempotenceKey("test-privacy-policy-" + Guid.NewGuid());

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams, context);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
    }

    [TestCase]
    public async Task GetPrivacyPolicy_SpecificPaymentProduct_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithVisaProduct()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(1));
    }

    #endregion

    #region GetPrivacyPolicy - Different locales

    [TestCase]
    public async Task GetPrivacyPolicy_EnglishLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithEnglishLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("en_US"));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_DutchLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithDutchLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("nl_NL"));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_FrenchLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithFrenchLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("fr_FR"));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_GermanLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithGermanLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("de_DE"));
    }

    #endregion

    #region GetPrivacyPolicy - Different payment products

    [TestCase]
    public async Task GetPrivacyPolicy_VisaProduct_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithVisaProduct()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(1));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_AmericanExpressProduct_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithAmericanExpressProduct()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(2));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_MasterCardProduct_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithMasterCardProduct()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(3));
    }

    #endregion

    #region GetPrivacyPolicy - Combined parameters

    [TestCase]
    public async Task GetPrivacyPolicy_VisaProductAndFrenchLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithVisaProduct()
            .WithFrenchLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(1));
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("fr_FR"));
    }

    [TestCase]
    public async Task GetPrivacyPolicy_AmericanExpressProductAndGermanLocale_ReturnsGetPrivacyPolicyResponse()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParamsBuilder()
            .WithAmericanExpressProduct()
            .WithGermanLocale()
            .Build();

        GetPrivacyPolicyResponse response = await _privacyPolicyClient.GetPrivacyPolicy(getPrivacyPolicyParams);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.HtmlContent, Is.Not.Null);
        Assert.That(getPrivacyPolicyParams.PaymentProductId, Is.EqualTo(2));
        Assert.That(getPrivacyPolicyParams.Locale, Is.EqualTo("de_DE"));
    }

    #endregion
}
