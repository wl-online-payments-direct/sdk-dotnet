using Ingenico.Direct.Sdk.Domain;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// Represents an error response from a create payment call.
    /// </summary>
    public class DeclinedPaymentException : DeclinedTransactionException
    {
        private readonly PaymentErrorResponse _errors;

        /// <summary>
        /// Gets the result of creating a payment if available, otherwise <c>null</c>.
        /// </summary>
        public CreatePaymentResponse CreatePaymentResponse => _errors?.PaymentResult;

        public DeclinedPaymentException(System.Net.HttpStatusCode statusCode, string responseBody, PaymentErrorResponse errors)
            : base(BuildMessage(errors), statusCode, responseBody, errors?.ErrorId, errors?.Errors)
        {
            _errors = errors;
        }

        static string BuildMessage(PaymentErrorResponse errors)
        {
            PaymentResponse payment = errors?.PaymentResult?.Payment;
            if (payment != null)
            {
                return "declined payment '" + payment.Id + "' with status '" + payment.Status + "'";
            }
            return "the Ingenico ePayments platform returned a declined refund response";
        }
    }
}

