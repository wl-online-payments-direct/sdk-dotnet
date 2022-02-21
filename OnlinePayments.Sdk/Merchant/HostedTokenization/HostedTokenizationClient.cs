/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.HostedTokenization
{
    /// <inheritdoc/>
    public class HostedTokenizationClient : ApiResource, IHostedTokenizationClient
    {
        public HostedTokenizationClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CreateHostedTokenizationResponse> CreateHostedTokenization(CreateHostedTokenizationRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/hostedtokenizations", null);
            try
            {
                return await _communicator.Post<CreateHostedTokenizationResponse>(
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
        public async Task<GetHostedTokenizationResponse> GetHostedTokenization(string hostedTokenizationId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "hostedTokenizationId", hostedTokenizationId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/hostedtokenizations/{hostedTokenizationId}", pathContext);
            try
            {
                return await _communicator.Get<GetHostedTokenizationResponse>(
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
