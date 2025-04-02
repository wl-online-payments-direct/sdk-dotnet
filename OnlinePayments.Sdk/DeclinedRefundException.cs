/*
 * This file was automatically generated.
 */
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from a refund call.
    /// </summary>
    public class DeclinedRefundException : DeclinedTransactionException
    {
        /// <summary>
        /// Gets the result of creating a refund if available, otherwise <c>null</c>.
        /// </summary>
        public RefundResponse RefundResponse => _response?.RefundResult;

        public DeclinedRefundException(HttpStatusCode statusCode, string responseBody, RefundErrorResponse response)
            : base(BuildMessage(response), statusCode, responseBody, response?.ErrorId, response?.Errors)
        {
            _response = response;
        }

        private readonly RefundErrorResponse _response;

        private static string BuildMessage(RefundErrorResponse response)
        {
            var refundResult = response?.RefundResult;
            if (refundResult != null)
            {
                return "declined refund '" + refundResult.Id + "' with status '" + refundResult.Status + "'";
            }
            return "the payment platform returned a declined refund response";
        }
    }
}
