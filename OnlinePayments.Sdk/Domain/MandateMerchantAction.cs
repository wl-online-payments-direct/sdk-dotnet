/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateMerchantAction
    {
        /// <summary>
        /// Action merchants needs to take in the online mandate process. Possible values are:<para />
        /// * REDIRECT - The customer needs to be redirected using the details found in redirectData<para />
        /// </summary>
        public string ActionType { get; set; } = null;

        /// <summary>
        /// Object containing all data needed to redirect the customer<para />
        /// </summary>
        public MandateRedirectData RedirectData { get; set; } = null;
    }
}
