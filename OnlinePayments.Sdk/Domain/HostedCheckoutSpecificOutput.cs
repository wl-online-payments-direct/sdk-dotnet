/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class HostedCheckoutSpecificOutput
    {
        /// <summary>
        /// The ID of the Hosted Checkout Session in which the payment was made.<para />
        /// </summary>
        public string HostedCheckoutId { get; set; } = null;

        /// <summary>
        /// Using the Back-Office it is possible to upload multiple templates of your HostedCheckout payment pages, including customized templates from Merchant Portal. You can force the use of another template by specifying it in the variant field. This allows you to test out the effect of certain changes to your hostedcheckout pages in a controlled manner. Please note that you need to specify the filename of the template or customization.<para />
        /// </summary>
        public string Variant { get; set; } = null;
    }
}
