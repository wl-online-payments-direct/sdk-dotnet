/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetIINDetailsRequest
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits. Providing additional digits (up to 19) can result in more co-brands being returned.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// Optional payment context to refine the IIN lookup to filter out payment products not applicable to your payment.
        /// </summary>
        public PaymentContext PaymentContext { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsRequest WithBin(string value)
        {
            Bin = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsRequest WithPaymentContext(PaymentContext value)
        {
            PaymentContext = value;
            return this;
        }
    }
}
