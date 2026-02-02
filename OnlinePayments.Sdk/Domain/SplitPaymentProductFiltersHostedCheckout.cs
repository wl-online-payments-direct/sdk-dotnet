/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SplitPaymentProductFiltersHostedCheckout
    {
        /// <summary>
        /// The payment product IDs to be excluded or restricted for the payment products available for the following payments in a split payment. Note that you can add exclusions on top of the 'restrictTo' filter.
        /// </summary>
        public SplitPaymentProductFilter Exclude { get; set; }

        /// <summary>
        /// The payment product IDs to be excluded or restricted for the payment products available for the following payments in a split payment. Note that you can add exclusions on top of the 'restrictTo' filter.
        /// </summary>
        public SplitPaymentProductFilter RestrictTo { get; set; }
    }
}
