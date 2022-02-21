/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class BrowserData
    {
        /// <summary>
        /// ColorDepth in bits. Value is returned from the screen.colorDepth property.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// <para />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement. As we currently support version 2.1 it means that this property is required when cardPaymentMethodSpecifInput.threeDSecure.authenticationFlow is set to "browser".<para />
        /// </summary>
        public int? ColorDepth { get; set; } = null;

        /// <summary>
        /// true =Java is enabled in the browser<para />
        /// <para />
        /// false = Java is not enabled in the browser<para />
        /// <para />
        /// Value is returned from the navigator.javaEnabled property.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// <para />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement. As we currently support version 2.1 it means that this property is required when cardPaymentMethodSpecifInput.threeDSecure.authenticationFlow is set to "browser".<para />
        /// </summary>
        public bool? JavaEnabled { get; set; } = null;

        /// <summary>
        /// * true = JavaScript is enabled in the browser.<para />
        /// * false = JavaScript is not enabled in the browser. In this case the following parameters are not mandatory anymore: colorDepth, javaEnabled, screenHeight, screenWidth, timezoneOffsetUtcMinutes.<para />
        /// </summary>
        public bool? JavaScriptEnabled { get; set; } = null;

        /// <summary>
        /// Height of the screen in pixels. Value is returned from the screen.height property.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// <para />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement. As we currently support version 2.1 it means that this property is required when cardPaymentMethodSpecifInput.threeDSecure.authenticationFlow is set to "browser".<para />
        /// </summary>
        public string ScreenHeight { get; set; } = null;

        /// <summary>
        /// Width of the screen in pixels. Value is returned from the screen.width property.<para />
        /// <para />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.<para />
        /// <para />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement. As we currently support version 2.1 it means that this property is required when cardPaymentMethodSpecifInput.threeDSecure.authenticationFlow is set to "browser".<para />
        /// </summary>
        public string ScreenWidth { get; set; } = null;
    }
}
