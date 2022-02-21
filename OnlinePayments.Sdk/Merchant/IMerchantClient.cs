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
        /// <returns>HostedCheckoutClient</returns>
		IHostedCheckoutClient HostedCheckout { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations
        /// </summary>
        /// <returns>HostedTokenizationClient</returns>
		IHostedTokenizationClient HostedTokenization { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/mandates
        /// </summary>
        /// <returns>MandatesClient</returns>
		IMandatesClient Mandates { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// </summary>
        /// <returns>PaymentsClient</returns>
		IPaymentsClient Payments { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payouts
        /// </summary>
        /// <returns>PayoutsClient</returns>
		IPayoutsClient Payouts { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// </summary>
        /// <returns>ProductGroupsClient</returns>
		IProductGroupsClient ProductGroups { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// </summary>
        /// <returns>ProductsClient</returns>
		IProductsClient Products { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/services
        /// </summary>
        /// <returns>ServicesClient</returns>
		IServicesClient Services { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// </summary>
        /// <returns>SessionsClient</returns>
		ISessionsClient Sessions { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/tokens
        /// </summary>
        /// <returns>TokensClient</returns>
		ITokensClient Tokens { get; }
    }
}
