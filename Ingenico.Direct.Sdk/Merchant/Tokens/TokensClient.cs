/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Ingenico.Direct.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingenico.Direct.Sdk.Merchant.Tokens
{
    /// <inheritdoc/>
    public class TokensClient : ApiResource, ITokensClient
    {
        public TokensClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CreatedTokenResponse> CreateToken(CreateTokenRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/tokens", null);
            try
            {
                return await _communicator.Post<CreatedTokenResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<TokenResponse> GetToken(string tokenId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "tokenId", tokenId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/tokens/{tokenId}", pathContext);
            try
            {
                return await _communicator.Get<TokenResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<TokenResponse> DeleteToken(string tokenId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "tokenId", tokenId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/tokens/{tokenId}", pathContext);
            try
            {
                return await _communicator.Delete<TokenResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }
    }
}
