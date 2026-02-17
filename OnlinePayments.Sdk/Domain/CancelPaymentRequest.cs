/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CancelPaymentRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

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
    }
}
