/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentContext
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// The country the payment takes place in
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// True if the payment is recurring
        /// </summary>
        public bool? IsRecurring { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentContext WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentContext WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentContext WithIsRecurring(bool? value)
        {
            IsRecurring = value;
            return this;
        }
    }
}
