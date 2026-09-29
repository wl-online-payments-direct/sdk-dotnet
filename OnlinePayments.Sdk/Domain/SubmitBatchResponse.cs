/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubmitBatchResponse
    {
        /// <summary>
        /// Unique batch reference submitted by the merchant.
        /// </summary>
        public string MerchantBatchReference { get; set; }

        /// <summary>
        /// The total number of batch items that were included in the submitted batch.
        /// </summary>
        public int? TotalCount { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchResponse WithMerchantBatchReference(string value)
        {
            MerchantBatchReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SubmitBatchResponse WithTotalCount(int? value)
        {
            TotalCount = value;
            return this;
        }
    }
}
