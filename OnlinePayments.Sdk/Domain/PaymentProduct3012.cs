/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3012
    {
        /// <summary>
        /// Contains a value which can be used to build a QR code (intended to be scanned by a device with the Bancontact app)
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// Contains URL intent that can be used as the link of an &quot;open the app&quot; button on a device
        /// </summary>
        public string UrlIntent { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3012 WithQrCode(string value)
        {
            QrCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3012 WithUrlIntent(string value)
        {
            UrlIntent = value;
            return this;
        }
    }
}
