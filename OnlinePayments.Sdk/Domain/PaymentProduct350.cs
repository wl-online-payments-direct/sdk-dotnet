/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct350
    {
        /// <summary>
        /// Contains an application switch URL for opening the Swish application on a mobile device (intended to be used by a device with the Swish app installed)
        /// </summary>
        public string AppSwitchLink { get; set; }

        /// <summary>
        /// Contains the token that identifies the payment on the Swish side. This can be used to generate a QR code (either manually or by calling the public QR Code API of Swish) to be scanned by the Swish app.
        /// </summary>
        public string PaymentRequestToken { get; set; }
    }
}
