/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkSpecificInput
    {
        /// <summary>
        /// A note related to the created payment link.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 6 months in the future or a past date. It must also contain the UTC offset.
        /// </summary>
        public DateTimeOffset ExpirationDate { get; set; }

        /// <summary>
        /// The payment link recipient name.
        /// </summary>
        public string RecipientName { get; set; }
    }
}
