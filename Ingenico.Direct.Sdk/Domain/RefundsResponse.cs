/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundsResponse
    {
        /// <summary>
        /// The list of all refunds performed on the requested payment.<para />
        /// </summary>
        public IList<RefundResponse> Refunds { get; set; } = null;
    }
}
