/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5412SpecificInput
    {
        /// <summary>
        /// If true, the customer can adjust the portion of the total amount paid using this payment method in the ANCV app at authentication time.
        /// </summary>
        public bool? AdjustableAmount { get; set; }

        /// <summary>
        /// The customer's 11-digit CV Connect ID, or their e-mail address on file with ANCV. The customer will be able to confirm their ID before proceeding with payment.
        /// </summary>
        public string BeneficiaryId { get; set; }
    }
}
