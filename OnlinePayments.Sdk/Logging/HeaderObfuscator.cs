using System.Collections.Generic;

namespace OnlinePayments.Sdk.Logging
{
    class HeaderObfuscator : Obfuscator
    {
        public static HeaderObfuscatorBuilder Builder()
        {
            return new HeaderObfuscatorBuilder();
        }

        public class HeaderObfuscatorBuilder
        {
            public HeaderObfuscatorBuilder WithField(string property)
            {
                Obfuscators.Add(property, ValueObfuscator.INSTANCE);
                return this;
            }

            public HeaderObfuscatorBuilder WithSensitiveField(string property)
            {
                Obfuscators.Add(property, SensitiveValueObfuscator.INSTANCE);
                return this;
            }

            public HeaderObfuscator Build()
            {
                return new HeaderObfuscator(this.Obfuscators);
            }

            IDictionary<string, ValueObfuscator> Obfuscators { get; }
                = new Dictionary<string, ValueObfuscator>();
        }

        HeaderObfuscator(IDictionary<string, ValueObfuscator> obfuscators)
            : base(obfuscators, true)
        {

        }
    }
}
