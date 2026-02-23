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
    }
}
