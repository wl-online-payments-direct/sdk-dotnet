/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class CreditCardSpecificInputHostedTokenization
    {
        /// <summary>
        /// Object containing specific validation rules for creditCard.
        /// </summary>
        [JsonProperty(PropertyName = "ValidationRules")]
        public CreditCardValidationRules ValidationRules { get; set; }

        /// <summary>
        /// This array contains the payment product identifiers representing the brands. For co-badged cards, this displays their available brands in the order defined by this array.
        /// </summary>
        public IList<int?> PaymentProductPreferredOrder { get; set; }
    }
}
