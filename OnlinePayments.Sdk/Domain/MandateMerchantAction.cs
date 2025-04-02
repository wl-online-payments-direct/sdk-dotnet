/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateMerchantAction
    {
        /// <summary>
        /// Action merchants needs to take in the online mandate process. Possible values are:
        /// <list type="bullet">
        ///   <item><description>REDIRECT - The customer needs to be redirected using the details found in redirectData</description></item>
        /// </list>
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Object containing all data needed to redirect the customer
        /// </summary>
        public MandateRedirectData RedirectData { get; set; }
    }
}
