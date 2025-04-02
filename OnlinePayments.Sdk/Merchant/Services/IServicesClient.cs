/*
 * This file was automatically generated.
 */
using System.Threading.Tasks;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Merchant.Services
{
    /// <summary>
    /// Services client. Thread-safe.
    /// </summary>
    public interface IServicesClient
    {
        /// <summary>
        /// Resource /v2/{merchantId}/services/testconnection - Test connection
        /// </summary>
        /// <param name="context">CallContext</param>
        /// <returns>TestConnection</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<TestConnection> TestConnection(CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/getIINdetails - Get IIN details
        /// </summary>
        /// <param name="body">GetIINDetailsRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>GetIINDetailsResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<GetIINDetailsResponse> GetIINDetails(GetIINDetailsRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/dccrate - Get currency conversion quote
        /// </summary>
        /// <param name="body">CurrencyConversionRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CurrencyConversionResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<CurrencyConversionResponse> GetDccRateInquiry(CurrencyConversionRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/surchargecalculation - Surcharge Calculation
        /// </summary>
        /// <param name="body">CalculateSurchargeRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CalculateSurchargeResponse</returns>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code 409)</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code 400)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code 403)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code 404, 409 or 410)</exception>
        /// <exception cref="PlatformException">if something went wrong at the payment platform,
        ///            the payment platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code 500, 502 or 503)</exception>
        /// <exception cref="ApiException">if the payment platform returned any other error</exception>
        Task<CalculateSurchargeResponse> SurchargeCalculation(CalculateSurchargeRequest body, CallContext context = null);

    }
}
