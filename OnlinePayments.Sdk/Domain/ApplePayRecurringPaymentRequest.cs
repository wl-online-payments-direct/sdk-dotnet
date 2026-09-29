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
        /// Object containing specific data regarding Apple Pay recurring regular payment
        /// </summary>
        public ApplePayLineItem RegularBilling { get; set; }

        /// <summary>
        /// Object containing specific data regarding Apple Pay recurring trial payment
        /// </summary>
        public ApplePayLineItem TrialBilling { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApplePayRecurringPaymentRequest WithBillingAgreement(string value)
        {
            BillingAgreement = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApplePayRecurringPaymentRequest WithManagementUrl(string value)
        {
            ManagementUrl = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApplePayRecurringPaymentRequest WithPaymentDescription(string value)
        {
            PaymentDescription = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApplePayRecurringPaymentRequest WithRegularBilling(ApplePayLineItem value)
        {
            RegularBilling = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ApplePayRecurringPaymentRequest WithTrialBilling(ApplePayLineItem value)
        {
            TrialBilling = value;
            return this;
        }
    }
}
