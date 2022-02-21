/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Payouts
{
    /// <summary>
    /// Payouts client. Thread-safe.
    /// </summary>
    public interface IPayoutsClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/payouts
        /// - Create payout
        /// </summary>
        /// <param name="body">CreatePayoutRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>PayoutResponse</returns>
        /// <exception cref="DeclinedPayoutException">if the payment platform declined / rejected the payout. The payout result will be available from the exception.</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<PayoutResponse> CreatePayout(CreatePayoutRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payouts/{payoutId}
        /// - Get payout
        /// </summary>
        /// <param name="payoutId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>PayoutResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="PaymentPlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<PayoutResponse> GetPayout(string payoutId, CallContext context = null);
    }
}
