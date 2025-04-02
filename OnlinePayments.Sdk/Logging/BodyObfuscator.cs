using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlinePayments.Sdk.Logging
{
    /// <summary>
    /// A class that can be used to obfuscate properties in JSON bodies. Thread-safe if all its obfuscation rules are.
    /// </summary>
    public class BodyObfuscator
    {
        private readonly IDictionary<string, ObfuscationRule> _obfuscationRules;
        private readonly Regex _propertyRegex;

        private BodyObfuscator(IDictionary<string, ObfuscationRule> obfuscationRules)
        {
            _obfuscationRules = obfuscationRules.ToImmutableDictionary();
            _propertyRegex = BuildPropertyPattern(obfuscationRules.Keys);
        }

        private static Regex BuildPropertyPattern(ICollection<string> propertyNames)
        {
            if (propertyNames.Count == 0)
            {
                // no matches possible
                return new Regex("$^");
            }

            using (var iterator = propertyNames.GetEnumerator())
            {
                /*
                 * Regex to create: (["'])(X|Y|Z)\1\s*:\s*(?:(["'])(.*?)(?<!\\)\3|([^"'\s\[\{][\S-[,]]*))
                 * Groups:
                 * 1: opening " or ' for the property name
                 * 2: property name
                 * 3: opening " or ' for the value
                 * 4: quoted value
                 * 5: non-quoted-value
                 * The negative lookbehind is to allow escaped quotes to be part of the value.
                 * What this does not allow currently is having values end with a \ (which would be escaped to \\).
                 */

                var regexStringBuilder = new StringBuilder();
                regexStringBuilder.Append("([\"'])(");
                if (iterator.MoveNext())
                {
                    regexStringBuilder.Append(Regex.Escape(iterator.Current));
                }

                while (iterator.MoveNext())
                {
                    regexStringBuilder.Append('|').Append(Regex.Escape(iterator.Current));
                }

                regexStringBuilder.Append(")\\1\\s*:\\s*(?:([\"'])(.*?)(?<!\\\\)\\3|([^\"'\\s\\[\\{][\\S-[,]]*))");

                return new Regex(regexStringBuilder.ToString(), RegexOptions.Multiline);
            }
        }

        private string ObfuscateValue(string propertyName, string value)
        {
            return _obfuscationRules.TryGetValue(propertyName, out var obfuscationRule) ? obfuscationRule(value) : value;
        }

        /// <summary>
        /// Obfuscates the given body as necessary.
        /// </summary>
        public string ObfuscateBody(string body)
        {
            if (string.IsNullOrEmpty(body))
            {
                return body;
            }

            var sb = new StringBuilder(body.Length);
            var index = 0;
            foreach (Match matcher in _propertyRegex.Matches(body))
            {
                var propertyName = matcher.Groups[2].Value;
                var valueGroup = matcher.Groups[4];
                if (!valueGroup.Success)
                {
                    valueGroup = matcher.Groups[5];
                }
                var value = valueGroup.Value;
                var valueStart = valueGroup.Index;
                var valueEnd = valueGroup.Index + valueGroup.Length;

                var obfuscatedValue = ObfuscateValue(propertyName, value);

                sb.Append(body, index, valueStart - index);
                sb.Append(obfuscatedValue);
                index = valueEnd;
            }
            sb.Append(body, index, body.Length - index);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a builder to create custom body obfuscators.
        /// This builder will contain some pre-defined obfuscation rules.These cannot be removed,
        /// but replacing them is possible.
        /// </summary>
        public static Builder Custom()
        {
            return new Builder()
                    .ObfuscateAll("additionalInfo")
                    .ObfuscateAll("cardholderName")
                    .ObfuscateAll("dateOfBirth")
                    .ObfuscateAll("emailAddress")
                    .ObfuscateAll("faxNumber")
                    .ObfuscateAll("firstName")
                    .ObfuscateAll("houseNumber")
                    .ObfuscateAll("mobilePhoneNumber")
                    .ObfuscateAll("passengerName")
                    .ObfuscateAll("phoneNumber")
                    .ObfuscateAll("street")
                    .ObfuscateAll("workPhoneNumber")
                    .ObfuscateAll("zip")
                    .ObfuscateAllButLast(4, "cardNumber")
                    .ObfuscateAllButLast(2, "expiryDate")
                    .ObfuscateAll("cvv")
                    .ObfuscateAllButLast(4, "iban")
                    .ObfuscateAllButLast(4, "accountNumber")
                    .ObfuscateAllButLast(4, "reformattedAccountNumber")
                    .ObfuscateAllButFirst(6, "bin")
                    // key-value pairs can contain any value, like credit card numbers or other private data; mask all values
                    .ObfuscateAll("value")
                    .ObfuscateWithFixedLength(8, "keyId")
                    .ObfuscateWithFixedLength(8, "secretKey")
                    .ObfuscateWithFixedLength(8, "publicKey")
                    .ObfuscateWithFixedLength(8, "userAuthenticationToken")
                    // encrypted payload is a base64 string that contains an encrypted value; to make decrypting even harder, just mask the entire thing
                    .ObfuscateWithFixedLength(8, "encryptedPayload")
                    // decrypted payload is a simple base64 string that may contain credit card numbers or other private data; just mask the entire thing
                    .ObfuscateWithFixedLength(8, "decryptedPayload")
                    // encrypted customer input is similar to encrypted payload
                    .ObfuscateWithFixedLength(8, "encryptedCustomerInput");
        }

        /// <summary>
        /// A default body obfuscator.
        /// This is equivalent to calling Custom().Build().
        /// </summary>
        public static readonly BodyObfuscator DefaultObfuscator = Custom().Build();

        public class Builder
        {
            /// <summary>
            /// Adds an obfuscation rule that will replace all characters with *.
            /// </summary>
            public Builder ObfuscateAll(string propertyName)
            {
                ObfuscationRules[propertyName] = ValueObfuscator.All.ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will replace values with a fixed length string containing only *.
            /// </summary>
            public Builder ObfuscateWithFixedLength(int fixedLength, string propertyName)
            {
                ObfuscationRules[propertyName] = ValueObfuscator.FixedLength(fixedLength).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will keep a fixed number of characters at the start,
            /// then replaces all other characters with *.
            /// </summary>
            public Builder ObfuscateAllButFirst(int count, string propertyName)
            {
                ObfuscationRules[propertyName] = ValueObfuscator.KeepingStartCount(count).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds an obfuscation rule that will keep a fixed number of characters at the end,
            /// then replaces all other characters with *.
            /// </summary>
            public Builder ObfuscateAllButLast(int count, string propertyName)
            {
                ObfuscationRules[propertyName] = ValueObfuscator.KeepingEndCount(count).ObfuscateValue;
                return this;
            }

            /// <summary>
            /// Adds a custom, non-null obfuscation rule.
            /// </summary>
            public Builder ObfuscateCustom(string propertyName, ObfuscationRule obfuscationRule)
            {
                ObfuscationRules[propertyName] = obfuscationRule ?? throw new ArgumentException("obfuscationRule is required");
                return this;
            }

            public BodyObfuscator Build()
            {
                return new BodyObfuscator(ObfuscationRules);
            }

            internal Builder()
            {
            }

            private IDictionary<string, ObfuscationRule> ObfuscationRules { get; } = new Dictionary<string, ObfuscationRule>();
        }
    }
}
