/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from the payment platform when an idempotent request failed because the first request has not finished yet.
    /// </summary>
    public class IdempotenceException : ApiException
    {
        /// <summary>
        /// Gets the key that was used for the idempotent request.
        /// </summary>
        public string IdempotenceKey { get; }

        /// <summary>
        /// Gets the request timestamp of the first idempotent request with the same key.
        /// </summary>
        public long? IdempotenceRequestTimestamp { get; }

        public IdempotenceException(string idempotenceKey, long? idempotenceRequestTimestamp, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : this(idempotenceKey, idempotenceRequestTimestamp, "the payment platform returned a duplicate request error response", statusCode, responseBody, errorId, errors)
        {

        }

        public IdempotenceException(string idempotenceKey, long? idempotenceRequestTimestamp, string message, HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {
            IdempotenceKey = idempotenceKey;
            IdempotenceRequestTimestamp = idempotenceRequestTimestamp;
        }
    }
}
