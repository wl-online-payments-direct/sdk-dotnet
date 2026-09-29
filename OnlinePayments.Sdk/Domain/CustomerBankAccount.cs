/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerBankAccount
    {
        /// <summary>
        /// Name of account holder
        /// </summary>
        public string AccountHolderName { get; set; }

        /// <summary>
        /// Bank Identification Code
        /// </summary>
        public string Bic { get; set; }

        /// <summary>
        /// The IBAN is the International Bank Account Number. It is an internationally agreed format for the BBAN and includes the ISO country code and two check digits.
        /// </summary>
        public string Iban { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerBankAccount WithAccountHolderName(string value)
        {
            AccountHolderName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerBankAccount WithBic(string value)
        {
            Bic = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerBankAccount WithIban(string value)
        {
            Iban = value;
            return this;
        }
    }
}
