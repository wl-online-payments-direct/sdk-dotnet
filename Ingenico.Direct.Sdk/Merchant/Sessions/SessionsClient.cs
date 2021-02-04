/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingenico.Direct.Sdk.Merchant.Sessions
{
    /// <inheritdoc/>
    public class SessionsClient : ApiResource, ISessionsClient
    {
        public SessionsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<SessionResponse> CreateSession(SessionRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/sessions", null);
            try
            {
                return await _communicator.Post<SessionResponse>(
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
    }
}
