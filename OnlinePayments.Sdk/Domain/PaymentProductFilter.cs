/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFilter
    {
        /// <summary>
        /// List containing all payment product groups that should either be restricted to in or excluded from the payment context. Currently, there is only one group, called 'cards'.
        /// </summary>
        public IList<string> Groups { get; set; }

        /// <summary>
        /// List containing all payment product ids that should either be restricted to in or excluded from the payment context.
        /// </summary>
        public IList<int> Products { get; set; }
    }
}
