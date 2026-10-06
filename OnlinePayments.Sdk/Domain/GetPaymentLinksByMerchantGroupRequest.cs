/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetPaymentLinksByMerchantGroupRequest
    {
        /// <summary>
        /// Object containing the filter criteria for retrieving payment links.
        /// </summary>
        public PaymentLinkOverviewFiltering Filtering { get; set; }

        /// <summary>
        /// Object containing pagination parameters.
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Object containing sorting parameters.
        /// </summary>
        public PaymentLinkOverviewSorting Sorting { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetPaymentLinksByMerchantGroupRequest WithFiltering(PaymentLinkOverviewFiltering value)
        {
            Filtering = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetPaymentLinksByMerchantGroupRequest WithPagination(Pagination value)
        {
            Pagination = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetPaymentLinksByMerchantGroupRequest WithSorting(PaymentLinkOverviewSorting value)
        {
            Sorting = value;
            return this;
        }
    }
}
