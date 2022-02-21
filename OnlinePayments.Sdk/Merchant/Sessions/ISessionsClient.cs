/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Sessions
{
    /// <summary>
    /// Sessions client. Thread-safe.
    /// </summary>
    public interface ISessionsClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// - Create session
        /// </summary>
        /// <param name="body">SessionRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>SessionResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<SessionResponse> CreateSession(SessionRequest body, CallContext context = null);
    }
}
