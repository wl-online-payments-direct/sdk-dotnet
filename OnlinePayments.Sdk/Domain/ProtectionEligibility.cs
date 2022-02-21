/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ProtectionEligibility
    {
        /// <summary>
        /// * Eligible - Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payment and Item Not Received<para />
        /// * PartiallyEligible - Merchant is protected by PayPal's Seller Protection Policy for Item Not Received<para />
        /// * Ineligible — Merchant is not protected under the Seller Protection Policy<para />
        /// </summary>
        public string Eligibility { get; set; } = null;

        /// <summary>
        /// - ItemNotReceivedEligible - Merchant is protected by PayPal's Seller Protection Policy for Item Not Received<para />
        /// - UnauthorizedPaymentEligible - Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payment<para />
        /// - Ineligible - Merchant is not protected under the Seller Protection Policy<para />
        /// </summary>
        public string Type { get; set; } = null;
    }
}
