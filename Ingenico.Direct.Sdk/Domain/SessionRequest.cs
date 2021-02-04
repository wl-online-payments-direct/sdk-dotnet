/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class SessionRequest
    {
        /// <summary>
        /// List of previously stored tokens linked to the customer that wants to checkout.<para />
        /// </summary>
        public IList<string> Tokens { get; set; } = null;
    }
}
