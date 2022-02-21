/*
 * This class was auto-generated.
 */
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class ExternalTokenLinked
    {
        [JsonProperty(PropertyName = "ComputedToken")]
        /// <summary>
        /// The computed token<para />
        /// </summary>
        public string ComputedToken { get; set; } = null;

        [JsonProperty(PropertyName = "GTSComputedToken")]
        /// <summary>
        /// Deprecated: Use the field ComputedToken instead.<para />
        /// </summary>
        public string GTSComputedToken { get; set; } = null;

        [JsonProperty(PropertyName = "GeneratedToken")]
        /// <summary>
        /// The generated token<para />
        /// </summary>
        public string GeneratedToken { get; set; } = null;
    }
}
