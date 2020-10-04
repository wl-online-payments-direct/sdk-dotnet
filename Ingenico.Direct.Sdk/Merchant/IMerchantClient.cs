/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Ingenico.Direct.Sdk.Merchant.HostedCheckout;
using Ingenico.Direct.Sdk.Merchant.HostedTokenization;
using Ingenico.Direct.Sdk.Merchant.Payments;
using Ingenico.Direct.Sdk.Merchant.Payouts;
using Ingenico.Direct.Sdk.Merchant.ProductGroups;
using Ingenico.Direct.Sdk.Merchant.Products;
using Ingenico.Direct.Sdk.Merchant.Services;
using Ingenico.Direct.Sdk.Merchant.Sessions;
using Ingenico.Direct.Sdk.Merchant.Tokens;

namespace Ingenico.Direct.Sdk.Merchant
{
    /// <summary>
    /// Merchant client. Thread-safe.
    /// </summary>
    public interface IMerchantClient
    {

        /// <summary>
        /// Resource /v2/{merchantId}/products
        /// </summary>
        /// <returns>ProductsClient</returns>
		IProductsClient Products { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/sessions
        /// </summary>
        /// <returns>SessionsClient</returns>
		ISessionsClient Sessions { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payouts
        /// </summary>
        /// <returns>PayoutsClient</returns>
		IPayoutsClient Payouts { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/payments
        /// </summary>
        /// <returns>PaymentsClient</returns>
		IPaymentsClient Payments { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/services/testconnection
        /// </summary>
        /// <returns>ServicesClient</returns>
		IServicesClient Services { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/productgroups
        /// </summary>
        /// <returns>ProductGroupsClient</returns>
		IProductGroupsClient ProductGroups { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedtokenizations
        /// </summary>
        /// <returns>HostedTokenizationClient</returns>
		IHostedTokenizationClient HostedTokenization { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/tokens
        /// </summary>
        /// <returns>TokensClient</returns>
		ITokensClient Tokens { get; }

        /// <summary>
        /// Resource /v2/{merchantId}/hostedcheckouts
        /// </summary>
        /// <returns>HostedCheckoutClient</returns>
		IHostedCheckoutClient HostedCheckout { get; }
    }
}
