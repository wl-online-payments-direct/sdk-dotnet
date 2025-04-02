/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.Mandates
{
    /// <summary>
    /// Mandates client. Thread-safe.
    /// </summary>
    public class MandatesClient : ApiResource, IMandatesClient
    {
        public MandatesClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <summary>
        /// Resource /v2/{merchantId}/mandates - Create mandate
        /// </summary>
        /// <param name="body">CreateMandateRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreateMandateResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<CreateMandateResponse> CreateMandate(CreateMandateRequest body, CallContext context = null)
        {
            var uri = InstantiateUri("/v2/{merchantId}/mandates", null);
            try
            {
                return await _communicator.Post<CreateMandateResponse>(
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
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference} - Get mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetMandateResponse> GetMandate(string uniqueMandateReference, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            var uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}", pathContext);
            try
            {
                return await _communicator.Get<GetMandateResponse>(
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

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/block - Block mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetMandateResponse> BlockMandate(string uniqueMandateReference, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            var uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/block", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        null,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/unblock - Unblock mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetMandateResponse> UnblockMandate(string uniqueMandateReference, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            var uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/unblock", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        null,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/revoke - Revoke mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetMandateResponse> RevokeMandate(string uniqueMandateReference, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            var uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/revoke", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
                        uri,
                        ClientHeaders,
                        null,
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
