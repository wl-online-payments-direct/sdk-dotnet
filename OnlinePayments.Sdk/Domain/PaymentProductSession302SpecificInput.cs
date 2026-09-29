/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductSession302SpecificInput
    {
        /// <summary>
        /// A human-readable name for the merchant, as it would be displayed to the user within the Apple Pay interface.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The fully qualified domain name of the web page that will host the Apple Pay session.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductSession302SpecificInput WithDisplayName(string value)
        {
            DisplayName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductSession302SpecificInput WithDomainName(string value)
        {
            DomainName = value;
            return this;
        }
    }
}
