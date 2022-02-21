/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductNetworksResponse
    {
        /// <summary>
        /// Array containing network entries for a payment product. The strings that represent the networks in the array are identical to the strings that the payment product vendors use in their documentation. For instance: "Visa" for Apple Pay, and "VISA" for Google Pay.<para />
        /// </summary>
        public IList<string> Networks { get; set; } = null;
    }
}
