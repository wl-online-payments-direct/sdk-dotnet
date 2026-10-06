/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFiltersHostedFields
    {
        /// <summary>
        /// List containing all payment product ids that should either be restricted to in or excluded from the payment context.
        /// </summary>
        public IList<int> Exclude { get; set; }

        /// <summary>
        /// List containing all payment product ids that should either be restricted to in or excluded from the payment context.
        /// </summary>
        public IList<int> RestrictTo { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFiltersHostedFields WithExclude(IList<int> value)
        {
            Exclude = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFiltersHostedFields WithRestrictTo(IList<int> value)
        {
            RestrictTo = value;
            return this;
        }
    }
}
