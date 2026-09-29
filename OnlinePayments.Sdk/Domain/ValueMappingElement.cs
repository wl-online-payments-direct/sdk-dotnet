/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ValueMappingElement
    {
        public IList<PaymentProductFieldDisplayElement> DisplayElements { get; set; }

        /// <summary>
        /// Value corresponding to the key
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ValueMappingElement WithDisplayElements(IList<PaymentProductFieldDisplayElement> value)
        {
            DisplayElements = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ValueMappingElement WithValue(string value)
        {
            Value = value;
            return this;
        }
    }
}
