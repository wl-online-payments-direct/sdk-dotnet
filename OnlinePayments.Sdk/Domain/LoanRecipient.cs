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
    }
}
