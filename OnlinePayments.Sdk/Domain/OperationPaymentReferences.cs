/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OperationPaymentReferences
    {
        /// <summary>
        /// Your unique reference of the transaction that is also returned in our report files. This is almost always used for your reconciliation of our report files.
        /// It is highly recommended to provide a single MerchantReference per unique order on your side
        /// </summary>
        public string MerchantReference { get; set; }

        /// <summary>
        /// An identifier for a group of transactions. This reference helps to link multiple related transactions together, facilitating easier reconciliation and tracking.
        /// </summary>
        public string OperationGroupReference { get; set; }
    }
}
