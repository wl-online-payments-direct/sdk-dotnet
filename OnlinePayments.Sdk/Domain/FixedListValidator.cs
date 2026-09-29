/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class FixedListValidator
    {
        public IList<string> AllowedValues { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public FixedListValidator WithAllowedValues(IList<string> value)
        {
            AllowedValues = value;
            return this;
        }
    }
}
