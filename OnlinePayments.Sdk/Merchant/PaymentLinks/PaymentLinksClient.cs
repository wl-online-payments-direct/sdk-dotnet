/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.PaymentLinks
{
    /// <inheritdoc/>
    public class PaymentLinksClient : ApiResource, IPaymentLinksClient
    {
        public PaymentLinksClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<PaymentLinkResponse> CreatePaymentLink(CreatePaymentLinkRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/paymentlinks", null);
            try
            {
                return await _communicator.Post<PaymentLinkResponse>(
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
        public async Task<PaymentLinkResponse> GetPaymentLinkById(string paymentLinkId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentLinkId", paymentLinkId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/paymentlinks/{paymentLinkId}", pathContext);
            try
            {
                return await _communicator.Get<PaymentLinkResponse>(
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
        public async Task CancelPaymentLinkById(string paymentLinkId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentLinkId", paymentLinkId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/paymentlinks/{paymentLinkId}/cancel", pathContext);
            try
            {
                await _communicator.Post<object>(
                        uri,
                        ClientHeaders,
                        null,
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
