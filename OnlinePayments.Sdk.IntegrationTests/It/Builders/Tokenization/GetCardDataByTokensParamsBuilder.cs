using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.Tokenization;

namespace OnlinePayments.Sdk.It.Builders.Tokenization;

public class GetCardDataByTokensParamsBuilder
{
    private IList<string> _tokens = [];

    #region Setters

    public GetCardDataByTokensParamsBuilder WithTokens(IList<string> tokens)
    {
        _tokens = tokens;
        return this;
    }

    #endregion

    public GetCardDataByTokensParams Build() => new()
    {
        Tokens = _tokens
    };
}
