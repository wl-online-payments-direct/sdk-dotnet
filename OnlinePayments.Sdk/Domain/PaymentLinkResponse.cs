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
        /// Base64 encoded QR code image containing the payment link URL. This field is only included in the response when displayQRCode is set to true in the request.
        /// </summary>
        public string QrCodeBase64 { get; set; }

        /// <summary>
        /// The payment link recipient name.
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// The URL that will redirect the customer to the Hosted Checkout page to process the payment.
        /// </summary>
        public string RedirectionUrl { get; set; }

        /// <summary>
        /// The current status of a payment link in its lifecycle. A payment link transitions through these states from creation to completion or termination:
        /// * ACTIVE - The payment link is active and ready to be used by the customer to complete a payment. This is the initial status when a link is created.
        /// * PAID - The payment has been successfully completed by the customer. The link can no longer be used unless it was created as a reusable link (isReusableLink = true).
        /// * CANCELLED - The payment link has been manually cancelled by the merchant and can no longer be used.
        /// * EXPIRED - The payment link has passed its expiration date (expirationDate) and is no longer usable.
        /// </summary>
        public string Status { get; set; }
    }
}
