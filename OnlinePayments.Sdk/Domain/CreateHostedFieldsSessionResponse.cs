/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedFieldsSessionResponse
    {
        /// <summary>
        /// This is a list of validated, previously stored card tokens available for use in this checkout session.
        /// </summary>
        public IList<CardToken> CardTokens { get; set; }

        /// <summary>
        /// Id of the created session
        /// </summary>
        public string HostedFieldsSessionId { get; set; }

        /// <summary>
        /// This is a list of tokens that failed validation.
        /// </summary>
        public IList<string> InvalidTokens { get; set; }

        /// <summary>
        /// This is the cryptographic hash used for Subresource Integrity validation.
        /// </summary>
        public string SdkSri { get; set; }

        /// <summary>
        /// The URL points to the hosted fields SDK.
        /// </summary>
        public string SdkUrl { get; set; }

        /// <summary>
        /// This contains the data required to initialize the Hosted Fields SDK.
        /// </summary>
        public SessionData SessionData { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithCardTokens(IList<CardToken> value)
        {
            CardTokens = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithHostedFieldsSessionId(string value)
        {
            HostedFieldsSessionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithInvalidTokens(IList<string> value)
        {
            InvalidTokens = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithSdkSri(string value)
        {
            SdkSri = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithSdkUrl(string value)
        {
            SdkUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionResponse WithSessionData(SessionData value)
        {
            SessionData = value;
            return this;
        }
    }
}
