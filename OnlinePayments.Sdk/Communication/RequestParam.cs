using System;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// A single request parameter. Immutable.
    /// </summary>
    public class RequestParam
    {
        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the un-encoded value.
        /// </summary>
        public string Value { get; }

        public RequestParam(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is required");
            }
            Name = name;
            Value = value;
        }

        public override string ToString() => Name + ":" + Value;

        public override int GetHashCode()
            => Tuple.Create(Name, Value).GetHashCode();

        private bool Equals(RequestParam obj) => (obj?.Name?.Equals(Name) ?? false) && (obj.Value?.Equals(Value) ?? false);

        public override bool Equals(object obj) => Equals(obj as RequestParam);
    }
}
