/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductGroup
    {
        public AccountOnFile AccountOnFile { get; set; }

        /// <summary>
        /// Deprecated: field is replaced by displayHintsList
        /// </summary>
        public PaymentProductDisplayHints DisplayHints { get; set; }

        /// <summary>
        /// List of display hints
        /// </summary>
        public IList<PaymentProductDisplayHints> DisplayHintsList { get; set; }

        /// <summary>
        /// The ID of the payment product group in our system
        /// </summary>
        public string Id { get; set; }
    }
}
