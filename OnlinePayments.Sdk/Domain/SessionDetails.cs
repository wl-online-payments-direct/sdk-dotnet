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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionDetails WithId(string value)
        {
            Id = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionDetails WithType(string value)
        {
            Type = value;
            return this;
        }
    }
}
