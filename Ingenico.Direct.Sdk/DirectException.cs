using System.Collections.Generic;
using System.Net;
using Ingenico.Direct.Sdk.Domain;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Represents an error response from the Ingenico ePayments platform when something went wrong at the Ingenico ePayments platform or further downstream.
    /// </summary>
    public class DirectException : ApiException
    {
        public DirectException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base("the Ingenico ePayments platform returned an error response", statusCode, responseBody, errorId, errors)
        {

        }

        public DirectException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
