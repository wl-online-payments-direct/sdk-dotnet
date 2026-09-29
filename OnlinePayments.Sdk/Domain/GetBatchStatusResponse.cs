/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetBatchStatusResponse
    {
        /// <summary>
        /// The total number of items included in the batch submission.
        /// </summary>
        public int? ItemCount { get; set; }

        /// <summary>
        /// Unique batch reference submitted by the merchant.
        /// </summary>
        public string MerchantBatchReference { get; set; }

        /// <summary>
        /// The specific operation type being requested for the batch.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// The status of the batch.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetBatchStatusResponse WithItemCount(int? value)
        {
            ItemCount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetBatchStatusResponse WithMerchantBatchReference(string value)
        {
            MerchantBatchReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetBatchStatusResponse WithOperationType(string value)
        {
            OperationType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetBatchStatusResponse WithStatus(string value)
        {
            Status = value;
            return this;
        }
    }
}
