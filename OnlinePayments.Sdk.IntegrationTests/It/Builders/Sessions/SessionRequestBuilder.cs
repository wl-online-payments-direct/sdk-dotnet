using System.Collections.Generic;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Sessions;

public class SessionRequestBuilder
{
    private IList<string> _tokens = [];

    #region Setters

    public SessionRequestBuilder WithToken(string token)
    {
        _tokens.Add(token);
        return this;
    }

    public SessionRequestBuilder WithTokens(params string[] tokens)
    {
        _tokens = new List<string>(tokens);
        return this;
    }

    public SessionRequestBuilder WithTokens(IList<string> tokens)
    {
        _tokens = tokens;
        return this;
    }

    #endregion

    public SessionRequest Build() => new()
    {
        Tokens = _tokens
    };
}
