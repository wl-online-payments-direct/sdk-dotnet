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
        /// Type of operation, including the merchant batch reference and the total count of items in the batch
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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithCancelPayments(IList<CancelPaymentBatchRequest> value)
        {
            CancelPayments = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithCapturePayments(IList<CapturePaymentBatchRequest> value)
        {
            CapturePayments = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithCreatePaymentLinks(IList<CreatePaymentLinkRequest> value)
        {
            CreatePaymentLinks = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithCreatePayments(IList<CreatePaymentRequest> value)
        {
            CreatePayments = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithCreatePayouts(IList<CreatePayoutRequest> value)
        {
            CreatePayouts = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithHeader(BatchMetadata value)
        {
            Header = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithRefundPayments(IList<RefundPaymentBatchRequest> value)
        {
            RefundPayments = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchRequestBody WithSubsequentPayments(IList<SubsequentPaymentBatchRequest> value)
        {
            SubsequentPayments = value;
            return this;
        }
    }
}
