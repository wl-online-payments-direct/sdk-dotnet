/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct5407
    {
        /// <summary>
        /// A numeric token, which the user has to copy or type into the TWINT app in order to pair it with the merchant for the payment process.
        /// </summary>
        public string PairingToken { get; set; }

        /// <summary>
        /// Contains a base64 encoded PNG image. By prepending data:image/png;base64, this value can be used as the source of an HTML inline image on a desktop or tablet (intended to be scanned by a device with the Twint app)
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5407 WithPairingToken(string value)
        {
            PairingToken = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5407 WithQrCode(string value)
        {
            QrCode = value;
            return this;
        }
    }
}
