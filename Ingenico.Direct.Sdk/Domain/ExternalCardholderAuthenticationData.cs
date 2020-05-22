/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class ExternalCardholderAuthenticationData
    {
        public string AcsTransactionId { get; set; } = null;

        public string AppliedExemption { get; set; } = null;

        public string Cavv { get; set; } = null;

        public string CavvAlgorithm { get; set; } = null;

        public string DirectoryServerTransactionId { get; set; } = null;

        public int? Eci { get; set; } = null;

        public int? SchemeRiskScore { get; set; } = null;

        public string ThreeDSecureVersion { get; set; } = null;

        public string Xid { get; set; } = null;
    }
}
