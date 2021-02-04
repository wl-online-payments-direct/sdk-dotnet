/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class CapturesResponse
    {
        /// <summary>
        /// The list of all captures performed on the requested payment.<para />
        /// </summary>
        public IList<Capture> Captures { get; set; } = null;
    }
}
