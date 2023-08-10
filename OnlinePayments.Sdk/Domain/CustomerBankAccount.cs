/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerBankAccount
    {
        /// <summary>
        /// Name of account holder<para />
        /// </summary>
        public string AccountHolderName { get; set; } = null;

        /// <summary>
        /// Bank Identification Code<para />
        /// </summary>
        public string Bic { get; set; } = null;

        /// <summary>
        /// The IBAN is the International Bank Account Number. It is an internationally agreed format for the BBAN and includes the ISO country code and two check digits.<para />
        /// </summary>
        public string Iban { get; set; } = null;
    }
}
