/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class SepaDirectDebitPaymentProduct771SpecificInput
    {
        /// <summary>
        /// The unique reference of the existing mandate to use in this payment.<para />
        /// </summary>
        public string ExistingUniqueMandateReference { get; set; } = null;

        /// <summary>
        /// Object containing information to create a SEPA Direct Debit mandate.<para />
        /// </summary>
        public CreateMandateWithReturnUrl Mandate { get; set; } = null;
    }
}
