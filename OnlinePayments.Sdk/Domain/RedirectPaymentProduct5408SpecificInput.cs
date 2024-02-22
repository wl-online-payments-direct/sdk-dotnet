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
        /// * true - consumer can only use instant payment for Account to Account Bank transfer payments<para />
        /// * false - consumer can only use standard payment for Account to Account Bank transfer payments<para />
        /// </summary>
        public bool? InstantPaymentOnly { get; set; } = null;
    }
}
