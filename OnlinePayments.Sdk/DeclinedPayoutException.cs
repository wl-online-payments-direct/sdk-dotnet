using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from a create payout call.
    /// </summary>
    public class DeclinedPayoutException : DeclinedTransactionException
    {
        private readonly PayoutErrorResponse _errorResponse;

        /// <summary>
        /// Gets the result of creating a payout if available, otherwise <c>null</c>.
        /// </summary>
        public PayoutResult PayoutResult => _errorResponse?.PayoutResult;

        public DeclinedPayoutException(System.Net.HttpStatusCode statusCode, string responseBody, PayoutErrorResponse errorResponse)
            : base(BuildMessage(errorResponse), statusCode, responseBody, errorResponse?.ErrorId, errorResponse?.Errors)
        {
            this._errorResponse = errorResponse;
        }

        static string BuildMessage(PayoutErrorResponse errors)
        {
            PayoutResult payout = errors?.PayoutResult;
            if (payout != null)
            {
                return "declined payout '" + payout.Id + "' with status '" + payout.Status + "'";
            }
            return "the payment platform returned a declined refund response";
        }
    }
}
