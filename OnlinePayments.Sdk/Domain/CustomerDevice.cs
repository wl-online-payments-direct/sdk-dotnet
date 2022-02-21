/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerDevice
    {
        /// <summary>
        /// The accept-header of the customer client from the HTTP Headers.<para />
        /// </summary>
        public string AcceptHeader { get; set; } = null;

        /// <summary>
        /// Object containing information regarding the browser of the customer<para />
        /// </summary>
        public BrowserData BrowserData { get; set; } = null;

        /// <summary>
        /// The IP address of the customer client from the HTTP Headers.<para />
        /// </summary>
        public string IpAddress { get; set; } = null;

        /// <summary>
        /// Locale of the client device/browser. Returned in the browser from the navigator.language property.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// Offset in minutes of timezone of the client versus the UTC. Value is returned by the JavaScript getTimezoneOffset() Method.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// </summary>
        public string TimezoneOffsetUtcMinutes { get; set; } = null;

        /// <summary>
        /// User-Agent of the client device/browser from the HTTP Headers.<para />
        /// <para />
        /// As a fall-back we will use the userAgent that might be included in the encryptedCustomerInput, but this is captured client side using JavaScript and might be different.<para />
        /// </summary>
        public string UserAgent { get; set; } = null;
    }
}
