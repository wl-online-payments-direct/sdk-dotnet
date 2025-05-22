/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ProtectionEligibility
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>Eligible - Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payment and Item Not Received</description></item>
        ///   <item><description>PartiallyEligible - Merchant is protected by PayPal's Seller Protection Policy for Item Not Received</description></item>
        ///   <item><description>Ineligible — Merchant is not protected under the Seller Protection Policy</description></item>
        /// </list>
        /// </summary>
        public string Eligibility { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>ItemNotReceivedEligible - Merchant is protected by PayPal's Seller Protection Policy for Item Not Received</description></item>
        ///   <item><description>UnauthorizedPaymentEligible - Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payment</description></item>
        ///   <item><description>Ineligible - Merchant is not protected under the Seller Protection Policy</description></item>
        /// </list>
        /// </summary>
        public string Type { get; set; }
    }
}
