using System.Collections.Generic;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform when a non-existing or removed object is trying to be accessed.
    /// </summary>
    public class ReferenceException : ApiException
    {
        public ReferenceException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base("the payment platform returned an incorrect request error response", statusCode, responseBody, errorId, errors)
        {

        }

        public ReferenceException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
