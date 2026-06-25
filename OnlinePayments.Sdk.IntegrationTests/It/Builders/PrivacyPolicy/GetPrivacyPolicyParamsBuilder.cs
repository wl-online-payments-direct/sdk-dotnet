using OnlinePayments.Sdk.Merchant.PrivacyPolicy;

namespace OnlinePayments.Sdk.It.Builders.PrivacyPolicy;

public class GetPrivacyPolicyParamsBuilder
{
    private string _locale = "en_US";
    private int? _paymentProductId;

    #region Setters

    public GetPrivacyPolicyParamsBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithPaymentProductId(int? paymentProductId)
    {
        _paymentProductId = paymentProductId;
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithEnglishLocale()
    {
        _locale = "en_US";
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithDutchLocale()
    {
        _locale = "nl_NL";
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithFrenchLocale()
    {
        _locale = "fr_FR";
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithGermanLocale()
    {
        _locale = "de_DE";
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithVisaProduct()
    {
        _paymentProductId = 1;
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithAmericanExpressProduct()
    {
        _paymentProductId = 2;
        return this;
    }

    public GetPrivacyPolicyParamsBuilder WithMasterCardProduct()
    {
        _paymentProductId = 3;
        return this;
    }

    #endregion

    public GetPrivacyPolicyParams Build()
    {
        GetPrivacyPolicyParams getPrivacyPolicyParams = new GetPrivacyPolicyParams { Locale = _locale };

        if (_paymentProductId != null)
        {
            getPrivacyPolicyParams.PaymentProductId = _paymentProductId;
        }

        return getPrivacyPolicyParams;
    }
}
