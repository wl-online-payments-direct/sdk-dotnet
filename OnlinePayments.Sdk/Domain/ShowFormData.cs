/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ShowFormData
    {
        /// <summary>
        /// Contains the third party data for payment product 11 (Offline Bank transfer)
        /// </summary>
        public PaymentProduct11 PaymentProduct11 { get; set; }

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
        /// Contains the third party data for payment product 5412 (Chèque-Vacances Connect)
        /// </summary>
        public PaymentProduct5412 PaymentProduct5412 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product 840 (PayPal)
        /// </summary>
        public PaymentProduct840 PaymentProduct840 { get; set; }

        /// <summary>
        /// Contains the third party data for payment product requiring an external authentication (e.g., Bizum, CV Connect)
        /// </summary>
        public PendingAuthentication PendingAuthentication { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct11(PaymentProduct11 value)
        {
            PaymentProduct11 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct3012(PaymentProduct3012 value)
        {
            PaymentProduct3012 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct350(PaymentProduct350 value)
        {
            PaymentProduct350 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct5001(PaymentProduct5001 value)
        {
            PaymentProduct5001 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct5404(PaymentProduct5404 value)
        {
            PaymentProduct5404 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct5407(PaymentProduct5407 value)
        {
            PaymentProduct5407 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct5412(PaymentProduct5412 value)
        {
            PaymentProduct5412 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPaymentProduct840(PaymentProduct840 value)
        {
            PaymentProduct840 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ShowFormData WithPendingAuthentication(PendingAuthentication value)
        {
            PendingAuthentication = value;
            return this;
        }
    }
}
