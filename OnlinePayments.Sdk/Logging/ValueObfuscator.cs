namespace OnlinePayments.Sdk.Logging
{
    internal class ValueObfuscator
    {
        internal static readonly ValueObfuscator All = new ValueObfuscator(0, 0, 0);

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
            if (value == null)
            {
                return null;
            }
            var valueLength = value.Length;
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
            var chars = value.ToCharArray();
            for (var i = _keepStartCount; i < valueLength - _keepEndCount; i++)
            {
                chars[i] = _maskCharacter;
            }

            return new string(chars);
        }

        private readonly char _maskCharacter;
        private readonly int _fixedLength;
        private readonly int _keepStartCount;
        private readonly int _keepEndCount;

        private ValueObfuscator(int fixedLength, int keepStartCount, int keepEndCount)
        {
            _maskCharacter = '*';
            _fixedLength = fixedLength;
            _keepStartCount = keepStartCount;
            _keepEndCount = keepEndCount;
        }

        private string RepeatMask(int count)
        {
            var chars = new char[count];
            for (var i = _keepStartCount; i < chars.Length; i++)
            {
                chars[i] = _maskCharacter;
            }
            return new string(chars);
        }
    }
}
