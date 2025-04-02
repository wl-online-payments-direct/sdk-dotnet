/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3012SpecificInput
    {
        /// <summary>
        /// Indicate whether 3D Secure authentication should be forced.
        /// </summary>
        public bool? ForceAuthentication { get; set; }

        /// <summary>
        /// Indicate whether its a deferred payment.
        /// </summary>
        public bool? IsDeferredPayment { get; set; }

        /// <summary>
        /// Indicate whether its wallet initiated payment.
        /// </summary>
        public bool? IsWipTransaction { get; set; }

        /// <summary>
        /// Indicates how the cardholder was authenticated to the Merchant Wallet in the context of the transaction to which the BEPAF is attached
        /// <list type="bullet">
        ///   <item><description>01 = Username/password or PIN login successfully performed by cardholder.</description></item>
        ///   <item><description>02 = Authentication through Secret/Private Key in Secure Hardware Solution was successfully performed.</description></item>
        ///   <item><description>04 = Authentication through Secret/Private Key in Secure Software Solution (for example, mobile App) was successfully performed.</description></item>
        ///   <item><description>08 = Location-based Authentication was successfully performed.</description></item>
        ///   <item><description>10 = Environmental Authentication in Secure Software Solution (mobile App) was successfully performed.</description></item>
        ///   <item><description>20 = Behavioral Analysis was successfully performed.</description></item>
        ///   <item><description>40 = Biometrics Authentication was successfully performed.</description></item>
        ///   <item><description>80 = Out of band user authentication was successfully performed.</description></item>
        /// </list>
        /// </summary>
        public string WipMerchantAuthenticationMethod { get; set; }
    }
}
