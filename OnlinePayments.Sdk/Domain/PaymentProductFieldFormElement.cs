/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
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

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// </summary>
        public IList<ValueMappingElement> ValueMapping { get; set; } = null;
    }
}
