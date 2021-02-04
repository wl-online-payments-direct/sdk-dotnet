/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk.Domain;
using System.Threading.Tasks;

namespace Ingenico.Direct.Sdk.Merchant.Payments
{
    /// <summary>
    /// Payments client. Thread-safe.
    /// </summary>
    public interface IPaymentsClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/CreatePaymentApi">Create payment</a>
        /// </summary>
        /// <param name="body">CreatePaymentRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CreatePaymentResponse</returns>
        /// <exception cref="DeclinedPaymentException">if the Ingenico ePayments platform declined / rejected the payment. The payment result will be available from the exception.</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetPaymentApi">Get payment</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>PaymentResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<PaymentResponse> GetPayment(string paymentId, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/complete
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/CompletePaymentApi">Complete payment</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="body">CompletePaymentRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CompletePaymentResponse</returns>
        /// <exception cref="DeclinedPaymentException">if the Ingenico ePayments platform declined / rejected the payment. The payment result will be available from the exception.</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<CompletePaymentResponse> CompletePayment(string paymentId, CompletePaymentRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/cancel
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/CancelPaymentApi">Cancel payment</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>CancelPaymentResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<CancelPaymentResponse> CancelPayment(string paymentId, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/refund
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/RefundPaymentApi">Refund payment</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="body">RefundRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>RefundResponse</returns>
        /// <exception cref="DeclinedRefundException">if the Ingenico ePayments platform declined / rejected the refund. The refund result will be available from the exception.</exception>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<RefundResponse> RefundPayment(string paymentId, RefundRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/capture
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/CapturePaymentApi">Capture payment</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="body">CapturePaymentRequest</param>
        /// <param name="context">CallContext</param>
        /// <returns>CaptureResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<CaptureResponse> CapturePayment(string paymentId, CapturePaymentRequest body, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/captures
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetCapturesApi">Get Captures Api</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>CapturesResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<CapturesResponse> GetCaptures(string paymentId, CallContext context = null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/refunds
        /// - <a href="https://support.direct.ingenico.com/documentation/api/reference#operation/GetRefundsApi">Get Refunds Api</a>
        /// </summary>
        /// <param name="paymentId">string</param>
        /// <param name="context">CallContext</param>
        /// <returns>RefundsResponse</returns>
        /// <exception cref="ValidationException">if the request was not correct and couldn't be processed (HTTP status code BadRequest)</exception>
        /// <exception cref="AuthorizationException">if the request was not allowed (HTTP status code Forbidden)</exception>
        /// <exception cref="IdempotenceException">if an idempotent request caused a conflict (HTTP status code Conflict)</exception>
        /// <exception cref="ReferenceException">if an object was attempted to be referenced that doesn't exist or has been removed,
        ///            or there was a conflict (HTTP status code NotFound, Conflict or Gone)</exception>
        /// <exception cref="DirectException">if something went wrong at the Ingenico ePayments platform,
        ///            the Ingenico ePayments platform was unable to process a message from a downstream partner/acquirer,
        ///            or the service that you're trying to reach is temporary unavailable (HTTP status code InternalServerError, BadGateway or ServiceUnavailable)</exception>
        /// <exception cref="ApiException">if the Ingenico ePayments platform returned any other error</exception>
        Task<RefundsResponse> GetRefunds(string paymentId, CallContext context = null);
    }
}
