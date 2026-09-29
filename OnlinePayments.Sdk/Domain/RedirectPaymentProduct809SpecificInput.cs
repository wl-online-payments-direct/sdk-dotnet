/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    [Obsolete("Deprecated, this is no longer used.")]
    public class RedirectPaymentProduct809SpecificInput
    {
        /// <summary>
        /// Deprecated. Unique ID of the issuing bank of the customer
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct809SpecificInput WithIssuerId(string value)
        {
            IssuerId = value;
            return this;
        }
    }
}
