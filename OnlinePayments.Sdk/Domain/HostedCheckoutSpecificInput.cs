/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class HostedCheckoutSpecificInput
    {
        /// <summary>
        /// Object containing card payment specific data for hosted checkout<para />
        /// </summary>
        public CardPaymentMethodSpecificInputForHostedCheckout CardPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// * true - Only payment products that support recurring payments will be shown. Any transactions created will also be tagged as being a first of a recurring sequence.<para />
        /// * false - Only payment products that support one-off payments will be shown.<para />
        /// The default value for this property is false.<para />
        /// </summary>
        public bool? IsRecurring { get; set; } = null;

        /// <summary>
        /// Locale used in the GUI towards the consumer. <para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// Contains the payment product ids and payment product groups that will be used for manipulating the payment products available for the payment to the customer.<para />
        /// </summary>
        public PaymentProductFiltersHostedCheckout PaymentProductFilters { get; set; } = null;

        /// <summary>
        /// The URL that the customer is redirect to after the payment flow has finished. You can add any number of key value pairs in the query string that, for instance help you to identify the customer when they return to your site. Please note that we will also append some additional key value pairs that will also help you with this identification process.<para />
        /// Note: The provided URL should be absolute and contain the protocol to use, e.g. http:// or https://. For use on mobile devices a custom protocol can be used in the form of protocol://. This protocol must be registered on the device first.<para />
        /// URLs without a protocol will be rejected.<para />
        /// </summary>
        public string ReturnUrl { get; set; } = null;

        /// <summary>
        /// The number of minutes after which the session will expire. By default, the value is set to 180 minutes.<para />
        /// </summary>
        public int? SessionTimeout { get; set; } = null;

        /// <summary>
        /// * true - Default - Hosted Checkout will show a result page to the customer when applicable.<para />
        /// * false - Hosted Checkout will redirect the customer back to the provided returnUrl when this is possible.<para />
        /// </summary>
        public bool? ShowResultPage { get; set; } = null;

        /// <summary>
        /// String containing comma separated tokens (no spaces) associated with the customer of this hosted session. Valid tokens will be used to present the customer the option to re-use previously used payment details. This means the customer for instance does not have to re-enter their card details again, which a big plus when the customer is using their mobile phone to complete the operation.<para />
        /// </summary>
        public string Tokens { get; set; } = null;

        /// <summary>
        /// Using the Back-Office it is possible to upload multiple templates of your HostedCheckout payment pages. You can force the use of another template by specifying it in the variant field. This allows you to test out the effect of certain changes to your hostedcheckout pages in a controlled manner. Please note that you need to specify the filename of the template.<para />
        /// </summary>
        public string Variant { get; set; } = null;
    }
}
