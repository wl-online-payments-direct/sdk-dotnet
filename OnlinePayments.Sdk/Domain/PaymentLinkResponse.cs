/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkResponse
    {
        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent must contain the UTC offset.<para />
        /// </summary>
        public string ExpirationDate { get; set; } = null;

        /// <summary>
        /// The unique payment transaction identifier. This id is only set when a payment was processed with this payment link.<para />
        /// </summary>
        public string PaymentId { get; set; } = null;

        public IList<PaymentLinkEvent> PaymentLinkEvents { get; set; } = null;

        /// <summary>
        /// The unique link identifier.<para />
        /// </summary>
        public string PaymentLinkId { get; set; } = null;

        /// <summary>
        /// An object containing the details of the related payment.<para />
        /// </summary>
        public PaymentLinkOrder PaymentLinkOrder { get; set; } = null;

        /// <summary>
        /// The payment link recipient name.<para />
        /// </summary>
        public string RecipientName { get; set; } = null;

        /// <summary>
        /// The URL that will redirect the customer to the Hosted Checkout page to process the payment.<para />
        /// </summary>
        public string RedirectionUrl { get; set; } = null;

        /// <summary>
        /// The state of the payment link:<para />
        ///   * ACTIVE: The payment link is ready to be used.<para />
        ///   * PAID: The payment has been completed.<para />
        ///   * CANCELLED: The payment link has been manually cancelled.<para />
        ///   * EXPIRED: The payment link is not usable anymore.<para />
        /// </summary>
        public string Status { get; set; } = null;
    }
}
