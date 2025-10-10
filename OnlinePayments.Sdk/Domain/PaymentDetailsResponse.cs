/*
 * This file was automatically generated.
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentDetailsResponse
    {
        /// <summary>
        /// Object that contains the complete list of operations executed on the payment.
        /// </summary>
        [JsonProperty(PropertyName = "Operations")]
        public IList<OperationOutput> Operations { get; set; }

        /// <summary>
        /// Hosted Checkout specific information. Populated if the payment was created on the platform through a Hosted Checkout.
        /// </summary>
        public HostedCheckoutSpecificOutput HostedCheckoutSpecificOutput { get; set; }

        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Object containing payment details
        /// </summary>
        public PaymentOutput PaymentOutput { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This object has the numeric representation of the current payment status, the timestamp of the last status change, and the performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.
        /// </summary>
        public PaymentStatusOutput StatusOutput { get; set; }
    }
}
