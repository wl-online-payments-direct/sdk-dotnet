/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Communication;

namespace OnlinePayments.Sdk.Merchant.Tokenization
{
    /// <summary>
    /// Query parameters for
    /// Get sensitive card details by card alias tokens (/v2/{merchantId}/detokenize/tokens)
    /// </summary>
    public class GetCardDataByTokensParams : AbstractParamRequest
    {
        /// <summary>
        /// This object contains the details for detokenizing a payment token.
        /// </summary>
        public IList<string> Tokens { get; set; }

        public void AddTokens(string value)
        {
            var tokens = Tokens;
            if (tokens == null)
            {
                tokens = new List<string>();
                Tokens = tokens;
            }
            tokens.Add(value);
        }

        public override IEnumerable<RequestParam> ToRequestParameters()
        {
            var result = new List<RequestParam>();
            if (Tokens != null)
            {
                foreach (var tokensElement in Tokens)
                {
                    if (tokensElement != null)
                    {
                        result.Add(new RequestParam("tokens", tokensElement));
                    }
                }
            }
            return result;
        }
    }
}
