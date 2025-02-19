/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OperationOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Our unique payment transaction identifier<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// <para />
        /// Deprecated: Use OperationReferences instead.<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; } = null;

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.<para />
        /// </summary>
        public string Status { get; set; } = null;

        /// <summary>
        /// This object has the numeric representation of the current payment status, timestamp of last status change and performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.<para />
        /// </summary>
        public PaymentStatusOutput StatusOutput { get; set; } = null;
    }
}