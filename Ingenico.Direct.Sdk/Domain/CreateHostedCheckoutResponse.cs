/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class CreateHostedCheckoutResponse
    {
        [JsonProperty(PropertyName = "RETURNMAC")]
        public string RETURNMAC { get; set; } = null;

        public string HostedCheckoutId { get; set; } = null;

        public IList<string> InvalidTokens { get; set; } = null;

        public string MerchantReference { get; set; } = null;

        public string PartialRedirectUrl { get; set; } = null;
    }
}
