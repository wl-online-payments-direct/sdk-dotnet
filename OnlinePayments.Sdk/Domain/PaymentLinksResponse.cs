/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinksResponse
    {
        [JsonProperty(PropertyName = "PaymentLinks")]
        public IList<PaymentLinkResponse> PaymentLinks { get; set; }
    }
}
