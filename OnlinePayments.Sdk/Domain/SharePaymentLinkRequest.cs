/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SharePaymentLinkRequest
    {
        /// <summary>
        /// Specifies the communication channel for sharing the payment link.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// The locale code in language-country format following ISO 639-1 and ISO 3166-1 standards (e.g., fr-BE, en-US, de-DE).
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// The email address of the recipient.
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SharePaymentLinkRequest WithChannel(string value)
        {
            Channel = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SharePaymentLinkRequest WithLocale(string value)
        {
            Locale = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SharePaymentLinkRequest WithRecipient(string value)
        {
            Recipient = value;
            return this;
        }
    }
}
