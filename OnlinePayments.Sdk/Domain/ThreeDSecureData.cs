/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDSecureData
    {
        /// <summary>
        /// The ACS Transaction ID for a prior 3-D Secure authenticated transaction (for example, the first recurring transaction that was authenticated with the customer)
        /// </summary>
        public string AcsTransactionId { get; set; }

        /// <summary>
        /// Method of authentication used for this transaction. Possible values:
        /// <list type="bullet">
        ///   <item><description>frictionless = The authentication went without a challenge</description></item>
        ///   <item><description>challenged = Cardholder was challenged</description></item>
        ///   <item><description>avs-verified = The authentication was verified by AVS</description></item>
        ///   <item><description>other = Another issuer method was used to authenticate this transaction</description></item>
        /// </list>
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Timestamp in UTC (YYYYMMDDHHmm) of the 3-D Secure authentication of this transaction
        /// </summary>
        public string UtcTimestamp { get; set; }
    }
}
