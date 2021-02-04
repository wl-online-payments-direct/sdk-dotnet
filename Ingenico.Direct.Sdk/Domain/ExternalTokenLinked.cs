/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Newtonsoft.Json;

namespace Ingenico.Direct.Sdk.Domain
{
    public class ExternalTokenLinked
    {
        [JsonProperty(PropertyName = "GTSComputedToken")]
        /// <summary>
        /// The GTS computed token<para />
        /// </summary>
        public string GTSComputedToken { get; set; } = null;
    }
}
