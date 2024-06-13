/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDSWhitelist
    {
        /// <summary>
        /// Whitelist Status Source. This data element will be populated by the system setting Whitelist Status<para />
        /// </summary>
        public string Source { get; set; } = null;

        /// <summary>
        /// Whitelist Status. Enables the communication of trusted beneficiary/whitelist status between the ACS, the DS and the 3DS Requestor.<para />
        /// </summary>
        public string Status { get; set; } = null;
    }
}
