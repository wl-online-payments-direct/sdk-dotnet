/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductNetworksResponse
    {
        /// <summary>
        /// Array containing network entries for a payment product. The strings that represent the networks in the array are identical to the strings that the payment product vendors use in their documentation. For instance: &quot;Visa&quot; for Apple Pay, and &quot;VISA&quot; for Google Pay.
        /// </summary>
        public IList<string> Networks { get; set; }
    }
}
