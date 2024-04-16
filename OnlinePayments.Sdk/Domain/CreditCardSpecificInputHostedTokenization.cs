/*
 * This class was auto-generated.
 */
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CreditCardSpecificInputHostedTokenization
    {
        [JsonProperty(PropertyName = "ValidationRules")]
        public CreditCardValidationRulesHostedTokenization ValidationRules { get; set; } = null;

        /// <summary>
        /// This array contains the payment product identifiers representing the brands. For co-badged cards, this displays their available brands in the order defined by this array.<para />
        /// </summary>
        public IList<int?> PaymentProductPreferredOrder { get; set; } = null;
    }
}
