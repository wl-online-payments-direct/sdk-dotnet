/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using Newtonsoft.Json;

namespace Ingenico.Direct.Sdk.Domain
{
    public class RedirectData
    {
        [JsonProperty(PropertyName = "RETURNMAC")]
        public string RETURNMAC { get; set; } = null;

        public string RedirectURL { get; set; } = null;
    }
}
