/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct320SpecificData
    {
        /// <summary>
        /// The gateway identifier. You should use this when creating a <a href="https://developers.google.com/pay/api/android/reference/request-objects#Gateway">tokenization specification</a> .
        /// </summary>
        public string Gateway { get; set; }

        /// <summary>
        /// The networks that can be used in the current payment context. The strings that represent the networks in the array are identical to the strings that GooglePay uses in their documentation. For instance &quot;Visa&quot;.
        /// </summary>
        public IList<string> Networks { get; set; }
    }
}
