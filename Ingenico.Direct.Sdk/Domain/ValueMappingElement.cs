/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class ValueMappingElement
    {
        public IList<PaymentProductFieldDisplayElement> DisplayElements { get; set; } = null;

        /// <summary>
        /// Value corresponding to the key<para />
        /// </summary>
        public string Value { get; set; } = null;
    }
}
