/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public long? AmountPaid { get; set; } = null;

        public RefundCardMethodSpecificOutput CardRefundMethodSpecificOutput { get; set; } = null;

        public RefundEWalletMethodSpecificOutput EWalletRefundMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-> key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.<para />
        /// </summary>
        public string MerchantParameters { get; set; } = null;

        public RefundMobileMethodSpecificOutput MobileRefundMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        public RefundRedirectMethodSpecificOutput RedirectRefundMethodSpecificOutput { get; set; } = null;

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
    }
}