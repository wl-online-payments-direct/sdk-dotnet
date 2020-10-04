/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class CreateHostedTokenizationResponse
    {
        public string HostedTokenizationId { get; set; } = null;

        public IList<string> InvalidTokens { get; set; } = null;

        public string PartialRedirectUrl { get; set; } = null;
    }
}
