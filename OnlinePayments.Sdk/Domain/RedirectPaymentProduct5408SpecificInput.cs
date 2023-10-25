/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5408SpecificInput
    {
        /// <summary>
        /// Data of customer bank account<para />
        /// </summary>
        public CustomerBankAccount CustomerBankAccount { get; set; } = null;

        /// <summary>
        /// * true - customer is allowed to do only instant payment for Account to Account Bank transfer payments<para />
        /// * false - customer is allowed to choose between instant or standard payment after the bank selection page for Account to Account Bank transfer payments<para />
        /// </summary>
        public bool? InstantPaymentOnly { get; set; } = null;
    }
}
