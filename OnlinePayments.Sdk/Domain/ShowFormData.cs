/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ShowFormData
    {
        /// <summary>
        /// Contains the third party data for payment product 3012 (Bancontact)
        /// </summary>
        public PaymentProduct3012 PaymentProduct3012 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product 350 (Swish)
        /// </summary>
        public PaymentProduct350 PaymentProduct350 { get; set; }

        /// <summary>
        /// Deprecated by pendingAuthentication. Contains the third party data for payment product 5001 (Bizum)
        /// </summary>
        public PaymentProduct5001 PaymentProduct5001 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product 5404 (WeChat Pay)
        /// </summary>
        public PaymentProduct5404 PaymentProduct5404 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product 5407 (Twint)
        /// </summary>
        public PaymentProduct5407 PaymentProduct5407 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product requiring an external authentication (e.g., Bizum, CV Connect)
        /// </summary>
        public PendingAuthentication PendingAuthentication { get; set; }
    }
}
