using System.Collections.Generic;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform when validation of requests failed.
    /// </summary>
    public class ValidationException : ApiException
    {

        public ValidationException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base("the payment platform returned an incorrect request error response", statusCode, responseBody, errorId, errors)
        {

        }

        public ValidationException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
