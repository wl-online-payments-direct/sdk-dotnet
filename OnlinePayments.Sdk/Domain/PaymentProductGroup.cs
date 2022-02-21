/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductGroup
    {
        public AccountOnFile AccountOnFile { get; set; } = null;

        /// <summary>
        /// Object containing display hints like the order of the product when shown in a list, the name of the product and the logo<para />
        /// </summary>
        public PaymentProductDisplayHints DisplayHints { get; set; } = null;

        /// <summary>
        /// List of display hints<para />
        /// </summary>
        public IList<PaymentProductDisplayHints> DisplayHintsList { get; set; } = null;

        /// <summary>
        /// The ID of the payment product group in our system<para />
        /// </summary>
        public string Id { get; set; } = null;
    }
}
