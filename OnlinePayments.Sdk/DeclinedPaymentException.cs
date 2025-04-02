/*
 * This file was automatically generated.
 */
using System.Net;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents an error response from a create payment call.
    /// </summary>
    public class DeclinedPaymentException : DeclinedTransactionException
    {
        /// <summary>
        /// Gets the result of creating a payment if available, otherwise <c>null</c>.
        /// </summary>
        public CreatePaymentResponse CreatePaymentResponse => _response?.PaymentResult;

        public DeclinedPaymentException(HttpStatusCode statusCode, string responseBody, PaymentErrorResponse response)
            : base(BuildMessage(response), statusCode, responseBody, response?.ErrorId, response?.Errors)
        {
            _response = response;
        }

        private readonly PaymentErrorResponse _response;

        private static string BuildMessage(PaymentErrorResponse response)
        {
            var payment = response?.PaymentResult?.Payment;
            if (payment != null)
            {
                return "declined payment '" + payment.Id + "' with status '" + payment.Status + "'";
            }
            return "the payment platform returned a declined payment response";
        }
    }
}
