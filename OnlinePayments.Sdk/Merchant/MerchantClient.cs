/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using OnlinePayments.Sdk.Merchant.Captures;
using OnlinePayments.Sdk.Merchant.Complete;
using OnlinePayments.Sdk.Merchant.HostedCheckout;
using OnlinePayments.Sdk.Merchant.HostedTokenization;
using OnlinePayments.Sdk.Merchant.Mandates;
using OnlinePayments.Sdk.Merchant.PaymentLinks;
using OnlinePayments.Sdk.Merchant.Payments;
using OnlinePayments.Sdk.Merchant.Payouts;
using OnlinePayments.Sdk.Merchant.PrivacyPolicy;
using OnlinePayments.Sdk.Merchant.ProductGroups;
using OnlinePayments.Sdk.Merchant.Products;
using OnlinePayments.Sdk.Merchant.Refunds;
using OnlinePayments.Sdk.Merchant.Services;
using OnlinePayments.Sdk.Merchant.Sessions;
using OnlinePayments.Sdk.Merchant.Subsequent;
using OnlinePayments.Sdk.Merchant.Tokens;
using OnlinePayments.Sdk.Merchant.Webhooks;

namespace OnlinePayments.Sdk.Merchant
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
        /// Resource /v2/{merchantId}/hostedcheckouts
        /// </summary>
        /// <returns>IHostedCheckoutClient</returns>
        public IHostedCheckoutClient HostedCheckout => new HostedCheckoutClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations
        /// </summary>
        /// <returns>IHostedTokenizationClient</returns>
        public IHostedTokenizationClient HostedTokenization => new HostedTokenizationClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// </summary>
        /// <returns>IPaymentsClient</returns>
        public IPaymentsClient Payments => new PaymentsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/captures
        /// </summary>
        /// <returns>ICapturesClient</returns>
        public ICapturesClient Captures => new CapturesClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/refunds
        /// </summary>
        /// <returns>IRefundsClient</returns>
        public IRefundsClient Refunds => new RefundsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/complete
        /// </summary>
        /// <returns>ICompleteClient</returns>
        public ICompleteClient Complete => new CompleteClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/subsequent
        /// </summary>
        /// <returns>ISubsequentClient</returns>
        public ISubsequentClient Subsequent => new SubsequentClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// </summary>
        /// <returns>IProductGroupsClient</returns>
        public IProductGroupsClient ProductGroups => new ProductGroupsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// </summary>
        /// <returns>IProductsClient</returns>
        public IProductsClient Products => new ProductsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/testconnection
        /// </summary>
        /// <returns>IServicesClient</returns>
        public IServicesClient Services => new ServicesClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/webhooks/validateCredentials
        /// </summary>
        /// <returns>IWebhooksClient</returns>
        public IWebhooksClient Webhooks => new WebhooksClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// </summary>
        /// <returns>ISessionsClient</returns>
        public ISessionsClient Sessions => new SessionsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/tokens/{tokenId}
        /// </summary>
        /// <returns>ITokensClient</returns>
        public ITokensClient Tokens => new TokensClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/payouts/{payoutId}
        /// </summary>
        /// <returns>IPayoutsClient</returns>
        public IPayoutsClient Payouts => new PayoutsClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/mandates
        /// </summary>
        /// <returns>IMandatesClient</returns>
        public IMandatesClient Mandates => new MandatesClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/services/privacypolicy
        /// </summary>
        /// <returns>IPrivacyPolicyClient</returns>
        public IPrivacyPolicyClient PrivacyPolicy => new PrivacyPolicyClient(this, null);

        /// <summary>
        /// Resource /v2/{merchantId}/paymentlinks
        /// </summary>
        /// <returns>IPaymentLinksClient</returns>
        public IPaymentLinksClient PaymentLinks => new PaymentLinksClient(this, null);
    }
}
