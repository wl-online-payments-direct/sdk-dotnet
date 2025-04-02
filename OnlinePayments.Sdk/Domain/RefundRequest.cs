/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// The identifier of the capture that is used for partial refund. CaptureId is only necessary for Paypal/PostfinancePay multi-capture payments.
        /// </summary>
        public string CaptureId { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }
    }
}
