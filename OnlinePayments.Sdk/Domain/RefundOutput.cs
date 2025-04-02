/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        public long? AmountPaid { get; set; }

        public RefundCardMethodSpecificOutput CardRefundMethodSpecificOutput { get; set; }

        public RefundEWalletMethodSpecificOutput EWalletRefundMethodSpecificOutput { get; set; }

        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-&gt; key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.
        /// </summary>
        public string MerchantParameters { get; set; }

        public RefundMobileMethodSpecificOutput MobileRefundMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        public RefundRedirectMethodSpecificOutput RedirectRefundMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }
    }
}
