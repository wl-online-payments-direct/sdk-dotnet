/*
 * This class was auto-generated.
 */
using OnlinePayments.Sdk.Merchant.HostedCheckout;
using OnlinePayments.Sdk.Merchant.HostedTokenization;
using OnlinePayments.Sdk.Merchant.Mandates;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.Payouts;
using OnlinePayments.Sdk.Merchant.ProductGroups;
using OnlinePayments.Sdk.Merchant.Products;
using OnlinePayments.Sdk.Merchant.Services;
using OnlinePayments.Sdk.Merchant.Sessions;
using OnlinePayments.Sdk.Merchant.Tokens;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Merchant
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
