/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk.Domain;
using System.Threading.Tasks;

namespace Ingenico.Direct.Sdk.Merchant.Products
{
    /// <summary>
    /// Products client. Thread-safe.
    /// </summary>
    public interface IProductsClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetPaymentProducts">Get payment products</a>
        /// </summary>
        /// <param name="query">GetPaymentProductsParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetPaymentProductsResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<GetPaymentProductsResponse> GetPaymentProducts(GetPaymentProductsParams query, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId}
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetPaymentProduct">Get payment product</a>
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetPaymentProductParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentProduct</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<PaymentProduct> GetPaymentProduct(int? paymentProductId, GetPaymentProductParams query, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId}/directory
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetProductDirectoryApi">Get payment product directory</a>
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetProductDirectoryParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>ProductDirectory</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<ProductDirectory> GetProductDirectory(int? paymentProductId, GetProductDirectoryParams query, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/products/{paymentProductId}/networks
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetPaymentProductNetworks">Get payment product networks</a>
        /// </summary>
        /// <param name="paymentProductId">int?</param>
        /// <param name="query">GetPaymentProductNetworksParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentProductNetworksResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<PaymentProductNetworksResponse> GetPaymentProductNetworks(int? paymentProductId, GetPaymentProductNetworksParams query, CallContext context = null);
    }
}
