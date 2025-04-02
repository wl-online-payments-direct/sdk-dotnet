/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class HostedCheckoutSpecificOutput
    {
        /// <summary>
        /// The ID of the Hosted Checkout Session in which the payment was made.
        /// </summary>
        public string HostedCheckoutId { get; set; }

        /// <summary>
        /// It is possible to upload multiple templates of your payment pages using the Merchant Portal. You can force the use of a custom template by specifying it in the variant field. This allows you to test out the effect of certain changes to your payment pages in a controlled manner. Please note that you need to specify the filename of the template or customization.
        /// </summary>
        public string Variant { get; set; }
    }
}
