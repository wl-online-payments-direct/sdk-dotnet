/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk.Domain;
using System.Threading.Tasks;

namespace Ingenico.Direct.Sdk.Merchant.ProductGroups
{
    /// <summary>
    /// ProductGroups client. Thread-safe.
    /// </summary>
    public interface IProductGroupsClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetProductGroups">Get product groups</a>
        /// </summary>
        /// <param name="query">GetProductGroupsParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetPaymentProductGroupsResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<GetPaymentProductGroupsResponse> GetProductGroups(GetProductGroupsParams query, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups/{paymentProductGroupId}
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetProductGroup">Get product group</a>
        /// </summary>
        /// <param name="paymentProductGroupId">string</param>
        /// <param name="query">GetProductGroupParams</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentProductGroup</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<PaymentProductGroup> GetProductGroup(string paymentProductGroupId, GetProductGroupParams query, CallContext context = null);
    }
}
