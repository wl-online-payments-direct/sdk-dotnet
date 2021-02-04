/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentProductFilter
    {
        /// <summary>
        /// List containing all payment product groups that should either be restricted to in or excluded from the payment context. Currently, there is only one group, called 'cards'.<para />
        /// </summary>
        public IList<string> Groups { get; set; } = null;

        /// <summary>
        /// List containing all payment product ids that should either be restricted to in or excluded from the payment context.<para />
        /// </summary>
        public IList<int?> Products { get; set; } = null;
    }
}
