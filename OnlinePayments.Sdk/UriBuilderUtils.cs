using System;
using System.Text;

namespace OnlinePayments.Sdk
{
    internal static class UriBuilderUtils
    {
        public static void AddParameter(this UriBuilder builder, string name, string value)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(builder.Query))
            {
                // Questionmark already added by uribuilder
            }
            else
            {
                sb.Append(builder.Query.TrimStart('?'));
                sb.Append("&");
            }
            sb.Append(Uri.EscapeDataString(name));
            sb.Append("=");
            sb.Append(Uri.EscapeDataString(value));
            builder.Query = sb.ToString();
        }
    }
}
