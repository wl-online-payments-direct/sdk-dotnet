/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentPaymentProduct5001SpecificInput
    {
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
