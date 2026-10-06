/*
 * This file was automatically generated.
 */
using System;

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
        /// Date and time when the current payment was first created
        /// </summary>
        public DateTimeOffset? PaymentCreationDate { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        public RefundRedirectMethodSpecificOutput RedirectRefundMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// It is the server-side processing date and time of the transaction.
        /// </summary>
        public DateTimeOffset? TransactionDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithAmountPaid(long? value)
        {
            AmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithCardRefundMethodSpecificOutput(RefundCardMethodSpecificOutput value)
        {
            CardRefundMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithEWalletRefundMethodSpecificOutput(RefundEWalletMethodSpecificOutput value)
        {
            EWalletRefundMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithMerchantParameters(string value)
        {
            MerchantParameters = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithMobileRefundMethodSpecificOutput(RefundMobileMethodSpecificOutput value)
        {
            MobileRefundMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithOperationReferences(OperationPaymentReferences value)
        {
            OperationReferences = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithPaymentCreationDate(DateTimeOffset? value)
        {
            PaymentCreationDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithPaymentMethod(string value)
        {
            PaymentMethod = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithRedirectRefundMethodSpecificOutput(RefundRedirectMethodSpecificOutput value)
        {
            RedirectRefundMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithReferences(PaymentReferences value)
        {
            References = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundOutput WithTransactionDate(DateTimeOffset? value)
        {
            TransactionDate = value;
            return this;
        }
    }
}
