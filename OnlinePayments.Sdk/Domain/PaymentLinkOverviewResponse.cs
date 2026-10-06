/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOverviewResponse
    {
        /// <summary>
        /// Object containing pagination parameters.
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Array of payment link overview entries matching the specified filters.
        /// </summary>
        public IList<PaymentLinkOverviewEntry> PaymentLinkOverviewEntries { get; set; }

        /// <summary>
        /// Total number of payment links matching the request filters across all pages.
        /// </summary>
        public long? Total { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewResponse WithPagination(Pagination value)
        {
            Pagination = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewResponse WithPaymentLinkOverviewEntries(IList<PaymentLinkOverviewEntry> value)
        {
            PaymentLinkOverviewEntries = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewResponse WithTotal(long? value)
        {
            Total = value;
            return this;
        }
    }
}
