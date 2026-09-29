/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductSession302SpecificOutput
    {
        /// <summary>
        /// The payment session object that must be passed to the Apple Pay API on the client side to initialize the Apple Pay payment sheet.
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductSession302SpecificOutput WithSession(string value)
        {
            Session = value;
            return this;
        }
    }
}
