/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class BrowserData
    {
        /// <summary>
        /// ColorDepth in bits. Value is returned from the screen.colorDepth property.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// <p />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement.
        /// </summary>
        public int? ColorDepth { get; set; }

        /// <summary>
        /// true =Java is enabled in the browser
        /// <p />
        /// false = Java is not enabled in the browser
        /// <p />
        /// Value is returned from the navigator.javaEnabled property.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// <p />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement.
        /// </summary>
        public bool? JavaEnabled { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = JavaScript is enabled in the browser.</description></item>
        ///   <item><description>false = JavaScript is not enabled in the browser. In this case the following parameters are not mandatory anymore: colorDepth, javaEnabled, screenHeight, screenWidth, timezoneOffsetUtcMinutes.</description></item>
        /// </list>
        /// </summary>
        public bool? JavaScriptEnabled { get; set; }

        /// <summary>
        /// Height of the screen in pixels. Value is returned from the screen.height property.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// <p />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement.
        /// </summary>
        public string ScreenHeight { get; set; }

        /// <summary>
        /// Width of the screen in pixels. Value is returned from the screen.width property.
        /// <p />
        /// If you use the latest version of our JavaScript Client SDK, we will collect this data and include it in the encryptedCustomerInput property. We will then automatically populate this data if available.
        /// <p />
        /// Note: This data can only be collected if JavaScript is enabled in the browser. This means that 3-D Secure version 2.1 requires the use of JavaScript to enabled. In the upcoming version 2.2 of the specification this is no longer a requirement.
        /// </summary>
        public string ScreenWidth { get; set; }
    }
}
