/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class CreditCardSpecificInputHostedTokenization
    {
        [JsonProperty(PropertyName = "ValidationRules")]
        public CreditCardValidationRulesHostedTokenization ValidationRules { get; set; }

        /// <summary>
        /// This array contains the payment product identifiers representing the brands. For co-badged cards, this displays their available brands in the order defined by this array.
        /// </summary>
        public IList<int?> PaymentProductPreferredOrder { get; set; }
    }
}
