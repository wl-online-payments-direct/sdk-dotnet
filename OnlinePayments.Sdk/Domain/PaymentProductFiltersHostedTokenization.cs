/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFiltersHostedTokenization
    {
        /// <summary>
        /// Contains the payment product ids that should be excluded from the payment products available for the payment. Note that excluding a payment product will ensure exclusion, even if the payment product is also present in the restrictTo filter.<para />
        /// </summary>
        public PaymentProductFilterHostedTokenization Exclude { get; set; } = null;

        /// <summary>
        /// Contains the payment product ids that should be excluded from the payment products available for the payment. Note that excluding a payment product will ensure exclusion, even if the payment product is also present in the restrictTo filter.<para />
        /// </summary>
        public PaymentProductFilterHostedTokenization RestrictTo { get; set; } = null;
    }
}
