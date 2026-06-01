/*
 * This file was automatically generated.
 */
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform containing problem details.
    /// </summary>
    public class ProblemDetailsException : ApiException
    {
        /// <summary>
        /// Gets the problem details response if available, otherwise <c>null</c>.
        /// </summary>
        public ProblemDetailsResponse Response => _response;

        public ProblemDetailsException(HttpStatusCode statusCode, string responseBody, ProblemDetailsResponse response)
            : base("the payment platform returned a problem details error response", statusCode, responseBody, null, null)
        {
            _response = response;
        }

        private readonly ProblemDetailsResponse _response;
    }
}
