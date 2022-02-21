/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Mandates
{
    /// <inheritdoc/>
    public class MandatesClient : ApiResource, IMandatesClient
    {
        public MandatesClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<CreateMandateResponse> CreateMandate(CreateMandateRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/mandates", null);
            try
            {
                return await _communicator.Post<CreateMandateResponse>(
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
        public async Task<GetMandateResponse> GetMandate(string uniqueMandateReference, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            string uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}", pathContext);
            try
            {
                return await _communicator.Get<GetMandateResponse>(
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
        public async Task<GetMandateResponse> BlockMandate(string uniqueMandateReference, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            string uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/block", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
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

        /// <inheritdoc/>
        public async Task<GetMandateResponse> UnblockMandate(string uniqueMandateReference, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            string uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/unblock", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
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

        /// <inheritdoc/>
        public async Task<GetMandateResponse> RevokeMandate(string uniqueMandateReference, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "uniqueMandateReference", uniqueMandateReference }
            };
            string uri = InstantiateUri("/v2/{merchantId}/mandates/{uniqueMandateReference}/revoke", pathContext);
            try
            {
                return await _communicator.Post<GetMandateResponse>(
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
