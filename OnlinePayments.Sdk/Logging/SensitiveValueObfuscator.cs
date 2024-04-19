namespace OnlinePayments.Sdk.Logging
{
    class SensitiveValueObfuscator : ValueObfuscator
    {
        internal new static readonly SensitiveValueObfuscator INSTANCE = new SensitiveValueObfuscator();

        internal override string ObfuscateValue(string value)
        {
            var valueLength = value?.Length ?? 0;
            return valueLength == 0
                ? value
                : "***";
        }
    }
}
