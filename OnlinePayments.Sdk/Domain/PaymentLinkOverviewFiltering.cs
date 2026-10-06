/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOverviewFiltering
    {
        /// <summary>
        /// List of unique merchant IDs to filter the payment links by.
        /// </summary>
        public IList<string> MerchantIds { get; set; }

        /// <summary>
        /// Filter payment links by their current status. You can provide one or more status values to retrieve only the links matching those statuses. When multiple statuses are provided, the response will include payment links matching ANY of the specified values (OR logic). If this parameter is omitted, payment links with all statuses will be returned. Possible values are:
        /// <list type="bullet">
        ///   <item><description>ACTIVE - Payment link is ready to be used</description></item>
        ///   <item><description>CANCELLED - Payment link has been manually cancelled</description></item>
        ///   <item><description>PAID - Payment has been successfully completed</description></item>
        ///   <item><description>EXPIRED - Payment link has passed its expiration date</description></item>
        /// </list>
        /// </summary>
        public IList<string> Status { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewFiltering WithMerchantIds(IList<string> value)
        {
            MerchantIds = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewFiltering WithStatus(IList<string> value)
        {
            Status = value;
            return this;
        }
    }
}
