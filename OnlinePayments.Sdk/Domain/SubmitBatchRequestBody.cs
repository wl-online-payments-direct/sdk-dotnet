/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class SubmitBatchRequestBody
    {
        /// <summary>
        /// Array of cancel payment requests to be submitted in batch.
        /// </summary>
        public IList<CancelPaymentBatchRequest> CancelPayments { get; set; }

        /// <summary>
        /// Array of capture payment requests to be submitted in batch.
        /// </summary>
        public IList<CapturePaymentBatchRequest> CapturePayments { get; set; }

        /// <summary>
        /// An array containing multiple payment link generation requests that will be processed as a batch. Each item represents an individual payment link to be created.
        /// </summary>
        public IList<CreatePaymentLinkRequest> CreatePaymentLinks { get; set; }

        /// <summary>
        /// Array of payment creation requests to be submitted in batch.
        /// </summary>
        public IList<CreatePaymentRequest> CreatePayments { get; set; }

        /// <summary>
        /// Array of payout creation requests to be submitted in batch.
        /// </summary>
        public IList<CreatePayoutRequest> CreatePayouts { get; set; }

        /// <summary>
        /// Details about the batch, including the type of operation, the merchant batch reference, and the number of items in the batch.
        /// </summary>
        public BatchMetadata Header { get; set; }

        /// <summary>
        /// Array of refund payment requests to be submitted in batch.
        /// </summary>
        public IList<RefundPaymentBatchRequest> RefundPayments { get; set; }

        /// <summary>
        /// Array of subsequent payment requests to be submitted in batch.
        /// </summary>
        public IList<SubsequentPaymentBatchRequest> SubsequentPayments { get; set; }
    }
}
