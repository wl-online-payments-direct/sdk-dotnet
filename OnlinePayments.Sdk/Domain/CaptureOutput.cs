/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class CaptureOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AcquiredAmount { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Amount that has been paid. This is deprecated. Use acquiredAmount instead.
        /// </summary>
        [Obsolete("Amount that has been paid. This is deprecated. Use acquiredAmount instead.")]
        public long? AmountPaid { get; set; }

        /// <summary>
        /// Object containing the card payment method details
        /// </summary>
        public CardPaymentMethodSpecificOutput CardPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-&gt; key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.
        /// </summary>
        public string MerchantParameters { get; set; }

        /// <summary>
        /// Object containing the mobile payment method details
        /// </summary>
        public MobilePaymentMethodSpecificOutput MobilePaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Object containing the redirect payment product details
        /// </summary>
        public RedirectPaymentMethodSpecificOutput RedirectPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// Object containing the SEPA direct debit details
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificOutput SepaDirectDebitPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object containing specific surcharging attributes applied to an order.
        /// </summary>
        public SurchargeSpecificOutput SurchargeSpecificOutput { get; set; }
    }
}
