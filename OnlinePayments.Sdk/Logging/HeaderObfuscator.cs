using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A class that can be used to obfuscate headers. Thread-safe if all its obfuscation rules are.
    /// </summary>
    public class HeaderObfuscator
    {
        private readonly IDictionary<string, ObfuscationRule> _obfuscationRules;

        private HeaderObfuscator(IDictionary<string, ObfuscationRule> obfuscationRules)
        {
            _obfuscationRules = obfuscationRules.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Obfuscates the value for the given header as necessary.
        /// </summary>
        public string ObfuscateHeader(string name, string value)
        {
            return _obfuscationRules.TryGetValue(name, out var obfuscationRule) ? obfuscationRule(value) : value;
        }

        /// <summary>
        /// Returns a builder to create custom header obfuscators.
        /// This builder will contain some pre-defined obfuscation rules.These cannot be removed,
        /// but replacing them is possible.
        /// </summary>
        public static Builder Custom()
        {
            return new Builder()
                    .ObfuscateWithFixedLength(8, "X-GCS-Authentication-Token")
                    .ObfuscateWithFixedLength(8, "X-GCS-CallerPassword")
                    .ObfuscateWithFixedLength(8, "Authorization")
                    .ObfuscateWithFixedLength(8, "WWW-Authenticate")
                    .ObfuscateWithFixedLength(8, "Proxy-Authenticate")
                    .ObfuscateWithFixedLength(8, "Proxy-Authorization");
        }

        /// <summary>
        /// A default header obfuscator.
        /// This is equivalent to calling Custom().Build().
        /// </summary>
        public static readonly HeaderObfuscator DefaultObfuscator = Custom().Build();

        public class Builder
        {
            /// <summary>
            /// Adds an obfuscation rule that will replace all characters with *.
            /// </summary>
            public Builder ObfuscateAll(string headerName)
            {
                ObfuscationRules[headerName] = ValueObfuscator.All.ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will replace values with a fixed length string containing only *.
            /// </summary>
            public Builder ObfuscateWithFixedLength(int fixedLength, string headerName)
            {
                ObfuscationRules[headerName] = ValueObfuscator.FixedLength(fixedLength).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will keep a fixed number of characters at the start,
            /// then replaces all other characters with *.
            /// </summary>
            public Builder ObfuscateAllButFirst(int count, string headerName)
            {
                ObfuscationRules[headerName] = ValueObfuscator.KeepingStartCount(count).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will keep a fixed number of characters at the end,
            /// then replaces all other characters with *.
            /// </summary>
            public Builder ObfuscateAllButLast(int count, string headerName)
            {
                ObfuscationRules[headerName] = ValueObfuscator.KeepingEndCount(count).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds a custom, non-null obfuscation rule.
            /// </summary>
            public Builder ObfuscateCustom(string headerName, ObfuscationRule obfuscationRule)
            {
                ObfuscationRules[headerName] = obfuscationRule ?? throw new ArgumentException("obfuscationRule is required");
                return this;
            }

            public HeaderObfuscator Build()
            {
                return new HeaderObfuscator(ObfuscationRules);
            }

            internal Builder()
            {
            }

            private IDictionary<string, ObfuscationRule> ObfuscationRules { get; } = new Dictionary<string, ObfuscationRule>();
        }
    }
}
