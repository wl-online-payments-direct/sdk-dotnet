/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class BankAccountIban
    {
        /// <summary>
        /// The IBAN is the International Bank Account Number. It is an internationally agreed format for the BBAN and includes the ISO country code and two check digits.<para />
        /// Required for the creation of a Payout<para />
        /// Required for Create and Update token.<para />
        /// Required for Create mandate and Create payment with mandate calls.<para />
        /// </summary>
        public string Iban { get; set; } = null;
    }
}
