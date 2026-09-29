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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ClickToPay WithIsClickToPayPayment(bool? value)
        {
            IsClickToPayPayment = value;
            return this;
        }
    }
}
