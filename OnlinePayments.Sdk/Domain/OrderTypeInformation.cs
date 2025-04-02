/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderTypeInformation
    {
        /// <summary>
        /// Possible values are:
        /// <list type="bullet">
        ///   <item><description>physical (tangible goods shipped to the customers)</description></item>
        ///   <item><description>digital (digital services like ebooks, streaming...)</description></item>
        /// </list>
        /// </summary>
        public string PurchaseType { get; set; }

        /// <summary>
        /// Identifies the type of transaction being authenticated. Possible values are:
        /// <list type="bullet">
        ///   <item><description>purchase = The purpose of the transaction is to purchase goods or services (Default)</description></item>
        ///   <item><description>check-acceptance = The purpose of the transaction is to accept a 'check'/'cheque'</description></item>
        ///   <item><description>account-funding = The purpose of the transaction is to fund an account</description></item>
        ///   <item><description>quasi-cash = The purpose of the transaction is to buy a quasi cash type product that is representative of actual cash such as money orders, traveler's checks, foreign currency, lottery tickets or casino gaming chips</description></item>
        ///   <item><description>prepaid-activation-or-load = The purpose of the transaction is to activate or load a prepaid card</description></item>
        /// </list>
        /// </summary>
        public string TransactionType { get; set; }
    }
}
