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

        public IList<string> Tokens { get; set; }
    }
}
