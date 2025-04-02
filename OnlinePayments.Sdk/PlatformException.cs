/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform when something went wrong at the payment platform or further downstream.
    /// </summary>
    public class PlatformException : ApiException
    {
        public PlatformException(HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base("the payment platform returned an error response", statusCode, responseBody, errorId, errors)
        {

        }

        public PlatformException(string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
