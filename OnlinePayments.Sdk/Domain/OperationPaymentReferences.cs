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

        /// <summary>
        /// Creditor Reference to use where applicable for invoicing related to the transaction, in accordance with ISO 11649. Might require merchant specific setup to enable and is subject to agreement with the acquirer.
        /// </summary>
        public string StructuredCreditorReference { get; set; }
    }
}
