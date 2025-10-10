/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OperationOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This object has the numeric representation of the current payment status, the timestamp of the last status change, and the performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.
        /// </summary>
        public PaymentStatusOutput StatusOutput { get; set; }
    }
}
