/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Mandates
{
    /// <summary>
    /// Mandates client. Thread-safe.
    /// </summary>
    public interface IMandatesClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/mandates
        /// - Create mandate
        /// </summary>
        /// <param name="body">CreateMandateRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreateMandateResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<CreateMandateResponse> CreateMandate(CreateMandateRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}
        /// - Get mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetMandateResponse> GetMandate(string uniqueMandateReference, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/block
        /// - Block mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetMandateResponse> BlockMandate(string uniqueMandateReference, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/unblock
        /// - Unblock mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetMandateResponse> UnblockMandate(string uniqueMandateReference, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/mandates/{uniqueMandateReference}/revoke
        /// - Revoke mandate
        /// </summary>
        /// <param name="uniqueMandateReference">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetMandateResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetMandateResponse> RevokeMandate(string uniqueMandateReference, CallContext context = null);
    }
}
