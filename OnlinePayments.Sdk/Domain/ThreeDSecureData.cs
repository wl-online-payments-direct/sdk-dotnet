/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDSecureData
    {
        /// <summary>
        /// The ACS Transaction ID for a prior 3-D Secure authenticated transaction (for example, the first recurring transaction that was authenticated with the customer)<para />
        /// </summary>
        public string AcsTransactionId { get; set; } = null;

        /// <summary>
        /// Method of authentication used for this transaction. Possible values:<para />
        ///  * frictionless = The authentication went without a challenge<para />
        ///  * challenged = Cardholder was challenged<para />
        ///  * avs-verified = The authentication was verified by AVS<para />
        ///  * other = Another issuer method was used to authenticate this transaction<para />
        /// </summary>
        public string Method { get; set; } = null;

        /// <summary>
        /// Timestamp in UTC (YYYYMMDDHHmm) of the 3-D Secure authentication of this transaction<para />
        /// </summary>
        public string UtcTimestamp { get; set; } = null;
    }
}
