/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MerchantAction
    {
        /// <summary>
        /// Action merchants needs to take in the online payment process. Possible values are: <para />
        ///  * REDIRECT - The customer needs to be redirected using the details found in redirectData <para />
        ///  * SHOW_FORM - The customer needs to be shown a form with the fields found in formFields. You can submit the data entered by the user in a Complete payment request. <para />
        ///  * SHOW_INSTRUCTIONS - The customer needs to be shown payment instruction using the details found in showData. Alternatively the instructions can be rendered by us using the instructionsRenderingData <para />
        ///  * SHOW_TRANSACTION_RESULTS - The customer needs to be shown the transaction results using the details found in showData. Alternatively the instructions can be rendered by us using the instructionsRenderingData <para />
        ///  * MOBILE_THREEDS_CHALLENGE - The customer needs to complete a challenge as part of the 3D Secure authentication inside your mobile app. The details contained in mobileThreeDSecureChallengeParameters need to be provided to the EMVco certified Mobile SDK as a challengeParameters object. <para />
        ///  * CALL_THIRD_PARTY - The merchant needs to call a third party using the data found in thirdPartyData<para />
        /// </summary>
        public string ActionType { get; set; } = null;

        /// <summary>
        /// Object containing all data needed to redirect the customer<para />
        /// </summary>
        public RedirectData RedirectData { get; set; } = null;

        /// <summary>
        /// Object returned for the SHOW_FORM actionType.<para />
        /// </summary>
        public ShowFormData ShowFormData { get; set; } = null;
    }
}
