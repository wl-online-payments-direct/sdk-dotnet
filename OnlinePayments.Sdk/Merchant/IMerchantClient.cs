/*
 * This file was automatically generated.
 */
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
    public interface IMerchantClient
    {
        /// <summary>
        /// Resource /v2/{merchantId}/hostedcheckouts
        /// </summary>
        /// <returns>IHostedCheckoutClient</returns>
        IHostedCheckoutClient HostedCheckout { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations
        /// </summary>
        /// <returns>IHostedTokenizationClient</returns>
        IHostedTokenizationClient HostedTokenization { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// </summary>
        /// <returns>IPaymentsClient</returns>
        IPaymentsClient Payments { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/captures
        /// </summary>
        /// <returns>ICapturesClient</returns>
        ICapturesClient Captures { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/refunds
        /// </summary>
        /// <returns>IRefundsClient</returns>
        IRefundsClient Refunds { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/complete
        /// </summary>
        /// <returns>ICompleteClient</returns>
        ICompleteClient Complete { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments/{paymentId}/subsequent
        /// </summary>
        /// <returns>ISubsequentClient</returns>
        ISubsequentClient Subsequent { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// </summary>
        /// <returns>IProductGroupsClient</returns>
        IProductGroupsClient ProductGroups { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// </summary>
        /// <returns>IProductsClient</returns>
        IProductsClient Products { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/services/testconnection
        /// </summary>
        /// <returns>IServicesClient</returns>
        IServicesClient Services { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/webhooks/validateCredentials
        /// </summary>
        /// <returns>IWebhooksClient</returns>
        IWebhooksClient Webhooks { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// </summary>
        /// <returns>ISessionsClient</returns>
        ISessionsClient Sessions { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/tokens
        /// </summary>
        /// <returns>ITokensClient</returns>
        ITokensClient Tokens { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payouts
        /// </summary>
        /// <returns>IPayoutsClient</returns>
        IPayoutsClient Payouts { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/mandates
        /// </summary>
        /// <returns>IMandatesClient</returns>
        IMandatesClient Mandates { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/services/privacypolicy
        /// </summary>
        /// <returns>IPrivacyPolicyClient</returns>
        IPrivacyPolicyClient PrivacyPolicy { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/paymentlinks
        /// </summary>
        /// <returns>IPaymentLinksClient</returns>
        IPaymentLinksClient PaymentLinks { get; }

    }
}
