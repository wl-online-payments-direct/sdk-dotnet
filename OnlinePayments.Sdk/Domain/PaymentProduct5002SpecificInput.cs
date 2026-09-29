/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct5002SpecificInput
    {
        public string CheckoutResponseSignature { get; set; }

        public string CreditCardBrand { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5002SpecificInput WithCheckoutResponseSignature(string value)
        {
            CheckoutResponseSignature = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5002SpecificInput WithCreditCardBrand(string value)
        {
            CreditCardBrand = value;
            return this;
        }
    }
}
