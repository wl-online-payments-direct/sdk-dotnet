/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5001SpecificInput
    {
        /// <summary>
        /// In PSD2, the ExemptionRequest field is used by merchants requesting an exemption when not using authentication on a transaction, in order to keep the conversion up. This field indicates the reason for the authentication exemption request. Allowed values:
        /// <list type="bullet">
        ///   <item><description>low-value - The transaction amount is below the 30€, with a maximum of 5 transactions or €100 accumulated per customer.</description></item>
        ///   <item><description>transaction-risk-analysis - The transaction has been assessed as low risk by the merchant's fraud prevention system.</description></item>
        /// </list>
        /// </summary>
        public string ExemptionRequest { get; set; }

        /// <summary>
        /// Determines the type of the subsequent that will be used. Allowed values:
        /// <list type="bullet">
        ///   <item><description>recurring - Transactions processed at fixed, regular intervals not to exceed one year between Transactions, representing an agreement between a consumer and a merchant to purchase goods or services provided over a period of time. Note that a recurring MIT transaction is initiated by the merchant (payee) not the customer (payer) and so is out of scope of PSD2. Recurring transactions that are in scope of PSD2 (and therefore may benefit from the recurring transaction exemption) are those that are customer (payer) initiates, e.g. standing orders set up from a bank account.</description></item>
        ///   <item><description>installment - Installment payments describe a single purchase of goods or services billed to a consumer in multiple transactions over a period of time agreed by the consumer and merchant.</description></item>
        ///   <item><description>other - other cases</description></item>
        /// </list>
        /// </summary>
        public string SubsequentType { get; set; }
    }
}
