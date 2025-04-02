/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform which contains an ID and a list of errors.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code that was returned by the Payment platform.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the raw response body that was returned by the Payment platform.
        /// </summary>
        public string ResponseBody { get; }

        /// <summary>
        /// Gets the <c>errorId</c> received from the Payment platform if available.
        /// </summary>
        public string ErrorId { get; }

        /// <summary>
        /// Gets the <c>errors</c> received from the Payment platform if available. Never <c>null</c>.
        /// </summary>
        public IList<APIError> Errors { get; }

        public ApiException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : this("the payment platform returned an error response", statusCode, responseBody, errorId, errors)
        {

        }

        public ApiException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
            ErrorId = errorId;
            Errors = errors ?? new List<APIError>();
        }

        public override string ToString()
        {
            var list = new StringBuilder(base.ToString());
            if (StatusCode > 0)
            {
                list.Append("; statusCode=").Append(StatusCode.ToString());
            }
            if (ResponseBody != null && ResponseBody.Any())
            {
                list.Append("; responseBody='").Append(ResponseBody).Append("'");
            }
            return list.ToString();
        }
    }
}
