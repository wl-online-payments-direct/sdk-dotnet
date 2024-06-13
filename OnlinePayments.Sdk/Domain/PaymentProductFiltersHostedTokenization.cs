/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFiltersHostedTokenization
    {
        /// <summary>
        /// The payment product ids to be be excluded or restricted to from the payment products available for the payment. Note that you can add exclusions on top of the 'restrictTo' filter.<para />
        /// </summary>
        public PaymentProductFilterHostedTokenization Exclude { get; set; } = null;

        /// <summary>
        /// The payment product ids to be be excluded or restricted to from the payment products available for the payment. Note that you can add exclusions on top of the 'restrictTo' filter.<para />
        /// </summary>
        public PaymentProductFilterHostedTokenization RestrictTo { get; set; } = null;
    }
}
