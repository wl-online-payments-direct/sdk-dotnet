/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ApplePayRecurringPaymentRequest
    {
        /// <summary>
        /// A localized billing agreement that the payment sheet displays to the user before the user authorizes the payment.
        /// </summary>
        public string BillingAgreement { get; set; }

        /// <summary>
        /// A URL to a web page where the user can update or delete the payment method for the recurring payment.
        /// </summary>
        public string ManagementUrl { get; set; }

        /// <summary>
        /// A description of the recurring payment that Apple Pay displays to the user in the payment sheet.
        /// </summary>
        public string PaymentDescription { get; set; }

        /// <summary>
        /// Object containing specific data regarding Apple Pay recurring payment.
        /// </summary>
        public ApplePayLineItem RegularBilling { get; set; }

        /// <summary>
        /// Object containing specific data regarding Apple Pay recurring payment.
        /// </summary>
        public ApplePayLineItem TrialBilling { get; set; }
    }
}
