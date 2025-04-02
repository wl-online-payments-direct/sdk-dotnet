/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.HostedTokenization
{
    /// <summary>
    /// HostedTokenization client. Thread-safe.
    /// </summary>
    public class HostedTokenizationClient : ApiResource, IHostedTokenizationClient
    {
        public HostedTokenizationClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations - Create hosted tokenization session
        /// </summary>
        /// <param name="body">CreateHostedTokenizationRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreateHostedTokenizationResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<CreateHostedTokenizationResponse> CreateHostedTokenization(CreateHostedTokenizationRequest body, CallContext context = null)
        {
            var uri = InstantiateUri("/v2/{merchantId}/hostedtokenizations", null);
            try
            {
                return await _communicator.Post<CreateHostedTokenizationResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations/{hostedTokenizationId} - Get hosted tokenization session
        /// </summary>
        /// <param name="hostedTokenizationId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetHostedTokenizationResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetHostedTokenizationResponse> GetHostedTokenization(string hostedTokenizationId, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "hostedTokenizationId", hostedTokenizationId }
            };
            var uri = InstantiateUri("/v2/{merchantId}/hostedtokenizations/{hostedTokenizationId}", pathContext);
            try
            {
                return await _communicator.Get<GetHostedTokenizationResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }
    }
}
