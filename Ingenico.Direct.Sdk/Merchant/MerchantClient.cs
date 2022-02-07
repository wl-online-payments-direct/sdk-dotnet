/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Ingenico.Direct.Sdk.Merchant.HostedCheckout;
using Ingenico.Direct.Sdk.Merchant.HostedTokenization;
using Ingenico.Direct.Sdk.Merchant.Mandates;
using Ingenico.Direct.Sdk.Merchant.Payments;
using Ingenico.Direct.Sdk.Merchant.Payouts;
using Ingenico.Direct.Sdk.Merchant.ProductGroups;
using Ingenico.Direct.Sdk.Merchant.Products;
using Ingenico.Direct.Sdk.Merchant.Services;
using Ingenico.Direct.Sdk.Merchant.Sessions;
using Ingenico.Direct.Sdk.Merchant.Tokens;
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Merchant
{
    /// <inheritdoc/>
    public class MerchantClient : ApiResource, IMerchantClient
    {
        public MerchantClient(ApiResource parent, IDictionary<string, string> pathContext) :
            base(parent, pathContext)
        {
        }

        /// <inheritdoc/>
		public IHostedCheckoutClient HostedCheckout => new HostedCheckoutClient(this, null);

        /// <inheritdoc/>
		public IHostedTokenizationClient HostedTokenization => new HostedTokenizationClient(this, null);

        /// <inheritdoc/>
		public IMandatesClient Mandates => new MandatesClient(this, null);

        /// <inheritdoc/>
		public IPaymentsClient Payments => new PaymentsClient(this, null);

        /// <inheritdoc/>
		public IPayoutsClient Payouts => new PayoutsClient(this, null);

        /// <inheritdoc/>
		public IProductGroupsClient ProductGroups => new ProductGroupsClient(this, null);

        /// <inheritdoc/>
		public IProductsClient Products => new ProductsClient(this, null);

        /// <inheritdoc/>
		public IServicesClient Services => new ServicesClient(this, null);

        /// <inheritdoc/>
		public ISessionsClient Sessions => new SessionsClient(this, null);

        /// <inheritdoc/>
		public ITokensClient Tokens => new TokensClient(this, null);
    }
}
