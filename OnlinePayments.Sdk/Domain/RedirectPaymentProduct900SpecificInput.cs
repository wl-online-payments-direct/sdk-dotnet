/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct900SpecificInput
    {
        /// <summary>
        /// Display your customers in the Wero portal when you will capture the transaction. Mandatory only for requests in authorisation mode. Possible values:
        /// <list type="bullet">
        ///   <item><description>shipping - Upon shipping the order.</description></item>
        ///   <item><description>delivery - Upon delivering the order.</description></item>
        ///   <item><description>availability - As soon as the order is available.</description></item>
        ///   <item><description>serviceFulfilment - Upon fulfilling the service.</description></item>
        ///   <item><description>other - For any other use case.</description></item>
        /// </list>
        /// </summary>
        public string CaptureTrigger { get; set; }
    }
}
