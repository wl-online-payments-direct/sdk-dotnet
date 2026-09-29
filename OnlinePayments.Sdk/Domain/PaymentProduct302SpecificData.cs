/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct302SpecificData
    {
        /// <summary>
        /// The networks that can be used in the current payment context. The strings that represent the networks in the array are identical to the strings that Apple uses in their documentation. For instance &quot;Visa&quot;.
        /// </summary>
        public IList<string> Networks { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct302SpecificData WithNetworks(IList<string> value)
        {
            Networks = value;
            return this;
        }
    }
}
