/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentProduct320SpecificData
    {
        /// <summary>
        /// The Ingenico gateway identifier. You should use this when creating a [tokenization specification](https://developers.google.com/pay/api/android/reference/request-objects#Gateway) .<para />
        /// </summary>
        public string Gateway { get; set; } = null;

        /// <summary>
        /// The networks that can be used in the current payment context. The strings that represent the networks in the array are identical to the strings that GooglePay uses in their documentation. For instance "Visa".<para />
        /// </summary>
        public IList<string> Networks { get; set; } = null;
    }
}
