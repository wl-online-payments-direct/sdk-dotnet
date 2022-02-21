/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.HostedTokenization
{
    /// <summary>
    /// HostedTokenization client. Thread-safe.
    /// </summary>
    public interface IHostedTokenizationClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations
        /// - Create hosted tokenization session
        /// </summary>
        /// <param name="body">CreateHostedTokenizationRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreateHostedTokenizationResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<CreateHostedTokenizationResponse> CreateHostedTokenization(CreateHostedTokenizationRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations/{hostedTokenizationId}
        /// - Get hosted tokenization session
        /// </summary>
        /// <param name="hostedTokenizationId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetHostedTokenizationResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetHostedTokenizationResponse> GetHostedTokenization(string hostedTokenizationId, CallContext context = null);
    }
}
