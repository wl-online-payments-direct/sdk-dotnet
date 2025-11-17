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
        /// The 11 digits CV Connect ID of the customer. If this ID is not provided, the customer's e-mail address will be used, if available. The customer will be able to confirm their ID before proceeding with payment.
        /// </summary>
        public string BeneficiaryId { get; set; }
    }
}
