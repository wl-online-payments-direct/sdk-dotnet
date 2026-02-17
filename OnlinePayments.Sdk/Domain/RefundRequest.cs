/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

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
        /// List of lineItemIds and quantities for capture/refund/cancellation.
        /// </summary>
        public IList<LineItemDetail> LineItemDetails { get; set; }

        /// <summary>
        /// Object containing the additional refund details for an Omnichannel merchant
        /// </summary>
        public OmnichannelRefundSpecificInput OmnichannelRefundSpecificInput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// The reason for the refund. This will be available in our portal and reports for your information only. It will NOT appear in the consumer bank statement or yours.§
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// Object containing the specific input details for refunds for redirection payment methods.
        /// </summary>
        public RefundRedirectPaymentMethodSpecificInput RefundRedirectPaymentMethodSpecificInput { get; set; }
    }
}
