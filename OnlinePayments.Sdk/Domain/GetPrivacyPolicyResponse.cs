/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetPrivacyPolicyResponse
    {
        /// <summary>
        /// HTML content to be displayed to the user.
        /// </summary>
        public string HtmlContent { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetPrivacyPolicyResponse WithHtmlContent(string value)
        {
            HtmlContent = value;
            return this;
        }
    }
}
