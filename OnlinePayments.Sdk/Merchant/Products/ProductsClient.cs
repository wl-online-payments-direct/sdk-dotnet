/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <summary>
    /// Products client. Thread-safe.
    /// </summary>
    public class ProductsClient : ApiResource, IProductsClient
    {
        public ProductsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <summary>
        /// Resource /v2/{merchantId}/products - Get payment products
        /// </summary>
        /// <param name="query">GetPaymentProductsParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetPaymentProductsResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<GetPaymentProductsResponse> GetPaymentProducts(GetPaymentProductsParams query, CallContext context = null)
        {
            var uri = InstantiateUri("/v2/{merchantId}/products", null);
            try
            {
                return await _communicator.Get<GetPaymentProductsResponse>(
                        uri,
                        ClientHeaders,
                        query,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId} - Get payment product
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetPaymentProductParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentProduct</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<PaymentProduct> GetPaymentProduct(int? paymentProductId, GetPaymentProductParams query, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            var uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}", pathContext);
            try
            {
                return await _communicator.Get<PaymentProduct>(
                        uri,
                        ClientHeaders,
                        query,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId}/networks - Get payment product networks
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetPaymentProductNetworksParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentProductNetworksResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<PaymentProductNetworksResponse> GetPaymentProductNetworks(int? paymentProductId, GetPaymentProductNetworksParams query, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            var uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}/networks", pathContext);
            try
            {
                return await _communicator.Get<PaymentProductNetworksResponse>(
                        uri,
                        ClientHeaders,
                        query,
                        context).ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Marshaller.Unmarshal<ErrorResponse>(e.Body);
                throw ExceptionFactory.CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId}/directory - Get payment product directory
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetProductDirectoryParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>ProductDirectory</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        public async Task<ProductDirectory> GetProductDirectory(int? paymentProductId, GetProductDirectoryParams query, CallContext context = null)
        {
            var pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            var uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}/directory", pathContext);
            try
            {
                return await _communicator.Get<ProductDirectory>(
                        uri,
                        ClientHeaders,
                        query,
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
