using System.Text;

namespace OnlinePayments.Sdk
{
    static class StringBuilderUtils
    {
        internal static StringBuilder AppendLLine(this StringBuilder sb, string aString)
            => sb.Append(aString).Append("\n");
    }
}
