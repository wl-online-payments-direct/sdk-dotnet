/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkResponse
    {
        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date will contain the UTC offset.
        /// </summary>
        public DateTimeOffset ExpirationDate { get; set; }

        /// <summary>
        /// Indicates if the payment link can be used multiple times. The default value for this property is false
        /// </summary>
        public bool? IsReusableLink { get; set; }

        /// <summary>
        /// The unique payment transaction identifier. This id is only set when a payment was processed with this payment link.
        /// </summary>
        public string PaymentId { get; set; }

        public IList<PaymentLinkEvent> PaymentLinkEvents { get; set; }

        /// <summary>
        /// The unique link identifier.
        /// </summary>
        public string PaymentLinkId { get; set; }

        /// <summary>
        /// An object containing the details of the related payment output.
        /// </summary>
        public PaymentLinkOrderOutput PaymentLinkOrder { get; set; }

        /// <summary>
        /// The payment link recipient name.
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// The URL that will redirect the customer to the Hosted Checkout page to process the payment.
        /// </summary>
        public string RedirectionUrl { get; set; }

        /// <summary>
        /// The state of the payment link:
        /// <list type="bullet">
        ///   <item><description>ACTIVE: The payment link is ready to be used.</description></item>
        ///   <item><description>PAID: The payment has been completed.</description></item>
        ///   <item><description>CANCELLED: The payment link has been manually cancelled.</description></item>
        ///   <item><description>EXPIRED: The payment link is not usable anymore.</description></item>
        /// </list>
        /// </summary>
        public string Status { get; set; }
    }
}
