/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFiltersHostedCheckout
    {
        /// <summary>
        /// Contains the payment product ids and payment product groups that should be excluded from the payment products available for the payment. Note that excluding a payment product will ensure exclusion, even if the payment product is also present in the restrictTo filter, and that excluding a payment product group will exclude all payment products that are a part of that group, even if one or more of them are present in the restrictTo filters.<para />
        /// </summary>
        public PaymentProductFilter Exclude { get; set; } = null;

        /// <summary>
        /// Contains the payment product ids and payment product groups that should be excluded from the payment products available for the payment. Note that excluding a payment product will ensure exclusion, even if the payment product is also present in the restrictTo filter, and that excluding a payment product group will exclude all payment products that are a part of that group, even if one or more of them are present in the restrictTo filters.<para />
        /// </summary>
        public PaymentProductFilter RestrictTo { get; set; } = null;
    }
}
