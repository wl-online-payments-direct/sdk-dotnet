/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentOutputSummary
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Summary of card payment method details for reporting
        /// </summary>
        public CardPaymentMethodSpecificOutputSummary CardPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// Date and time the payment was created in UTC
        /// </summary>
        public DateTimeOffset? TransactionDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutputSummary WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutputSummary WithCardPaymentMethodSpecificOutput(CardPaymentMethodSpecificOutputSummary value)
        {
            CardPaymentMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutputSummary WithReferences(PaymentReferences value)
        {
            References = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutputSummary WithTransactionDate(DateTimeOffset? value)
        {
            TransactionDate = value;
            return this;
        }
    }
}
