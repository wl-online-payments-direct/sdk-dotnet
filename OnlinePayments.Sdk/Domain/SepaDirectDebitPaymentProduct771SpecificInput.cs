/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SepaDirectDebitPaymentProduct771SpecificInput
    {
        /// <summary>
        /// The unique reference of the existing mandate to use in this payment.
        /// </summary>
        public string ExistingUniqueMandateReference { get; set; }

        /// <summary>
        /// Object containing information to create a SEPA Direct Debit mandate.
        /// </summary>
        public CreateMandateWithReturnUrl Mandate { get; set; }
    }
}
