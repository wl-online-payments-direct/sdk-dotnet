/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOverviewEntry
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney Amount { get; set; }

        /// <summary>
        /// The identifier of the user or entity that created the payment link.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date and time when the payment link was created. The date contains the UTC offset.
        /// </summary>
        public DateTimeOffset? CreationDate { get; set; }

        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 6 months in the future or a past date. It must also contain the UTC offset.
        /// </summary>
        public DateTimeOffset? ExpirationDate { get; set; }

        /// <summary>
        /// Indicates if the payment link can be used multiple times.
        /// </summary>
        public bool? IsReusableLink { get; set; }

        /// <summary>
        /// The unique Merchant Id of the merchant associated with the payment link.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// Your unique reference of the transaction that is also returned in our report files. This is almost always used for your reconciliation of our report files.
        /// It is highly recommended to provide a single MerchantReference per unique order on your side
        /// </summary>
        public string MerchantReference { get; set; }

        /// <summary>
        /// The unique identifier of the payment link.
        /// </summary>
        public string PaymentLinkId { get; set; }

        /// <summary>
        /// The URL that will redirect the customer to the payment page to process the payment.
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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithAmount(AmountOfMoney value)
        {
            Amount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithCreatedBy(string value)
        {
            CreatedBy = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithCreationDate(DateTimeOffset? value)
        {
            CreationDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithExpirationDate(DateTimeOffset? value)
        {
            ExpirationDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithIsReusableLink(bool? value)
        {
            IsReusableLink = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithMerchantId(string value)
        {
            MerchantId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithMerchantReference(string value)
        {
            MerchantReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithPaymentLinkId(string value)
        {
            PaymentLinkId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithRedirectionUrl(string value)
        {
            RedirectionUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewEntry WithStatus(string value)
        {
            Status = value;
            return this;
        }
    }
}
