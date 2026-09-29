/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CapturesResponse
    {
        /// <summary>
        /// The list of all captures performed on the requested payment.
        /// </summary>
        public IList<Capture> Captures { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CapturesResponse WithCaptures(IList<Capture> value)
        {
            Captures = value;
            return this;
        }
    }
}
