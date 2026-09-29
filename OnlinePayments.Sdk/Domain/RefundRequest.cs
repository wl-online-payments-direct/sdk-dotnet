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
        /// This property indicates whether this will be the final operation. The default value for this property is false.
        /// </summary>
        public bool? IsFinal { get; set; }

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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithCaptureId(string value)
        {
            CaptureId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithIsFinal(bool? value)
        {
            IsFinal = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithLineItemDetails(IList<LineItemDetail> value)
        {
            LineItemDetails = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithOmnichannelRefundSpecificInput(OmnichannelRefundSpecificInput value)
        {
            OmnichannelRefundSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithOperationReferences(OperationPaymentReferences value)
        {
            OperationReferences = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithReason(string value)
        {
            Reason = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithReferences(PaymentReferences value)
        {
            References = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRequest WithRefundRedirectPaymentMethodSpecificInput(RefundRedirectPaymentMethodSpecificInput value)
        {
            RefundRedirectPaymentMethodSpecificInput = value;
            return this;
        }
    }
}
