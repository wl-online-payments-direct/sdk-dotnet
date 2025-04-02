/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFiltersHostedCheckout
    {
        /// <summary>
        /// The payment product ids to be be excluded or restricted to from the payment products available for the payment. Note that you can add exclusions on top of the 'restrictTo' filter.
        /// </summary>
        public PaymentProductFilter Exclude { get; set; }

        /// <summary>
        /// The payment product ids to be be excluded or restricted to from the payment products available for the payment. Note that you can add exclusions on top of the 'restrictTo' filter.
        /// </summary>
        public PaymentProductFilter RestrictTo { get; set; }
    }
}
