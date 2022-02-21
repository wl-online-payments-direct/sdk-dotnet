/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.HostedCheckout
{
    /// <inheritdoc/>
    public class HostedCheckoutClient : ApiResource, IHostedCheckoutClient
    {
        public HostedCheckoutClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CreateHostedCheckoutResponse> CreateHostedCheckout(CreateHostedCheckoutRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/hostedcheckouts", null);
            try
            {
                return await _communicator.Post<CreateHostedCheckoutResponse>(
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
        public async Task<GetHostedCheckoutResponse> GetHostedCheckout(string hostedCheckoutId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "hostedCheckoutId", hostedCheckoutId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/hostedcheckouts/{hostedCheckoutId}", pathContext);
            try
            {
                return await _communicator.Get<GetHostedCheckoutResponse>(
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
