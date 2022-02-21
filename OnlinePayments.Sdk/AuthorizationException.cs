using System.Collections.Generic;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform when authorization failed.
    /// </summary>
    public class AuthorizationException : ApiException
    {
        public AuthorizationException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base("The payment platform returned an incorrect request error response", statusCode, responseBody, errorId, errors)
        {

        }

        public AuthorizationException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors) : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
