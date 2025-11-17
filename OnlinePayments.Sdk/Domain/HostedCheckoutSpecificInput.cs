/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class HostedCheckoutSpecificInput
    {
        /// <summary>
        /// The maximum number of times a customer can try to pay before the payment is definitely declined. The value must be between 1 and 10. By default, the value is set to 10 attempts.
        /// </summary>
        public int? AllowedNumberOfPaymentAttempts { get; set; }

        /// <summary>
        /// Object containing card payment specific data for hosted checkout
        /// </summary>
        public CardPaymentMethodSpecificInputForHostedCheckout CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - A new unscheduled credentials on file series will be started. You will be able to use the paymentID of this transaction to initiate subsequent merchant initiated transactions. In the EU, the current transaction should be authenticated.</description></item>
        ///   <item><description>false - Default. No new card on file series created.</description></item>
        /// </list>
        /// </summary>
        public bool? IsNewUnscheduledCardOnFileSeries { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Only payment products that support recurring payments will be shown. Any transactions created will also be tagged as being a first of a recurring sequence.</description></item>
        ///   <item><description>false - Only payment products that support one-off payments will be shown.
        /// The default value for this property is false.</description></item>
        /// </list>
        /// </summary>
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Locale used in the GUI towards the consumer.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Contains the payment product ids and payment product groups that will be used for manipulating the payment products available for the payment to the customer.
        /// </summary>
        public PaymentProductFiltersHostedCheckout PaymentProductFilters { get; set; }

        /// <summary>
        /// The URL that the customer is redirect to after the payment flow has finished. You can add any number of key value pairs in the query string that, for instance help you to identify the customer when they return to your site. Please note that we will also append some additional key value pairs that will also help you with this identification process.
        /// Note: The provided URL should be absolute and contain the protocol to use, e.g. http:// or https://. For use on mobile devices a custom protocol can be used in the form of protocol://. This protocol must be registered on the device first.
        /// URLs without a protocol will be rejected.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The number of minutes after which the session will expire. By default, the value is set to 180 minutes.
        /// </summary>
        public int? SessionTimeout { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Default - Hosted Checkout will show a result page to the customer when applicable.</description></item>
        ///   <item><description>false - Hosted Checkout will redirect the customer back to the provided returnUrl when this is possible.</description></item>
        /// </list>
        /// </summary>
        public bool? ShowResultPage { get; set; }

        /// <summary>
        /// String containing comma separated tokens (no spaces) associated with the customer of this hosted session. Valid tokens will be used to present the customer the option to re-use previously used payment details. This means the customer for instance does not have to re-enter their card details again, which a big plus when the customer is using their mobile phone to complete the operation.
        /// </summary>
        public string Tokens { get; set; }

        /// <summary>
        /// You can force the use of a custom template by specifying it in the variant field. This allows you to test out the effect of certain changes to your payment pages in a controlled manner. Please note that you need to specify the filename of the template or customization.
        /// </summary>
        public string Variant { get; set; }
    }
}
