using Ingenico.Direct.Sdk.Domain;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Represents an error response from a refund call.
    /// </summary>
    public class DeclinedRefundException : DeclinedTransactionException
    {
        private readonly RefundErrorResponse _errors;

        /// <summary>
        /// Gets the result of creating a refund if available, otherwise <c>null</c>.
        /// </summary>
        public RefundResponse RefundResult => _errors?.RefundResult;

        public DeclinedRefundException(System.Net.HttpStatusCode statusCode, string responseBody, RefundErrorResponse errors)
            : base(BuildMessage(errors), statusCode, responseBody, errors?.ErrorId, errors?.Errors)
        {
            _errors = errors;
        }

        static string BuildMessage(RefundErrorResponse errors)
        {
            RefundResponse refund = errors?.RefundResult;
            if (refund != null)
            {
                return "declined refund '" + refund.Id + "' with status '" + refund.Status + "'";
            }
            return "the Ingenico ePayments platform returned a declined refund response";
        }
    }
}
