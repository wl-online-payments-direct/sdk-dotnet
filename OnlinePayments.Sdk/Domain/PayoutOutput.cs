/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class PayoutOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Object containing the card payment method details in a Payout context
        /// </summary>
        public PayoutCardPaymentMethodSpecificOutput PayoutCardPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Allows you to additionally specify the reason for initiating the payout for authorization purposes. If this field is not specified, authorization of the payment will be made according to your merchant profile. Possible values are:
        /// <list type="bullet">
        ///   <item><description>Gambling</description></item>
        ///   <item><description>Refund</description></item>
        ///   <item><description>Loyalty</description></item>
        /// </list>
        /// </summary>
        public string PayoutReason { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// It is the server-side processing date and time of the transaction.
        /// </summary>
        public DateTimeOffset TransactionDate { get; set; }
    }
}
