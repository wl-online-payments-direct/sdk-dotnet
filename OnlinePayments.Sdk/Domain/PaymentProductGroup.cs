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
        /// Object containing display hints like the order of the product when shown in a list, the name of the product and the logo
        /// </summary>
        public PaymentProductDisplayHints DisplayHints { get; set; }

        public IList<PaymentProductDisplayHints> DisplayHintsList { get; set; }

        /// <summary>
        /// The ID of the payment product group in our system
        /// </summary>
        public string Id { get; set; }
    }
}
