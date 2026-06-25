using System.Collections.Generic;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.HostedFields;

public class CreateHostedFieldsSessionRequestBuilder
{
    private string _locale = "en_US";
    private IList<string> _tokens;

    #region Setters

    public CreateHostedFieldsSessionRequestBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public CreateHostedFieldsSessionRequestBuilder WithTokens(IList<string> tokens)
    {
        _tokens = tokens;
        return this;
    }

    #endregion

    public CreateHostedFieldsSessionRequest Build() => new()
    {
        Locale = _locale,
        Tokens = _tokens
    };
}
