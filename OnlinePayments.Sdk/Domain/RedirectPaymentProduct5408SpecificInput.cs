/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5408SpecificInput
    {
        /// <summary>
        /// Data of customer bank account
        /// </summary>
        public CustomerBankAccount CustomerBankAccount { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - consumer can only use instant payment for Account to Account Bank transfer payments</description></item>
        ///   <item><description>false - consumer can only use standard payment for Account to Account Bank transfer payments</description></item>
        /// </list>
        /// </summary>
        public bool? InstantPaymentOnly { get; set; }
    }
}
