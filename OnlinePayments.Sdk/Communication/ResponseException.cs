using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// Thrown when a response was received from the Online Payments platform which indicates an error.
    /// </summary>
    public class ResponseException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code that was returned by the Online Payments platform.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the raw response body that was returned by the Online Payments platform.
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// Gets the headers that were returned by the Online Payments platform.
        /// </summary>
        public IEnumerable<IResponseHeader> Headers { get; }

        public ResponseException(HttpStatusCode statusCode, string body, IEnumerable<IResponseHeader> headers)
        {
            Body = body;
            StatusCode = statusCode;
            Headers = headers ?? Enumerable.Empty<IResponseHeader>();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:OnlinePayments.Sdk.Communication.ResponseException"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:OnlinePayments.Sdk.Communication.ResponseException"/>.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            if (StatusCode != HttpStatusCode.Unused)
            {
                sb.Append("; statusCode=").Append(StatusCode);
            }
            if (!string.IsNullOrEmpty(Body))
            {
                sb.Append("; responseBody='").Append(Body).Append("'");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the header with the given name, or <c>null</c> if there was no such header.
        /// </summary>
        public IResponseHeader GetHeader(string headerName)
            => Headers.GetHeader(headerName);

        /// <summary>
        /// Returns the value of the header with the given name, or <c>null</c> if there was no such header.
        /// </summary>
        public string GetHeaderValue(string headerName)
            => Headers.GetHeaderValue(headerName);
    }
}
