/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerPaymentActivity
    {
        /// <summary>
        /// Number of payment attempts (so including unsuccessful ones) made by this customer with you in the last 24 hours
        /// </summary>
        public int? NumberOfPaymentAttemptsLast24Hours { get; set; }

        /// <summary>
        /// Number of payment attempts (so including unsuccessful ones) made by this customer with you in the last 12 months
        /// </summary>
        public int? NumberOfPaymentAttemptsLastYear { get; set; }

        /// <summary>
        /// Number of successful purchases made by this customer with you in the last 6 months
        /// </summary>
        public int? NumberOfPurchasesLast6Months { get; set; }
    }
}
