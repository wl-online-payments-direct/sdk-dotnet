/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LoanRecipient
    {
        /// <summary>
        /// Should be filled with the last 10 digits of the bank account number of the recipient of the loan.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// The date of birth of the customer of the recipient of the loan.
        /// Format YYYYMMDD
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Should be filled with the first 6 and last 4 digits of the PAN number of the recipient of the loan.
        /// </summary>
        public string PartialPan { get; set; }

        /// <summary>
        /// Surname of the recipient of the loan.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Zip code of the recipient of the loan
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LoanRecipient WithAccountNumber(string value)
        {
            AccountNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LoanRecipient WithDateOfBirth(string value)
        {
            DateOfBirth = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LoanRecipient WithPartialPan(string value)
        {
            PartialPan = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LoanRecipient WithSurname(string value)
        {
            Surname = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LoanRecipient WithZip(string value)
        {
            Zip = value;
            return this;
        }
    }
}
