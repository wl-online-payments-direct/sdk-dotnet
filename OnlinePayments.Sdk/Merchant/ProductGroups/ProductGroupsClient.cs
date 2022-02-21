/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.ProductGroups
{
    /// <inheritdoc/>
    public class ProductGroupsClient : ApiResource, IProductGroupsClient
    {
        public ProductGroupsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<GetPaymentProductGroupsResponse> GetProductGroups(GetProductGroupsParams query, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/productgroups", null);
            try
            {
                return await _communicator.Get<GetPaymentProductGroupsResponse>(
                        uri,
                        ClientHeaders,
                        query,
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
        public async Task<PaymentProductGroup> GetProductGroup(string paymentProductGroupId, GetProductGroupParams query, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentProductGroupId", paymentProductGroupId }
            };
            string uri = InstantiateUri("/v2/{merchantId}/productgroups/{paymentProductGroupId}", pathContext);
            try
            {
                return await _communicator.Get<PaymentProductGroup>(
                        uri,
                        ClientHeaders,
                        query,
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
