/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class SessionData
    {
        /// <summary>
        /// Id of the created session
        /// </summary>
        public string HostedFieldsSessionId { get; set; }

        /// <summary>
        /// Locale used in the GUI towards the consumer.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// This is the URL to Worldline's payment platform.
        /// </summary>
        public string PlatformUrl { get; set; }

        /// <summary>
        /// The JWT token used to authorize calls between iframes and server
        /// </summary>
        public string SessionToken { get; set; }

        /// <summary>
        /// This is a list of validated, previously stored card tokens available for use in this checkout session.
        /// </summary>
        public IList<string> Tokens { get; set; }
    }
}
