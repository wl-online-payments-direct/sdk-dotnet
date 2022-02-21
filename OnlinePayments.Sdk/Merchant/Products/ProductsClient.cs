/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Merchant.Products
{
    /// <inheritdoc/>
    public class ProductsClient : ApiResource, IProductsClient
    {
        public ProductsClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
        public async Task<GetPaymentProductsResponse> GetPaymentProducts(GetPaymentProductsParams query, CallContext context = null)
        {
            string uri = InstantiateUri("/v2/{merchantId}/products", null);
            try
            {
                return await _communicator.Get<GetPaymentProductsResponse>(
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
        public async Task<PaymentProduct> GetPaymentProduct(int? paymentProductId, GetPaymentProductParams query, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            string uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}", pathContext);
            try
            {
                return await _communicator.Get<PaymentProduct>(
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
        public async Task<ProductDirectory> GetProductDirectory(int? paymentProductId, GetProductDirectoryParams query, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            string uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}/directory", pathContext);
            try
            {
                return await _communicator.Get<ProductDirectory>(
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
        public async Task<PaymentProductNetworksResponse> GetPaymentProductNetworks(int? paymentProductId, GetPaymentProductNetworksParams query, CallContext context = null)
        {
            IDictionary<string, string> pathContext = new Dictionary<string, string>
            {
                { "paymentProductId", paymentProductId.ToString() }
            };
            string uri = InstantiateUri("/v2/{merchantId}/products/{paymentProductId}/networks", pathContext);
            try
            {
                return await _communicator.Get<PaymentProductNetworksResponse>(
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
