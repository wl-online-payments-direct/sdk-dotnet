/*
 * This file was automatically generated.
 */
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.HostedCheckout
{
    /// <summary>
    /// HostedCheckout client. Thread-safe.
    /// </summary>
    public interface IHostedCheckoutClient
    {
        /// <summary>
        /// Resource /v2/{merchantId}/hostedcheckouts - Create hosted checkout
        /// </summary>
        /// <param name="body">CreateHostedCheckoutRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreateHostedCheckoutResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<CreateHostedCheckoutResponse> CreateHostedCheckout(CreateHostedCheckoutRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/hostedcheckouts/{hostedCheckoutId} - Get hosted checkout status
        /// </summary>
        /// <param name="hostedCheckoutId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetHostedCheckoutResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetHostedCheckoutResponse> GetHostedCheckout(string hostedCheckoutId, CallContext context = null);

    }
}
