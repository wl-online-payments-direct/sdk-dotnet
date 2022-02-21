/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ExternalCardholderAuthenticationData
    {
        /// <summary>
        /// Identifier of the authenticated transaction at the ACS/Issuer.<para />
        /// </summary>
        public string AcsTransactionId { get; set; } = null;

        /// <summary>
        /// Exemption code from Carte Bancaire (130) (unknown possible values so far -free format).<para />
        /// </summary>
        public string AppliedExemption { get; set; } = null;

        /// <summary>
        /// The CAVV (cardholder authentication verification value) or AAV (accountholder authentication value) provides an authentication validation value.<para />
        /// Note:<para />
        ///   This is mandatory for ECI 2 and 5.<para />
        /// </summary>
        public string Cavv { get; set; } = null;

        /// <summary>
        /// The algorithm, from your 3D Secure provider, used to generate the authentication CAVV.<para />
        /// Note:<para />
        ///   Required when<para />
        ///   * The 3D Secure authentication for the transaction is managed by a third-party 3D Secure authentication provider<para />
        ///   * You process the transaction through Atos<para />
        /// </summary>
        public string CavvAlgorithm { get; set; } = null;

        /// <summary>
        /// The 3-D Secure Directory Server transaction ID that is used for the 3D Authentication<para />
        /// Example: d4c849f8-24c6-4673-bf34-d0f822c81b16<para />
        /// </summary>
        public string DirectoryServerTransactionId { get; set; } = null;

        /// <summary>
        /// Electronic Commerce Indicator provides authentication validation results returned after AUTHENTICATIONVALIDATION<para />
        /// * 0 = No authentication, Internet (no liability shift, not a 3D Secure transaction)<para />
        /// * 1 = Authentication attempted (MasterCard)<para />
        /// * 2 = Successful authentication (MasterCard)<para />
        /// * 5 = Successful authentication (Visa, Diners Club, Amex)<para />
        /// * 6 = Authentication attempted (Visa, Diners Club, Amex)<para />
        /// * 7 = No authentication, Internet (no liability shift, not a 3D Secure transaction)<para />
        /// * (empty) = Not checked or not enrolled<para />
        /// </summary>
        public int? Eci { get; set; } = null;

        /// <summary>
        /// Global score calculated by the Carte Bancaire (130) Scoring platform. Possible values from 0 to 99.<para />
        /// </summary>
        public int? SchemeRiskScore { get; set; } = null;

        /// <summary>
        /// The 3-D Secure version used for the authentication. Possible values:<para />
        /// * v1<para />
        /// * v2<para />
        /// * 1.0.2<para />
        /// * 2.1.0<para />
        /// * 2.2.0<para />
        /// </summary>
        public string ThreeDSecureVersion { get; set; } = null;

        /// <summary>
        /// The transaction ID that is used for the 3D Authentication<para />
        /// </summary>
        public string Xid { get; set; } = null;
    }
}
