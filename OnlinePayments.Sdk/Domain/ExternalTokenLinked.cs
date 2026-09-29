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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ExternalTokenLinked WithComputedToken(string value)
        {
            ComputedToken = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("Use the field ComputedToken instead.")]
        public ExternalTokenLinked WithGTSComputedToken(string value)
        {
            GTSComputedToken = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ExternalTokenLinked WithGeneratedToken(string value)
        {
            GeneratedToken = value;
            return this;
        }
    }
}
