/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class DetokenizationResponse
    {
        /// <summary>
        /// The response contains an array of detokenized data for the provided token IDs, which includes card details and expiration dates.
        /// </summary>
        public IList<DetokenizedTokenResponse> Tokens { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DetokenizationResponse WithTokens(IList<DetokenizedTokenResponse> value)
        {
            Tokens = value;
            return this;
        }
    }
}
