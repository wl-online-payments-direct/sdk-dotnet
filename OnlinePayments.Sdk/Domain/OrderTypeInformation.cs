/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderTypeInformation
    {
        /// <summary>
        /// Possible values are:<para />
        /// * physical (tangible goods shipped to the customers)<para />
        /// * digital (digital services like ebooks, streaming...)<para />
        /// </summary>
        public string PurchaseType { get; set; } = null;

        /// <summary>
        /// Identifies the type of transaction being authenticated. Possible values are:<para />
        /// * purchase = The purpose of the transaction is to purchase goods or services (Default)<para />
        /// * check-acceptance = The purpose of the transaction is to accept a 'check'/'cheque'<para />
        /// * account-funding = The purpose of the transaction is to fund an account<para />
        /// * quasi-cash = The purpose of the transaction is to buy a quasi cash type product that is representative of actual cash such as money orders, traveler's checks, foreign currency, lottery tickets or casino gaming chips<para />
        /// * prepaid-activation-or-load = The purpose of the transaction is to activate or load a prepaid card<para />
        /// </summary>
        public string TransactionType { get; set; } = null;
    }
}
