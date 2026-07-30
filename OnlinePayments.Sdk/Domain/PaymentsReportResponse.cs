/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentsReportResponse
    {
        /// <summary>
        /// Pagination information for cursor-based pagination
        /// </summary>
        public CursorPaginationInfo Pagination { get; set; }

        /// <summary>
        /// List of payment summaries
        /// </summary>
        public IList<PaymentSummary> Payments { get; set; }
    }
}
