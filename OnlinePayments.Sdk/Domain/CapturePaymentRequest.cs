/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CapturePaymentRequest
    {
        /// <summary>
        /// Here you can specify the amount that you want to capture (specified in cents, where single digit currencies are presumed to have 2 digits). The amount can be lower than the amount that was authorized, but not higher.
        /// If left empty, the full amount will be captured and the request will be final.
        /// If the full amount is captured, the request will also be final.
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// This property indicates whether this will be the final operation. The default value for this property is false.
        /// </summary>
        public bool? IsFinal { get; set; }

        /// <summary>
        /// List of lineItemIds and quantities for capture/refund/cancellation.
        /// </summary>
        public IList<LineItemDetail> LineItemDetails { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }
    }
}
