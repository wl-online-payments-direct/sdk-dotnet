/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentProductFieldFormElement
    {
        /// <summary>
        /// Type of form element to be used. The following types can be returned:<para />
        /// * text - A normal text input field<para />
        /// * list - A list of values that the customer needs to choose from, is detailed in the valueMapping array<para />
        /// * currency - Currency fields should be split into two fields, with the second one being specifically for the cents<para />
        /// * boolean - Boolean fields should offer the customer a choice, like accepting the terms and conditions of a product.<para />
        /// * date - let the customer pick a date.<para />
        /// </summary>
        public string Type { get; set; } = null;

        public IList<ValueMappingElement> ValueMapping { get; set; } = null;
    }
}
