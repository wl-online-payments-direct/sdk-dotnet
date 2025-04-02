/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class SessionRequest
    {
        /// <summary>
        /// List of previously stored tokens linked to the customer that wants to checkout.
        /// </summary>
        public IList<string> Tokens { get; set; }
    }
}
