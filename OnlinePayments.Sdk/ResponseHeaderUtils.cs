using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlinePayments.Sdk
{
    public static class ResponseHeaderUtils
    {
        /// <returns>
        /// The value of the header from this with the given name, or <c>null</c> if there was no such header.
        /// </returns>
        public static string GetHeaderValue(this IEnumerable<IResponseHeader> headers, string headerName)
        {
            return headers?.GetHeader(headerName)?.Value;
        }

        /// <returns>
        /// The header from this with the given name, or <c>null</c> if there was no such header.
        /// </returns>
        public static IResponseHeader GetHeader(this IEnumerable<IResponseHeader> headers, string headerName)
        {
            return headers?.FirstOrDefault((h) => h.Name.Equals(headerName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
