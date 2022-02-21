using System;
using System.Text;

namespace OnlinePayments.Sdk
{
    static class UriBuilderExtensions
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
                sb.Append(builder.Query.TrimStart('?'))
                    .Append("&");
            }
            sb.Append(Uri.EscapeDataString(name))
                .Append("=")
                .Append(Uri.EscapeDataString(value));
            builder.Query = sb.ToString();
        }
    }
}
