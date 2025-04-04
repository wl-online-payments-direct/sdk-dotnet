using System;
using System.Text.RegularExpressions;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// A single request header. Immutable.
    /// </summary>
    public class RequestHeader : IRequestHeader
    {
        public RequestHeader(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required");
            }
            Name = name;
            Value = NormalizeValue(value);
        }

        private static string NormalizeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            // Replace all sequences of linebreak-whitespace* with a single linebreak-space
            const string pattern = "\r?\n[\\s-[\r\n]]*";
            var newString = new Regex(pattern, RegexOptions.Multiline | RegexOptions.CultureInvariant).Replace(value, " ").Trim();
            return newString;
        }

        #region IRequestHeader
        public string Name { get; }

        public string Value { get; }
        #endregion

        public override string ToString() => Name + ":" + Value;

        public override int GetHashCode()
            => Tuple.Create(Name, Value).GetHashCode();

        private bool Equals(RequestHeader obj) => (obj?.Name?.Equals(Name) ?? false) && (obj.Value?.Equals(Value) ?? false);

        public override bool Equals(object obj) => Equals(obj as RequestHeader);
    }
}
