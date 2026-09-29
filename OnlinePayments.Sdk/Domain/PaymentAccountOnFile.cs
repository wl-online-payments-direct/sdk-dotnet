/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentAccountOnFile
    {
        /// <summary>
        /// The date (YYYYMMDD) when the payment account on file was first created.
        /// <p />
        /// In case a token is used for the transaction we will use the creation date of the token in our system in case you leave this property empty.
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Number of attempts made to add new card to the customer account in the last 24 hours
        /// </summary>
        public int? NumberOfCardOnFileCreationAttemptsLast24Hours { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentAccountOnFile WithCreateDate(string value)
        {
            CreateDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentAccountOnFile WithNumberOfCardOnFileCreationAttemptsLast24Hours(int? value)
        {
            NumberOfCardOnFileCreationAttemptsLast24Hours = value;
            return this;
        }
    }
}
