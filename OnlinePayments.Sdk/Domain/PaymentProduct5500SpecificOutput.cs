/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct5500SpecificOutput
    {
        /// <summary>
        /// The reference to be used during Multibanco payment for reconciliation matter
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// The end date of the payment validity
        /// </summary>
        public string PaymentEndDate { get; set; }

        /// <summary>
        /// The reference to be used within the Multibanco network to confirm the payment
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// The start date of the payment validity
        /// </summary>
        public string PaymentStartDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5500SpecificOutput WithEntityId(string value)
        {
            EntityId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5500SpecificOutput WithPaymentEndDate(string value)
        {
            PaymentEndDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5500SpecificOutput WithPaymentReference(string value)
        {
            PaymentReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct5500SpecificOutput WithPaymentStartDate(string value)
        {
            PaymentStartDate = value;
            return this;
        }
    }
}
