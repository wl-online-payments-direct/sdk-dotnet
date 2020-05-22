/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Ingenico.Direct.Sdk.Merchant.HostedCheckout;
using Ingenico.Direct.Sdk.Merchant.Payments;
using Ingenico.Direct.Sdk.Merchant.ProductGroups;
using Ingenico.Direct.Sdk.Merchant.Products;
using Ingenico.Direct.Sdk.Merchant.Services;
using Ingenico.Direct.Sdk.Merchant.Sessions;
using Ingenico.Direct.Sdk.Merchant.Tokens;
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Merchant
{
    /// <summary>
    /// Merchant client. Thread-safe.
    /// </summary>
    public class MerchantClient : ApiResource, IMerchantClient
    {
        public MerchantClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// </summary>
        /// <returns>ProductsClient</returns>
		public IProductsClient Products => new ProductsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/tokens/{tokenId}
        /// </summary>
        /// <param name="tokenId">string</param>
        /// <returns>TokensClient</returns>
        public ITokensClient WithNewTokens(string tokenId)
        {
            IDictionary<string, string> subContext = new Dictionary<string, string>
			{
				{ "tokenId", tokenId }
			};
            return new TokensClient(this, subContext);
		}

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// </summary>
        /// <returns>SessionsClient</returns>
		public ISessionsClient Sessions => new SessionsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// </summary>
        /// <returns>PaymentsClient</returns>
		public IPaymentsClient Payments => new PaymentsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/testconnection
        /// </summary>
        /// <returns>ServicesClient</returns>
		public IServicesClient Services => new ServicesClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// </summary>
        /// <returns>ProductGroupsClient</returns>
		public IProductGroupsClient ProductGroups => new ProductGroupsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/hostedcheckouts
        /// </summary>
        /// <returns>HostedCheckoutClient</returns>
		public IHostedCheckoutClient HostedCheckout => new HostedCheckoutClient(this, null);
    }
}
