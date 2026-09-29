/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class RefundsResponse
    {
        /// <summary>
        /// The list of all refunds performed on the requested payment.
        /// </summary>
        public IList<RefundResponse> Refunds { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundsResponse WithRefunds(IList<RefundResponse> value)
        {
            Refunds = value;
            return this;
        }
    }
}
