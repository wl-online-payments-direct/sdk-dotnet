/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedFieldsSessionRequest
    {
        /// <summary>
        /// Locale used in the GUI towards the consumer.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// merchant site's origin.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Optional object that limits which payment products are allowed in the session.
        /// </summary>
        public PaymentProductFiltersHostedFields PaymentProductFilters { get; set; }

        /// <summary>
        /// These are your stored tokens that you can reuse during the session.
        /// </summary>
        public IList<string> Tokens { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionRequest WithLocale(string value)
        {
            Locale = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionRequest WithOrigin(string value)
        {
            Origin = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionRequest WithPaymentProductFilters(PaymentProductFiltersHostedFields value)
        {
            PaymentProductFilters = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedFieldsSessionRequest WithTokens(IList<string> value)
        {
            Tokens = value;
            return this;
        }
    }
}
