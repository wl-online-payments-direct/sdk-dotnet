/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class BankAccountIban
    {
        /// <summary>
        /// The IBAN is the International Bank Account Number. It is an internationally agreed format for the BBAN and includes the ISO country code and two check digits.
        /// Required for the creation of a Payout
        /// Required for Create and Update token.
        /// Required for Create mandate and Create payment with mandate calls.
        /// </summary>
        public string Iban { get; set; }
    }
}
