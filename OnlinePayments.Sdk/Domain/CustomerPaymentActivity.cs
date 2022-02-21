/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerPaymentActivity
    {
        /// <summary>
        /// Number of payment attempts (so including unsuccessful ones) made by this customer with you in the last 24 hours<para />
        /// </summary>
        public int? NumberOfPaymentAttemptsLast24Hours { get; set; } = null;

        /// <summary>
        /// Number of payment attempts (so including unsuccessful ones) made by this customer with you in the last 12 months<para />
        /// </summary>
        public int? NumberOfPaymentAttemptsLastYear { get; set; } = null;

        /// <summary>
        /// Number of successful purchases made by this customer with you in the last 6 months<para />
        /// </summary>
        public int? NumberOfPurchasesLast6Months { get; set; } = null;
    }
}
