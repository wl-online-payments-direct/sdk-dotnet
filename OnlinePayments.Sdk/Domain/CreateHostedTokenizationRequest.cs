/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedTokenizationRequest
    {
        /// <summary>
        /// Indicate if the tokenization form should contain a prompt asking the user to give consent for storing their information for future payments.<para />
        /// If this parameter is false, you should ask the user yourself and provide the answer when submitting the Tokenizer in your javascript code.<para />
        /// </summary>
        public bool? AskConsumerConsent { get; set; } = null;

        /// <summary>
        /// Locale used in the GUI towards the consumer. <para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// String containing comma separated tokens (no spaces) associated with the customer of this hosted session. Valid tokens will be used to present the customer the option to re-use previously used payment details. This means the customer for instance does not have to re-enter their card details again, which a big plus when the customer is using their mobile phone to complete the operation.<para />
        /// </summary>
        public string Tokens { get; set; } = null;

        /// <summary>
        /// Using the Back-Office it is possible to upload multiple templates of your HostedCheckout payment pages, including customized templates from Merchant Portal. You can force the use of another template by specifying it in the variant field. This allows you to test out the effect of certain changes to your hostedcheckout pages in a controlled manner. Please note that you need to specify the filename of the template or customization.<para />
        /// </summary>
        public string Variant { get; set; } = null;
    }
}
