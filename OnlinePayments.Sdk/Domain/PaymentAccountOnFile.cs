/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentAccountOnFile
    {
        /// <summary>
        /// The date (YYYYMMDD) when the payment account on file was first created.<para />
        /// <para />
        /// In case a token is used for the transaction we will use the creation date of the token in our system in case you leave this property empty.<para />
        /// </summary>
        public string CreateDate { get; set; } = null;

        /// <summary>
        /// Number of attempts made to add new card to the customer account in the last 24 hours<para />
        /// </summary>
        public int? NumberOfCardOnFileCreationAttemptsLast24Hours { get; set; } = null;
    }
}
