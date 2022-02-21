namespace OnlinePayments.Sdk.Logging
{
    class ValueObfuscator
    {
        internal static readonly ValueObfuscator INSTANCE = new ValueObfuscator();

        internal virtual string ObfuscateValue(string value)
        {
            var valueLength = value?.Length ?? 0;
            return valueLength == 0
                ? value
                : "*" + valueLength;
        }
    }
}
