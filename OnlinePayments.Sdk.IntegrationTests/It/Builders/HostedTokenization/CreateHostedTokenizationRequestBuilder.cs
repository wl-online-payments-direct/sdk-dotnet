using System.Collections.Generic;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.HostedTokenization;

public class CreateHostedTokenizationRequestBuilder
{
    private bool _askConsumerConsent = true;
    private string _locale = "en_US";
    private readonly List<string> _tokens = [];

    #region Setters

    public CreateHostedTokenizationRequestBuilder WithAskConsumerConsent(bool askConsumerConsent)
    {
        _askConsumerConsent = askConsumerConsent;
        return this;
    }

    public CreateHostedTokenizationRequestBuilder WithLocale(string locale)
    {
        _locale = locale;
        return this;
    }

    public CreateHostedTokenizationRequestBuilder WithToken(string token)
    {
        _tokens.Add(token);
        return this;
    }

    public CreateHostedTokenizationRequestBuilder WithTokens(params string[] tokens)
    {
        _tokens.Clear();
        _tokens.AddRange(tokens);
        return this;
    }

    #endregion

    public CreateHostedTokenizationRequest Build() => new()
    {
        AskConsumerConsent = _askConsumerConsent,
        Locale = _locale,
        Tokens = _tokens.Count == 0 ? null : string.Join(",", _tokens)
    };
}
