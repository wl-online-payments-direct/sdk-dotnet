/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class Feedbacks
    {
        /// <summary>
        /// The URL where the webhook will be dispatched for all status change events related to this payment.
        /// </summary>
        [Obsolete("The URL where the webhook will be dispatched for all status change events related to this payment.")]
        public string WebhookUrl { get; set; }

        /// <summary>
        /// The list of the URLs where the webhook will be dispatched for all status change events related to this payment.
        /// </summary>
        public IList<string> WebhooksUrls { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("The URL where the webhook will be dispatched for all status change events related to this payment.")]
        public Feedbacks WithWebhookUrl(string value)
        {
            WebhookUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Feedbacks WithWebhooksUrls(IList<string> value)
        {
            WebhooksUrls = value;
            return this;
        }
    }
}
