using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from a create payment call.
    /// </summary>
    public class DeclinedPaymentException : DeclinedTransactionException
    {
        private readonly PaymentErrorResponse _errorResponse;

        /// <summary>
        /// Gets the result of creating a payment if available, otherwise <c>null</c>.
        /// </summary>
        public CreatePaymentResponse CreatePaymentResponse => _errorResponse?.PaymentResult;

        public DeclinedPaymentException(System.Net.HttpStatusCode statusCode, string responseBody, PaymentErrorResponse errorResponse)
            : base(BuildMessage(errorResponse), statusCode, responseBody, errorResponse?.ErrorId, errorResponse?.Errors)
        {
            _errorResponse = errorResponse;
        }

        static string BuildMessage(PaymentErrorResponse errors)
        {
            PaymentResponse payment = errors?.PaymentResult?.Payment;
            if (payment != null)
            {
                return "declined payment '" + payment.Id + "' with status '" + payment.Status + "'";
            }
            return "the payment platform returned a declined payment response";
        }
    }
}

