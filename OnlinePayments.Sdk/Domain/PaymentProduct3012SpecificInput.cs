/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3012SpecificInput
    {
        /// <summary>
        /// Indicate whether 3D Secure authentication should be forced.<para />
        /// </summary>
        public bool? ForceAuthentication { get; set; } = null;

        /// <summary>
        /// Indicate whether its a deferred payment.<para />
        /// </summary>
        public bool? IsDeferredPayment { get; set; } = null;

        /// <summary>
        /// Indicate whether its wallet initiated payment.<para />
        /// </summary>
        public bool? IsWipTransaction { get; set; } = null;

        /// <summary>
        /// Indicates how the cardholder was authenticated to the Merchant Wallet in the context of the transaction to which the BEPAF is attached<para />
        /// * 01 = Username/password or PIN login successfully performed by cardholder.<para />
        /// * 02 = Authentication through Secret/Private Key in Secure Hardware Solution was successfully performed.<para />
        /// * 04 = Authentication through Secret/Private Key in Secure Software Solution (for example, mobile App) was successfully performed.<para />
        /// * 08 = Location-based Authentication was successfully performed.<para />
        /// * 10 = Environmental Authentication in Secure Software Solution (mobile App) was successfully performed.<para />
        /// * 20 = Behavioral Analysis was successfully performed.<para />
        /// * 40 = Biometrics Authentication was successfully performed.<para />
        /// * 80 = Out of band user authentication was successfully performed.<para />
        /// </summary>
        public string WipMerchantAuthenticationMethod { get; set; } = null;
    }
}
