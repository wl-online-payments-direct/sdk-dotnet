/*
 * This file was automatically generated.
 */
using System;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class ExternalTokenLinked
    {
        /// <summary>
        /// The computed token
        /// </summary>
        [JsonProperty(PropertyName = "ComputedToken")]
        public string ComputedToken { get; set; }

        /// <summary>
        /// Deprecated: Use the field ComputedToken instead.
        /// </summary>
        [JsonProperty(PropertyName = "GTSComputedToken")]
        [Obsolete("Use the field ComputedToken instead.")]
        public string GTSComputedToken { get; set; }

        /// <summary>
        /// The generated token
        /// </summary>
        [JsonProperty(PropertyName = "GeneratedToken")]
        public string GeneratedToken { get; set; }
    }
}
