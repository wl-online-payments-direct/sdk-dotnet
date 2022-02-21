/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Payouts
{
    /// <inheritdoc/>
    public class PayoutsClient : ApiResource, IPayoutsClient
    {
        public PayoutsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<PayoutResponse> CreatePayout(CreatePayoutRequest body, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/payouts", null);
            try
            {
                return await _communicator.Post<PayoutResponse>(
                        uri,
                        ClientHeaders,
                        null,
                        body,
                        context)
                    .ConfigureAwait(false);
            }
            catch (ResponseException e)
            {
                object errorObject = _communicator.Unmarshal<PayoutErrorResponse>(e.Body);
                throw CreateException(e.StatusCode, e.Body, errorObject, context);
            }
        }

        /// <inheritdoc/>
        public async Task<PayoutResponse> GetPayout(string payoutId, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "payoutId", payoutId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/payouts/{payoutId}", pathContext);
            try
            {
                return await _communicator.Get<PayoutResponse>(
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
