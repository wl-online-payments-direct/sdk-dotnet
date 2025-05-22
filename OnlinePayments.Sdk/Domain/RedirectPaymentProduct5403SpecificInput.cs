/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5403SpecificInput
    {
        /// <summary>
        /// Determines how the remaining payment amount is handled if the initial payment is insufficient.
        /// <list type="bullet">
        ///   <item><description><c>true</c>: The payment process will continue on our side, allowing the customer to pay the outstanding amount using a different payment method.</description></item>
        ///   <item><description><c>false</c>: Merchant must create and process a separate payment for the remaining amount independently.</description></item>
        /// </list>
        /// </summary>
        public bool? CompleteRemainingPaymentAmount { get; set; }
    }
}
