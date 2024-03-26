/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3012
    {
        /// <summary>
        /// Contains a base64 encoded PNG image. By prepending data:image/png;base64, this value can be used as the source of an HTML inline image on a desktop or tablet (intended to be scanned by a device with the Bancontact app)<para />
        /// </summary>
        public string QrCode { get; set; } = null;

        /// <summary>
        /// Contains URL intent that can be used as the link of an "open the app" button on a device<para />
        /// </summary>
        public string UrlIntent { get; set; } = null;
    }
}
