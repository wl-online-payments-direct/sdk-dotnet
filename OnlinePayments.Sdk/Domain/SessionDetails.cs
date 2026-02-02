/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SessionDetails
    {
        /// <summary>
        /// Session identifier from where this payment originates from. Depends on the session type: ex: For PayByLink: id is the corresponding paymentLinkId.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Session type. This denotes the origin of the session. For example PayByLink, HostedTokenization, etc.
        /// </summary>
        public string Type { get; set; }
    }
}
