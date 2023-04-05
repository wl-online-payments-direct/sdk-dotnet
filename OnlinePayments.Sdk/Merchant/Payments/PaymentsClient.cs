/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Payments
{
    /// <inheritdoc/>
    public class PaymentsClient : ApiResource, IPaymentsClient
    {
        public PaymentsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CreatePaymentResponse> CreatePayment(CreatePaymentRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/payments", null);
            try
            {
                return await _communicator.Post<CreatePaymentResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<PaymentErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<PaymentResponse> GetPayment(string paymentId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}", pathContext);
            try
            {
                return await _communicator.Get<PaymentResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<CompletePaymentResponse> CompletePayment(string paymentId, CompletePaymentRequest body, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/complete", pathContext);
            try
            {
                return await _communicator.Post<CompletePaymentResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<PaymentErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<CancelPaymentResponse> CancelPayment(string paymentId, CallContext context = null)
        {
            CancelPaymentRequest body = null;
            return await CancelPayment(paymentId, body, context);
        }

        /// <inheritdoc/>
        public async Task<CancelPaymentResponse> CancelPayment(string paymentId, CancelPaymentRequest body, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/cancel", pathContext);
            try
            {
                return await _communicator.Post<CancelPaymentResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<SubsequentPaymentResponse> SubsequentPayment(string paymentId, SubsequentPaymentRequest body, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/subsequent", pathContext);
            try
            {
                return await _communicator.Post<SubsequentPaymentResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<PaymentErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<RefundResponse> RefundPayment(string paymentId, RefundRequest body, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/refund", pathContext);
            try
            {
                return await _communicator.Post<RefundResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<RefundErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<CaptureResponse> CapturePayment(string paymentId, CapturePaymentRequest body, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/capture", pathContext);
            try
            {
                return await _communicator.Post<CaptureResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<CapturesResponse> GetCaptures(string paymentId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/captures", pathContext);
            try
            {
                return await _communicator.Get<CapturesResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<PaymentDetailsResponse> GetPaymentDetails(string paymentId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/details", pathContext);
            try
            {
                return await _communicator.Get<PaymentDetailsResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<RefundsResponse> GetRefunds(string paymentId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentId", paymentId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payments/{paymentId}/refunds", pathContext);
            try
            {
                return await _communicator.Get<RefundsResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<ErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }
    }
}
