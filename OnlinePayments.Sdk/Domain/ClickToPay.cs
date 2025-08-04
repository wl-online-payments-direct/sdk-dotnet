/*
 * This file was automatically generated.
 */
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class ClickToPay
    {
        /// <summary>
        /// A flag indicating whether the payment is made using Click to Pay
        /// </summary>
        [JsonProperty(PropertyName = "IsClickToPayPayment")]
        public bool? IsClickToPayPayment { get; set; }
    }
}
