/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerDevice
    {
        /// <summary>
        /// The accept-header of the customer client from the HTTP Headers.
        /// </summary>
        public string AcceptHeader { get; set; }

        /// <summary>
        /// Object containing information regarding the browser of the customer
        /// </summary>
        public BrowserData BrowserData { get; set; }

        /// <summary>
        /// The session ID for the device fingerprint must match the one sent in the device fingerprint script.
        /// </summary>
        public string DeviceFingerprint { get; set; }

        /// <summary>
        /// The IP address of the customer client from the HTTP Headers.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Locale of the client device/browser. Returned in the browser from the navigator.language property.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Offset in minutes of timezone of the client versus the UTC. Value is returned by the JavaScript getTimezoneOffset() Method.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// </summary>
        public string TimezoneOffsetUtcMinutes { get; set; }

        /// <summary>
        /// User-Agent of the client device/browser from the HTTP Headers.
        /// <p />
        /// As a fall-back we will use the userAgent that might be included in the encryptedCustomerInput, but this is captured client side using JavaScript and might be different.
        /// </summary>
        public string UserAgent { get; set; }
    }
}
