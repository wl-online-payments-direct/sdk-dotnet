namespace Ingenico.Direct.Sdk.Logging
{
    class ValueObfuscator
    {
        internal static readonly ValueObfuscator ALL = new ValueObfuscator(0, 0, 0);

        private readonly char _maskCharacter;
        private readonly int _fixedLength;
        private readonly int _keepStartCount;
        private readonly int _keepEndCount;

        ValueObfuscator(int fixedLength, int keepStartCount, int keepEndCount)
        {
            _maskCharacter = '*';
            _fixedLength = fixedLength;
            _keepStartCount = keepStartCount;
            _keepEndCount = keepEndCount;
        }

        internal static ValueObfuscator FixedLength(int fixedLength)
        {
            return new ValueObfuscator(fixedLength, 0, 0);
        }

        internal static ValueObfuscator KeepingStartCount(int count)
        {
            return new ValueObfuscator(0, count, 0);
        }

        internal static ValueObfuscator KeepingEndCount(int count)
        {
            return new ValueObfuscator(0, 0, count);
        }

        internal string ObfuscateValue(string value)
        {
            var valueLength = value?.Length ?? 0;
            if (valueLength == 0)
            {
                return value;
            }
            if (_fixedLength > 0)
            {
                return RepeatMask(_fixedLength);
            }
            if (_keepStartCount == 0 && _keepEndCount == 0)
            {
                return RepeatMask(valueLength);
            }
            if (valueLength < _keepStartCount || valueLength < _keepEndCount)
            {
                return value;
            }
            char[] chars = value.ToCharArray();
            for (int i = _keepStartCount; i < valueLength - _keepEndCount; i++)
            {
                chars[i] = _maskCharacter;
            }

            return new string(chars);
        }

        string RepeatMask(int count)
        {
            char[] chars = new char[count];
            for (int i = _keepStartCount; i < chars.Length; i++)
            {
                chars[i] = _maskCharacter;
            }
            return new string(chars);
        }
    }
}
