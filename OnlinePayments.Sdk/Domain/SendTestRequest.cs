/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SendTestRequest
    {
        /// <summary>
        /// Url to which the dummy webhook would be sent. If the parameter is not sent, It will be sent as default to the webhook url configured in the backoffice.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SendTestRequest WithUrl(string value)
        {
            Url = value;
            return this;
        }
    }
}
