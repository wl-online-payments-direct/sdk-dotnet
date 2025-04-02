using System;
using System.Text;
using System.Linq;

namespace OnlinePayments.Sdk
{
    internal static class StringUtils
    {
        internal static string FromBase64String(this string input)
            => Encoding.GetString(Convert.FromBase64String(input));

        internal static string ToBase64String(this string input)
            => Convert.ToBase64String(Encoding.GetBytes(input));

        internal static Encoding Encoding
            => Encoding.UTF8;

        internal static string NullIfEmpty(this string input)
            => string.IsNullOrEmpty(input) ? null : input;

        internal static bool IsBlank(this string input)
            => string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim());

        internal static bool CompareWithoutTimingLeak(this string input, string expected)
        {
            var length = input.Length;
            var expectedLength = expected.Length;
            var limit = Math.Max(Math.Max(length, expectedLength), 256);
            var result = true;
            for (var i = 0; i < limit; i++)
            {
                if (i < length && i < expectedLength)
                {
                    result &= input.ElementAt(i) == expected.ElementAt(i);
                }
                else if (i >= length && i >= expectedLength)
                {
                    result &= true;
                }
                else
                {
                    result &= false;
                }
            }
            return result;
        }
    }
}
