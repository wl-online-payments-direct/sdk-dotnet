using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from a refund call.
    /// </summary>
    public class DeclinedRefundException : DeclinedTransactionException
    {
        private readonly RefundErrorResponse _errorResponse;

        /// <summary>
        /// Gets the result of creating a refund if available, otherwise <c>null</c>.
        /// </summary>
        public RefundResponse RefundResult => _errorResponse?.RefundResult;

        public DeclinedRefundException(System.Net.HttpStatusCode statusCode, string responseBody, RefundErrorResponse errorResponse)
            : base(BuildMessage(errorResponse), statusCode, responseBody, errorResponse?.ErrorId, errorResponse?.Errors)
        {
            this._errorResponse = errorResponse;
        }

        static string BuildMessage(RefundErrorResponse errorResponse)
        {
            RefundResponse refund = errorResponse?.RefundResult;
            if (refund != null)
            {
                return "declined refund '" + refund.Id + "' with status '" + refund.Status + "'";
            }
            return "the payment platform returned a declined refund response";
        }
    }
}
