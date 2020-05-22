using System.Collections.Generic;
using Ingenico.Direct.Sdk.Domain;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Represents an error response from a create payment, payout or refund call.
    /// </summary>
    public class DeclinedTransactionException : ApiException
    {
        public DeclinedTransactionException(System.Net.HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(statusCode, responseBody, errorId, errors)
        {

        }

        public DeclinedTransactionException(string message, System.Net.HttpStatusCode statusCode, string responseBody, string errorId, IList<APIError> errors)
            : base(message, statusCode, responseBody, errorId, errors)
        {

        }
    }
}
