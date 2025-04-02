/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.Captures
{
    /// <summary>
    /// Captures client. Thread-safe.
    /// </summary>
    public class CapturesClient : ApiResource, ICapturesClient
    {
        public CapturesClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/captures - Get captures of payment
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>CapturesResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<CapturesResponse> GetCaptures(string paymentId, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            var uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/captures", pathContext);
            try
            {
                return await _communicator.Get<CapturesResponse>(
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
