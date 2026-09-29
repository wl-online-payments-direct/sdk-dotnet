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
        /// The CSRF token used to authorize iframe's calls
        /// </summary>
        public string SessionToken { get; set; }

        /// <summary>
        /// This is a list of card tokens
        /// </summary>
        public IList<string> Tokens { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionData WithHostedFieldsSessionId(string value)
        {
            HostedFieldsSessionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionData WithLocale(string value)
        {
            Locale = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionData WithPlatformUrl(string value)
        {
            PlatformUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionData WithSessionToken(string value)
        {
            SessionToken = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SessionData WithTokens(IList<string> value)
        {
            Tokens = value;
            return this;
        }
    }
}
